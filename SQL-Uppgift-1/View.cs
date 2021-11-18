using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL_Uppgift_1
{
    class View
    {
        static DataTable SqlHelper(string sqlQuery)
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

        public static void UniqueCountries()  //FUNKAR
        {
           Box.Simple(new string[] { "These are all the unique countries in the database" });
           DataTable dta = SqlHelper("select count (distinct country) from People");

            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0]);
                }
            }
        }
        public static void UniqueUserAndPassword() //FUNKAR
        {
            bool unique = true;

            DataTable dtaUsername = SqlHelper("select username, count (*) from people group by username having count(*) > 1");
            DataTable dtaPassword = SqlHelper("select password, count (*) from people group by password having count(*) > 1");

            if (dtaUsername.Rows.Count == 0 && dtaPassword.Rows.Count == 0) unique = true;

            if (unique) Box.Simple(new string[] { "All usernames and passwords are unique" });
            if (!unique) Box.Simple(new string[] { "Not all usernames and passwords are unique" });
        }

        public static void Vikings() //FUNKAR
        {
            Box.Simple(new string[] { "All of these users live in the North and Scandinavia" });
            DataTable dta = SqlHelper("select username, country from People where country in ('sweden', 'norway', 'finland', 'denmark', 'iceland')");

            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0] + " " + person[1]);
                }
            }
        }

        public static void MostCommonCountry() //INTE
        {
            Box.Simple(new string[] { "This is the most common country" });
            DataTable dta = SqlHelper("select top 1 country from people group by country order by count(*) DESC");
            
            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0]);
                }
            }
        }

        public static void Top10L() //FUNKAR
        {
            Box.Simple(new string[] { "These ten users are the first users in the list to have L as the first letter of their last name" });

            DataTable dta = SqlHelper("Select top 10 first_name, last_name from People where last_name like 'L%'");
            
            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0] + " " + person[1]);
                }
            }

        }

        public static void StartingLetter() //FUNKAR
        {
            Box.Simple(new string[] { "These users has the same first letter for both their first and last names" });
            DataTable dta = SqlHelper("Select first_name, last_name from People where left(first_name, 1) = left(last_name, 1)");

            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0] + " " + person[1]);
                }
            }
        }
    }
}
