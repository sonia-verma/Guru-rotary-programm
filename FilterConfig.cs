//file FilterConfig.cs
// By default RegisterGlobalFilters having Error handling index structure
// filters.add(new HandleErrorAttribute(),2); ** here 2 is for error handing presedence
// limited only for 404 error, not work for other errors

using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Linq;
using System.Collections.Generic;

namespace ErrorHandeling
{
    public class FilterConfig
    {
    // RegisterGlobalFilters{Pre defined Function for Error handiling in Application** Specially use for handel error-404}
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute
                {
                    ExceptionType = typeof(System.Data.DataException),
                    View = "Error"
                },1
          );
            filters.Add(new HandleErrorAttribute(),2);
        }
    }
    
}
