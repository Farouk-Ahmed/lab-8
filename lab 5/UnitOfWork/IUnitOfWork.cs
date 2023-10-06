using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Mangers;

namespace App
{
    public interface IUnitOfWork
    {
        ITraineeManger TManger { get; }
        ICourseManger ICourseManger { get; }
        int SaveChanges();
    }
}
