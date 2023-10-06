using App.Mangers;
using App.Models;
using App.Storage;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStorage storage = new INMemoryStorage();
            IUnitOfWork unitOfWork = new UnitOfWork(storage);


            unitOfWork.TManger.Add(new Trainee { Id = 1, Name = "ahmed" });
            unitOfWork.TManger.Add(new Trainee { Id = 2, Name = "Shawky" });

            unitOfWork.ICourseManger.Add(new Course { Id = 1, Name = "Math" });

            unitOfWork.SaveChanges();

            foreach (var c in unitOfWork.TManger.GetAll()) {
                Console.WriteLine(c.Name);

            }
            foreach (var t in unitOfWork.ICourseManger.GetAll())
            {
                Console.WriteLine(t.Name);

            }


        }
    }
}