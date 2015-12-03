using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlatRent.Model;

namespace FlatRent.ViewModel
{
    class RoomCountDAO
    {
        FlatrentEntities context = new FlatrentEntities();

        public roomcount Create(int roomCount, int coefficient)
        {
            FlatrentEntities context = new FlatrentEntities();
            roomcount roomcount = context.roomcounts.Create();
            roomcount.roomCount = roomCount;
            roomcount.coefficient = coefficient;
            context.roomcounts.Add(roomcount);
            context.SaveChanges();
            return roomcount;
        }

        public roomcount GetRootCountById(int id)
        {
            roomcount roomcount = context.roomcounts.Find(id);
            return roomcount;
        }

        public List<roomcount> GetAllRoomCounts()
        {
            var list = from roomcount in context.roomcounts
                       select roomcount;
            return list.ToList();
        }

        public void Update(roomcount roomcount)
        {
            FlatrentEntities context = new FlatrentEntities();
            context.Entry(roomcount).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public int GetIdRoomCountByCount(int count)
        {
            List<roomcount> roomcountList = context.roomcounts.SqlQuery("SELECT * from roomcount WHERE roomcount.roomCount ='" + count + "'").ToList();
            if (roomcountList.Count == 0)
            {
                MessageBox.Show("Не найдено");
            }

            return roomcountList[0].id;
        }
        public void Delete(int id)
        {
            roomcount roomcount = context.roomcounts.Find(id);
            if (roomcount == null)
            {
                MessageBox.Show("Не найдено");
            }
            else
            {
                context.roomcounts.Remove(roomcount);
                context.SaveChanges();
            }

        }
    }
}
