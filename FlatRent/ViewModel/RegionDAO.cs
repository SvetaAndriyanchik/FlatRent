using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatRent.Model;
using System.Windows;

namespace FlatRent.ViewModel
{
    public class RegionDAO
    {
        FlatrentEntities context = new FlatrentEntities();

        public region Create(string title, int coefficient)
        {
            FlatrentEntities context = new FlatrentEntities();
            region region = context.regions.Create();
            region.title = title;
            region.coefficient = coefficient;
            context.regions.Add(region);
            context.SaveChanges();
            return region;
        }

        public region GetRegionById(int id)
        {
            region region = context.regions.Find(id);
            return region;
        }

        public List<region> GetAllRegions()
        {
            var list = from region in context.regions
                       select region;
            return list.ToList();
        }

        public void Update(region region)
        {
            FlatrentEntities context = new FlatrentEntities();
            context.Entry(region).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public int GetIdRegionByTitle(string title)
        {
            List<region> regionList = context.regions.SqlQuery("SELECT * from region WHERE region.title ='" + title + "'").ToList();
            if (regionList.Count == 0)
            {
                MessageBox.Show("Не найдено данного региона");      
            }

            return regionList[0].id;
        }
        public void Delete(int id)
        {
            region region = context.regions.Find(id);
            if (region == null)
            {
                MessageBox.Show("Не найдено региона с таким id!");
            }
            else
            {
                context.regions.Remove(region);
                context.SaveChanges();
            }

        }

    }
}
