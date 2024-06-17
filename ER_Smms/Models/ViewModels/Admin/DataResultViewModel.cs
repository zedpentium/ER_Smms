using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Models.ViewModels.Admin
{

    public class DataResultViewModel<T>
    {
        /// <summary>
        /// Data items
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Pagination
        /// </summary>
        public Pagination Pagination { get; set; }
    }

}