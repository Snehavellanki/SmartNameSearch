using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNameSearch.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartNameSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoCompleteApiController : ControllerBase
    {
        private readonly ISmartNameSearch smartNameSearch;

        public AutoCompleteApiController(ISmartNameSearch smartNameSearch)
        {
            this.smartNameSearch = smartNameSearch;
        }

        [Produces("application/json")]
        [HttpGet("autocompleteGlobal")]
        public IEnumerable<PeopleNames> AutoComplete()
        {
            try
            {
                string searchKeyword = HttpContext.Request.Query["term"].ToString();
                var peopleNames = smartNameSearch.AutoSearchPeoples(searchKeyword);
                return peopleNames;
            }
            catch
            {
                return Enumerable.Empty<PeopleNames>();
            }
        }

    }
}
