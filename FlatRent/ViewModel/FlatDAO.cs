using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlatRent.Model;

namespace FlatRent.ViewModel
{
    public class FlatDAO
    {
        FlatrentEntities context = new FlatrentEntities();

        public flat Create(int idRegion, int idRoomCount, int idWallMaterial, int idYearConstruction, int floor, int numberOfFloors,float square,
            string street, int houseNumber, int flatNumber)
        {
            FlatrentEntities context = new FlatrentEntities();
            flat flat = context.flats.Create();
            
            flat.idRegion = idRegion;
            flat.idRoomCount = idRoomCount;
            flat.idWallMaterial = idWallMaterial;
            flat.idYearConstruction = idYearConstruction;
            flat.floor = floor;
            flat.numberOfFloors = numberOfFloors;
            flat.square = square;
            flat.street = street;
            flat.houseNumber = houseNumber;
            flat.flatNumber = flatNumber;
            flat.views = 0;

            context.flats.Add(flat);
            context.SaveChanges();
            return flat;
        }

        public flat GetFlatById(int id)
        {
            flat flat = context.flats.Find(id);
            return flat;
        }

        public List<flat> GetAllFlats()
        {
            var list = from flat in context.flats
                       select flat;
            return list.ToList();
        }

        public void Update(flat flat)
        {
            FlatrentEntities context = new FlatrentEntities();
            context.Entry(flat).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public List<flat> GetFlatsByIdRegion(int idRegion)
        {
            List<flat> flatList = context.flats.SqlQuery("SELECT * from flat WHERE flat.idRegion ='" + idRegion + "'").ToList();
            if (flatList.Count == 0)
            {
                MessageBox.Show("Не найдено квартир в данном регионе");
            }

            return flatList;
        }

        public void AddFlatViewsById(int id){
             flat flat = context.flats.Find(id);
             flat.views++;
             Update(flat);
        }
        public void Delete(int id)
        {
            flat flat = context.flats.Find(id);
            if (flat == null)
            {
                MessageBox.Show("Не найдено квартиры по данному id");
            }
            else
            {
                context.flats.Remove(flat);
                context.SaveChanges();
            }

        }
    }
    
}
