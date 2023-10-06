using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mangers
{
    public interface IManger<T>where T : BaseModel
    {
        IEnumerable<T>GetAll();
        T GetById(int id);
        void Add(T Item);
        void Remove(T Item);
        void Update(T Item);

    }
}
