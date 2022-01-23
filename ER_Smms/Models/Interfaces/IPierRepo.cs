using ER_Smms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IPierRepo
    {
        string Create(Pier obj, Harbour selectedobj);


        List<Pier> ReadAll();


        Pier Read(int id);


        string Update(Pier obj);


        bool Delete(Pier obj);
    }
}
