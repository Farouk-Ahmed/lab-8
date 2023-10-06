using App.Mangers;
using App.Models;
using App.Storage;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class UnitOfWork : App.IUnitOfWork
    {
        IStorage storage;
        public UnitOfWork(IStorage storage) {
            this.storage = storage;
        }
        private ITraineeManger tMnger;
        private ICourseManger cMnger;
        public ITraineeManger TManger
        {
            get
            {
                if(tMnger == null)
                    tMnger = new TraineeManager(storage.Trainees);
                return tMnger;
            }
        }
        public ICourseManger ICourseManger
        { 
            get
            {
                if(cMnger == null)
                    cMnger = new CourseManger(storage.Courses);
                return cMnger;
            }
        }

        

        public int SaveChanges()
        {
            return storage.SaveChanges();
        }

    }
}
