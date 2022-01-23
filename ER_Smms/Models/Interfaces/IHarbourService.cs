using ER_Smms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ER_Smms.Models.Interfaces
{
    public interface IHarbourService
    {
        string Create(CreateHarbourViewModel viewModel);

        HarbourViewModel ReadAll();

        //HarbourViewModel FindBy(HarbourViewModel findbymodel);

        Harbour FindBy(int id);

        string Update(Harbour obj);

        bool Remove(int id);

    }
}
