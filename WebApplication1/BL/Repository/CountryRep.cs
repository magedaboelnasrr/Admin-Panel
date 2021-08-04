using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly Dbcontainer db;

        public CountryRep(Dbcontainer db)
        {
            this.db = db;
        }
        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;
        }

        

        public CountryVM GetById(int id)
        {
            CountryVM data = GetCountryById(id);
            return data;
        }

        private CountryVM GetCountryById(int id)
        {
            return db.Countries.Where(a => a.Id == id).Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName }).FirstOrDefault();
        }
        private IQueryable<CountryVM> GetAllCountries()
        {
            return db.Countries.Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
        }
    }
}
