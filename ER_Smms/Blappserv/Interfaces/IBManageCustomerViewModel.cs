using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;

namespace ER_Smms.Blappserv.Interfaces
{
    public interface IBManageCustomerViewModel
    {
        bool IsBusy { get; set; }
        //int ToDoItems { get; }
        //ToDoItem ToDoItem { get; set; }
        //List<ToDoItem> ToDoItemList { get; }

        event PropertyChangedEventHandler PropertyChanged;

        //void SaveToDoItem(ToDoItem todoitem);

        CustomerAllInfoDTO CustomerAllInfo { get; set; }

        IdentityAppUser Customer { get; set; }

        int SelectedBoatDataId { get; set; }
        int SelectedBoatslipId { get; set; }
        int SelectedWinterstoreSpotId { get; set; }
        //int SelectedBoatFormId { get; set; }

        //public bool AnyBoatSelected { get; set; }
        //public string Boatsliplabel { get; set; }
        //public string Pierlabel { get; set; }

        BoatDataDTO BoatDTO { get; set; }


        List<Boatslip> FreeBoatslips { get; set; }

        //List<WinterstoreSpot> FreeWinterstoreSpotsIn { get; set; }
        //List<WinterstoreSpot> FreeWinterstoreSpotsOut { get; set; }
        List<WinterstoreSpot> FreeWinterstoreSpots { get; set; }

        List<CustomerAllInfoDTO> CustomerAllInfoListView { get; set; }
    }
}
