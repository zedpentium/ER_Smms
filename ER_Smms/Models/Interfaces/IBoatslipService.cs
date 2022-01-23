using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IBoatslipService
    {
        string Create(CreateBoatslipViewModel viewModel, Pier selectedObj);

        BoatslipViewModel ReadAll();

        Boatslip FindBy(int id);

        string Update(Boatslip obj);

        bool Remove(int id);

    }
}
