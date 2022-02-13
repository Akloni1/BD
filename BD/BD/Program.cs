using System;
using System.Data;
using System.Data.SqlClient;

namespace BD
{
    class Program
    {
        static String connectionString = "Server=DESKTOP-JUI9V07;Database=MyDB;Trusted_connection=True";

        static void Main(string[] args)
        {
            CreateBD createBd = new CreateBD();
              createBd.CreateBd();
               createBd.CreateTableCust();
              createBd.CreateTableOrders();
              createBd.AddCust();
             createBd.AddOrders();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {

                string sqlCommand = "SELECT Customers.Name,Orders.CustomerId FROM Customers" +
                                    " LEFT JOIN Orders ON Customers.Id = Orders.CustomerId"+
                                   " WHERE Orders.CustomerId is null";
                 

                SqlCommand command = new SqlCommand(sqlCommand, connection);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine(reader[i] + "\t");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}