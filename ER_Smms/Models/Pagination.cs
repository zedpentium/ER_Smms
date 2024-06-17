using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ER_Smms.Models
{
    public class Pagination
    {
        /// <summary>
        /// Total count of items
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Count of items at the page
        /// </summary>
        public int PageSize { get; set; } = 5;

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Sorted by field name
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Is this an ascending sort?
        /// </summary>
        public bool IsSortAscending { get; set; }

        /// <summary>
        /// Information about what page should be requested
        /// </summary>
        public RouteInfo RouteInfo { get; set; }
    }

}