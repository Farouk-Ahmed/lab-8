using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mangers
{
    internal class TraineeManager : Manger<Trainee>, ITraineeManger
    {
        public TraineeManager(DbSet<Trainee> trainees) :base(trainees) 
        {
            
        }
    }
}
