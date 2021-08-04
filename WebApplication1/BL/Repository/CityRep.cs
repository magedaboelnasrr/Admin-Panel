using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly Dbcontainer db;

        public CityRep(Dbcontainer db)
        {
            this.db = db;
        }

        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCities();
            return data;
        }

       

        public CityVM GetById(int id)
        {
            CityVM data = GetCityById(id);
            return data;
        }


        //Refactor
        private CityVM GetCityById(int id)
        {
            return db.Cities.Where(a => a.Id == id).Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId }).FirstOrDefault();
        }
        private IQueryable<CityVM> GetAllCities()
        {
            return db.Cities.Select(a => new CityVM { Id = a.Id, CityName = a.CityName, CountryId = a.CountryId });
        }
    }
}
