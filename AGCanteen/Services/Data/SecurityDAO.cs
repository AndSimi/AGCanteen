using AGCanteen.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AGCanteen.Services.Data
{
    public class SecurityDAO
    {
        //Connection to database
        //String connectionString = "\"Data Source = DESKTOP - AVMV162; Initial Catalog = CanteenDB; Integrated Security = True\"";
        //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-AVMV162;Initial Catalog=CanteenDB;Integrated Security=True");

        internal bool FindUserId(UserModel user)
        {
            bool success = false;

            string query = "Select * from dbo.Employee Where EmpId = @Id";

            //Creating a database inside a using block
            //This ensures all resources are closed properly when query ends 
            //Change the 
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-AVMV162;Initial Catalog=CanteenDB;Integrated Security=True"))
            {
                //Creating command and parameter objects
                SqlCommand command = new SqlCommand(query, connection);

                //Setting @Id to be equal to user.Id
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = user.Id;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();


                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }


            return success;
        }
    }
}