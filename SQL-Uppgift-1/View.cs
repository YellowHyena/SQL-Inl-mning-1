using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Uppgift_1
{
    class View
    {
        public static void UniqueCountries()
        {
            Box.Simple(new string[] { "These are all the unique countries in the database" });

            var db = new SqlDatabase();
            db.DatabaseName = "People";

            var allParameters = new ParamData[2];
            allParameters[0] = new ParamData { Name = "@fname", Data = "Clark" };
            allParameters[1] = new ParamData { Name = "@lname", Data = "Kent" };

            var dt = db.GetDataTable("Select country from MOCK_DATA", null);
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item[0]+" "+item[1]);
            }
        }
    }
}
