using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IPierService
    {
        string Create(CreatePierViewModel viewModel, Harbour selectedObj);

        PierViewModel ReadAll();

        //PierViewModel FindBy(PierViewModel findbymodel);

        Pier FindBy(int id);

        string Update(Pier obj);

        bool Remove(int id);

    }
}
