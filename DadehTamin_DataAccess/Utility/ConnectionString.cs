using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadehTamin_DataAccess.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=.;Initial Catalog=DadehTamin;Integrated Security=true;";
        public static string CName
        {
            get => cName;
        }
    }
}
