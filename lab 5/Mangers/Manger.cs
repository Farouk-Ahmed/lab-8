using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mangers
{
    public class Manger<T> : IManger<T> where T : BaseModel
    {
        private DbSet<T> set;
        public Manger(DbSet<T> Data)
        {
                this.set = Data;
        }
        public void Add(T Item)
        {
            this.set.Add(Item);
        }

        public IEnumerable<T> GetAll()
        {
            return set.ToList();
        }

        public T GetById(int id)
        {
            foreach (T item in set)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public void Remove(T Item)
        {
            this.Remove(Item);
        }

        public void Update(T Item)
        {
            this.Update(Item);
        }
    }
}
