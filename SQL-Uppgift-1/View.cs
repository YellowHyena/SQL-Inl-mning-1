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
        public static void UniqueCountries()
        {
            Box.Simple(new string[] { "These are all the unique countries in the database" });
           DataTable dta = SqlHelper("select count (distinct country) from People ");

            if (dta.Rows.Count > 0)
            {
                foreach (DataRow person in dta.Rows)
                {
                    Console.WriteLine(person[0]);
                }
            }
        }
        public static void UniqueUserAndPassword()
        {
            bool unique = true;

            DataTable dtaUsername = SqlHelper("select username, count (*) from people group by username having count(*) > 1");
            DataTable dtaPassword = SqlHelper("select password, count (*) from people group by password having count(*) > 1");

            if (dtaUsername.Rows.Count == 0 && dtaPassword.Rows.Count == 0) unique = true;

            if (unique) Box.Simple(new string[] { "All usernames and passwords are unique" });
            if (!unique) Box.Simple(new string[] { "Not all usernames and passwords are unique" });
        }

        public static void Vikings()
        {
            Box.Simple(new string[] { "All of these people lives in the north and Scandinavia" });

        }

        public static void MostCommonCountry()
        {
            Box.Simple(new string[] { "This is the most common country" });
        }

        public static void Top10L()
        {
            Box.Simple(new string[] { "These ten users are the first users in the list to have L as the first letter of their last name" });

            SqlHelper("Select Top 10 * from People where last_name like 'L%'");

        }

        public static void StartingLetter()
        {
            Box.Simple(new string[] { "These users have the same first letter for both their first and last names" });
        }
    }
}
