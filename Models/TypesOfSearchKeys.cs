using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartNameSearch.Models
{[BindProperties]
    public class TypesOfSearchKeys
    {
        [StringLength(25)]
        public string GlobalSearch { get; set; }
        [StringLength(25)]
        public string SearchFirstName { get; set; }
        [StringLength(25)]
        public string SearchMiddleName { get; set; }
        [StringLength(25)]
        public string SearchLastName { get; set; }

    }
}
