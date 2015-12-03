using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatRent.Model;
using System.Windows;

namespace FlatRent.ViewModel
{
    class WallMaterialDAO
    {
        FlatrentEntities context = new FlatrentEntities();

        public wallmaterial Create(string title, int coefficient)
        {
            FlatrentEntities context = new FlatrentEntities();
            wallmaterial wallmaterial = context.wallmaterials.Create();
            wallmaterial.title = title;
            wallmaterial.coefficient = coefficient;
            context.wallmaterials.Add(wallmaterial);
            context.SaveChanges();
            return wallmaterial;
        }

        public wallmaterial GetWallMaterialById(int id)
        {
            wallmaterial wallmaterial = context.wallmaterials.Find(id);
            return wallmaterial;
        }

        public List<wallmaterial> GetAllWallMaterials()
        {
            var list = from wallmaterial in context.wallmaterials
                       select wallmaterial;
            return list.ToList();
        }

        public void Update(wallmaterial wallmaterial)
        {
            FlatrentEntities context = new FlatrentEntities();
            context.Entry(wallmaterial).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public int GetIdWallMaterialByTitle(string title)
        {
            List<region> wallmaterialList = context.regions.SqlQuery("SELECT * from wallmaterial WHERE wallmaterial.title ='" + title + "'").ToList();
            if (wallmaterialList.Count == 0)
            {
                MessageBox.Show("Не найдено данного материала стен");
            }

            return wallmaterialList[0].id;
        }
        public void Delete(int id)
        {
            wallmaterial wallmaterial = context.wallmaterials.Find(id);
            if (wallmaterial == null)
            {
                MessageBox.Show("Не найдено материала стен с таким id!");
            }
            else
            {
                context.wallmaterials.Remove(wallmaterial);
                context.SaveChanges();
            }

        }
    }
}
