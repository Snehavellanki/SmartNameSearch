using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SmartNameSearch.Data;
using SmartNameSearch.Models;

namespace SmartNameSearch.Pages.NamesDB
{
    public class NameSearchModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ISmartNameSearch names;
        public NameSearchModel(IConfiguration config, ISmartNameSearch names)
        {
            this.config = config;
            this.names = names;
        }

        [BindProperty]
        public TypesOfSearchKeys SearchWords { get; set; }
        
        public string typeofSearch { get; set; } = "Contains";
        public string[] typeofSearches = new string[] { "Contains" ,"StartsWith", "Equals"};
        public IEnumerable<People> Peoples { get; set; }
        public void OnGet(TypesOfSearchKeys SearchWords, string typeofSearch)
        { 
            if (ModelState.IsValid)
            {
                Peoples = names.SearchNames(SearchWords, typeofSearch);
            }
            else
            {
                Peoples = new List<People>();
            }
        }

        

    }
}
