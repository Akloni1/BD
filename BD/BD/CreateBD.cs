using System;
using System.Data;
using System.Data.SqlClient;

namespace BD
{
    public class CreateBD
    {
        private static SqlConnection myConn;
        private static SqlConnection myConn1;
        private static String createBD;
        
        public CreateBD()
        {
            myConn = new SqlConnection("Server=DESKTOP-JUI9V07;Trusted_connection=True");
            myConn1 = new SqlConnection("Server=DESKTOP-JUI9V07;Database=MyDB;Trusted_connection=True");
            createBD = "CREATE DATABASE MyDB";
        }
        
        
       public void CreateBd()
       {
           SqlCommand myCommand = new SqlCommand(createBD, myConn);
           try
           {
               myConn.Open();
               myCommand.ExecuteNonQuery();
           }

           catch (System.Exception ex)
           {
              
               Console.WriteLine("Error" + ex.Message);
           }
           finally
           {
               if (myConn.State == ConnectionState.Open)
               {
                   myConn.Close();
               }
           }
       }



       public void CreateTableCust()
       {
           SqlCommand command = new SqlCommand();
           command.CommandText = "CREATE TABLE Customers (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(100) NOT NULL)";
           command.Connection = myConn1;
           try
           {
               myConn1.Open();
               command.ExecuteNonQuery();
           }
           catch (System.Exception ex)
           {
               Console.WriteLine("Error" + ex.Message);
           }
           finally
           {
               if (myConn1.State == ConnectionState.Open)
               {
                   myConn1.Close();
               }
           }
       }
       
       
       public void CreateTableOrders()
       {
           SqlCommand command = new SqlCommand();
           command.CommandText = "CREATE TABLE Orders (Id INT PRIMARY KEY IDENTITY, CustomerId INT NOT NULL)";
           command.Connection = myConn1;
           try
           {
               myConn1.Open();
               command.ExecuteNonQuery();
           }
           catch (System.Exception ex)
           {
               Console.WriteLine("Error" + ex.Message);
           }
           finally
           {
               if (myConn1.State == ConnectionState.Open)
               {
                   myConn1.Close();
               }
           }
       }

       public void AddCust()
       {
           string sqlExpression = "INSERT INTO Customers (Name) VALUES ('Max'), ('Pavel'), ('Ivan'), ('Leonid')";
           SqlCommand command = new SqlCommand(sqlExpression, myConn1);
           try
           {
               myConn1.Open();
               command.ExecuteNonQuery();
           }
           catch (System.Exception ex)
           {
               Console.WriteLine("Error" + ex.Message);
           }
           finally
           {
               if (myConn1.State == ConnectionState.Open)
               {
                   myConn1.Close();
               }
           }
       }

       
       
       public void AddOrders()
       {
           string sqlExpression = "INSERT INTO Orders (CustomerId) VALUES (2), (4)";
           SqlCommand command = new SqlCommand(sqlExpression, myConn1);
           try
           {
               myConn1.Open();
               command.ExecuteNonQuery();
           }
           catch (System.Exception ex)
           {
               Console.WriteLine("Error" + ex.Message);
           }
           finally
           {
               if (myConn1.State == ConnectionState.Open)
               {
                   myConn1.Close();
               }
           }
       }
    }
    }
