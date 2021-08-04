using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly Dbcontainer db;

        public DistrictRep(Dbcontainer db)
        {
            this.db = db;
        }

        public IQueryable<DiscritVM> Get()
        {
            IQueryable<DiscritVM> data = GetAllDistricts();
            return data;
        }

       

        public DiscritVM GetById(int id)
        {
            DiscritVM data = GetDistrictsById(id);
            return data;
        }
        //Refactor
        private DiscritVM GetDistrictsById(int id)
        {
            return db.Districts.Where(a => a.Id == id).Select(a => new DiscritVM { Id = a.Id, DistrictName = a.DistrictName, CityId =a.CityId }).FirstOrDefault();
        }
        private IQueryable<DiscritVM> GetAllDistricts()
        {
            return db.Districts.Select(a => new DiscritVM { Id = a.Id, DistrictName = a.DistrictName, CityId = a.CityId });
        }
    }
}
