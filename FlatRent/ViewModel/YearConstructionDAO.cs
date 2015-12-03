using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlatRent.Model;

namespace FlatRent.ViewModel
{
    class YearConstructionDAO
    {
        FlatrentEntities context = new FlatrentEntities();

        public yearconstruction Create(int year, int coefficient)
        {
            FlatrentEntities context = new FlatrentEntities();
            yearconstruction yearconstruction = context.yearconstructions.Create();
            yearconstruction.yearConstruction = year;
            yearconstruction.coefficient = coefficient;
            context.yearconstructions.Add(yearconstruction);
            context.SaveChanges();
            return yearconstruction;
        }

        public yearconstruction GetYearConstructionById(int id)
        {
            yearconstruction yearconstruction = context.yearconstructions.Find(id);
            return yearconstruction;
        }

        public List<yearconstruction> GetAllYearConstructions()
        {
            var list = from yearconstruction in context.yearconstructions
                       select yearconstruction;
            return list.ToList();
        }

        public void Update(yearconstruction yearconstruction)
        {
            FlatrentEntities context = new FlatrentEntities();
            context.Entry(yearconstruction).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public int GetIdYearConstructionByYear(int year)
        {
            List<yearconstruction> yearconstructionList = context.yearconstructions.SqlQuery("SELECT * from yearconstruction WHERE yearconstruction.yearConstruction ='" + year + "'").ToList();
            if (yearconstructionList.Count == 0)
            {
                MessageBox.Show("Не найдено");
            }

            return yearconstructionList[0].id;
        }
        public void Delete(int id)
        {
            yearconstruction yearconstruction = context.yearconstructions.Find(id);
            if (yearconstruction == null)
            {
                MessageBox.Show("Не найдено");
            }
            else
            {
                context.yearconstructions.Remove(yearconstruction);
                context.SaveChanges();
            }

        }
    }
}
