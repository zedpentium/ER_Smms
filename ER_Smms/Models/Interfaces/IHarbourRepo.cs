using ER_Smms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IHarbourRepo
    {
        string Create(Harbour obj);


        List<Harbour> ReadAll();


        Harbour Read(int id);


        string Update(Harbour obj);


        bool Delete(Harbour obj);
    }
}
