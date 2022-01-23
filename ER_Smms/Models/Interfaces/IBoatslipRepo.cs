using ER_Smms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatslipRepo
    {
        string Create(Boatslip obj, Pier selectedObj);

        List<Boatslip> ReadAll();

        Boatslip Read(int id);

        string Update(Boatslip obj);

        bool Delete(Boatslip obj);
    }
}
