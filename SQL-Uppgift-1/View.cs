using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQL_Uppgift_1
{
    class View
    {
        static DataTable DataTableCreator(string sqlQuery) //Metoden tar emot en query och slänger tillbaka dta
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;";

            SqlConnection con = null;
            SqlCommand cmd = null;
            DataTable dta = null;
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(sqlQuery, con);
            var adapter = new SqlDataAdapter(cmd);

            dta = new DataTable();
            adapter.Fill(dta);

            con.Open();
            return dta;
        }

        static void QueryAnswer(DataTable dta) //Sorterar query svar baserat på längsta string och tar ut svaret för att användas i Box.Table för att skrivas ut.
        {
            var personList = new List<string>();

            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    for (int i = 0; i < person.ItemArray.Length; i++)
                    {
                        personList.Add(person.ItemArray.GetValue(i).ToString());
                    }
                }

                var sortedList = from c in personList orderby c.Length descending, c descending select c;  // fick hjälp härifrån https://dev.to/jjowensdev/csharp-sort-list-by-length-and-text-52oo

                string longestString = sortedList.First();
                int length = longestString.Length;

                Box.Table(dta, length);
            }
        }

        public static void UniqueCountries() 
        {
            Box.Simple(new string[] { "These are all the unique countries in the database" });

            //Jag har valt i följande metoder att skicka query utan parametrar då användaren inte har någon möjlighet att påverka dem. Det borde väll inte vara några problem?
            DataTable dta = DataTableCreator("select count (distinct country) from People");

            QueryAnswer(dta);
        }

        public static void UniqueUserAndPassword() //om dtaUsername och dtaPassword är tomma innebär det att alla användarnamn och lösenord är unika. Kom på att man egentligen kan göra select count (distinct) här också men if it ain't broke..
        {
            bool unique = true;

            DataTable dtaUsername = DataTableCreator("select username, count (*) from people group by username having count(*) > 1");
            DataTable dtaPassword = DataTableCreator("select password, count (*) from people group by password having count(*) > 1");

            if (dtaUsername.Rows.Count == 0 && dtaPassword.Rows.Count == 0) unique = true;

            if (unique) Box.Simple(new string[] { "All usernames and passwords are unique." });
            if (!unique) Box.Simple(new string[] { "Not all usernames and passwords are unique." });
        }

        public static void Vikings()
        {
            Box.Simple(new string[] { "All of these users live in the North and Scandinavia" });

            DataTable dta = DataTableCreator("select username, country from People where country in ('sweden', 'norway', 'finland', 'denmark', 'iceland')");

            QueryAnswer(dta);
        }

        public static void MostCommonCountry()
        {
            Box.Simple(new string[] { "This is the most common country" });

            DataTable dta = DataTableCreator("select top 1 country from people group by country order by count(*) DESC");

            QueryAnswer(dta);
        }

        public static void Top10L()
        {
            Box.Simple(new string[] { "These ten users are the first users in the list to have L as the first letter of their last name" });

            DataTable dta = DataTableCreator("Select top 10 first_name, last_name from People where last_name like 'L%'");

            QueryAnswer(dta);
        }

        public static void StartingLetter()
        {
            Box.Simple(new string[] { "These users has the same first letter for both their first and last names" });

            DataTable dta = DataTableCreator("Select first_name, last_name from People where left(first_name, 1) = left(last_name, 1)");

            QueryAnswer(dta);
        }
    }
}
