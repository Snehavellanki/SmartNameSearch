using SmartNameSearch.Data;
using SmartNameSearch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace SmartNameSearch
{
    public class SmartNameSearchFromDB : ISmartNameSearch
    {
        private readonly SmartNameSearchContext db;

        public SmartNameSearchFromDB(SmartNameSearchContext db)
        {
            this.db = db;
        }

        public List<PeopleNames> AutoSearchPeoples(string keyword)
        {
                var searchWordParam = new SqlParameter("searchWord", keyword);
                var names = db.PeopleNames.FromSqlRaw("Sp_People_Names @searchWord", searchWordParam).ToList();
                return names;
        }

      
        public IEnumerable<People> SearchNames(TypesOfSearchKeys SearchKeywords, string typeOfSearch)
        {
            try
            {
                    var searchWordParam = new SqlParameter("searchWord", SearchKeywords.GlobalSearch ?? (object)DBNull.Value);
                    var  searchWordFirstParam = new SqlParameter("searchWordFirst", SearchKeywords.SearchFirstName ?? (object)DBNull.Value);
                    var  searchWordMiddleParam = new SqlParameter("searchWordMiddle", SearchKeywords.SearchMiddleName ?? (object)DBNull.Value);
                   var  searchWordLastParam = new SqlParameter("searchWordLast", SearchKeywords.SearchLastName ?? (object)DBNull.Value);
               
              
                IQueryable<People> names = null; 
                
                switch (typeOfSearch)
                {
                    case "Contains":
                        names = GetDataFromProcContains(searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam); 
                        break;
                    case "StartsWith":
                        names = GetDataFromProcStartsWith(searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam);
                        break;
                    case "Equals":
                        names = GetDataFromProcEquals(searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam);
                        break;
                    default:
                        names = from people in db.People
                                select people;
                            break;
                }
                 return names;
            }
            catch
            {
                return null;
            }
        }

        private IQueryable<People> GetDataFromProcEquals(SqlParameter searchWordParam, SqlParameter searchWordFirstParam, SqlParameter searchWordMiddleParam, SqlParameter searchWordLastParam)
        {
            IQueryable<People> names = db.People.FromSqlRaw("SP_Search_Names_Equals @searchWord, @searchWordFirst, @searchWordMiddle, @searchWordLast", searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam);
            ;
            return names;
        }

        private IQueryable<People> GetDataFromProcStartsWith(SqlParameter searchWordParam, SqlParameter searchWordFirstParam, SqlParameter searchWordMiddleParam, SqlParameter searchWordLastParam)
        {
            IQueryable<People> names = db.People.FromSqlRaw("SP_Search_Names_StartsWith @searchWord, @searchWordFirst, @searchWordMiddle, @searchWordLast", searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam);
            ;
            return names;
        }

        private IQueryable<People> GetDataFromProcContains(SqlParameter searchWordParam, SqlParameter searchWordFirstParam, SqlParameter searchWordMiddleParam, SqlParameter searchWordLastParam)
        {
            IQueryable<People> names = db.People.FromSqlRaw("SP_Search_Names_Contains @searchWord, @searchWordFirst, @searchWordMiddle, @searchWordLast", searchWordParam, searchWordFirstParam, searchWordMiddleParam, searchWordLastParam);
            ;
            return names;
        }
    }
}
