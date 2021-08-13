using SmartNameSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SmartNameSearch
{
    public interface ISmartNameSearch
    {
        IEnumerable<People> SearchNames(TypesOfSearchKeys SearchKeyword, string typeOfSearch);
        List<PeopleNames> AutoSearchPeoples(string keyword);
    }
}
