using System;
using System.Data.SqlClient;

namespace TESTINGC
{
    internal class AMS
    {
        public SqlConnection sqlConnection;
        public string names1, provider, passwords;

        public void PrintMenu()
        {
            Console.WriteLine("Select one of the following: \n1. Insert to database \n2. Delete from database\n3. Update from database\n4. View database");
        }
        public void ConnectSql(string connectionSTRING)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionSTRING);
                sqlConnection.Open();
                Console.WriteLine("Connected Succesfully!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private void ChooseDataTo()
        {   
            Console.WriteLine("Enter your Username: ");
            names1 = Console.ReadLine();
                 
            Console.WriteLine("Enter your account provider: ");
            provider = Console.ReadLine();
        }
        
        public void insertToDatabase()
        {
            try
            { 
                string insertquerys;
                Console.WriteLine("Enter your account provider: ");
                provider = Console.ReadLine();
                Console.WriteLine("Enter your Username: ");
                names1 = Console.ReadLine();
                Console.WriteLine("Enter your Password: ");
                passwords = Console.ReadLine();
                insertquerys = "INSERT INTO employees(Providers,Username,passwords) VALUES('" + provider + "','" + names1 + "','" + passwords + "')";
                SqlCommand insertcommnad = new SqlCommand(insertquerys, sqlConnection);
                insertcommnad.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void deleteFromDatabase()
        {
            ChooseDataTo();
            try
            {
                string deleteQuerys = "DELETE FROM employees WHERE Providers ='"+provider+"' AND Username='"+names1+"'";
                SqlCommand deletecommand = new SqlCommand(deleteQuerys, sqlConnection);
                deletecommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void viewContent()
        {
            int counter = 1;
            string viewQuery = "SELECT * FROM employees";
            SqlCommand sqlsComm = new SqlCommand(viewQuery, sqlConnection);
            SqlDataReader sqlreader = sqlsComm.ExecuteReader();
            while (sqlreader.Read())
            {
                Console.WriteLine(+counter+". Platform: '" + sqlreader.GetString(0) + "' Username: '" + sqlreader.GetString(1) + "' Password: '" + sqlreader.GetString(2)+ "' ID: '"+sqlreader.GetValue(3).ToString()+"'");
                counter++;
            }
            sqlreader.Close();
        }
        public void updateContent()
        {
            Console.WriteLine("Choose which to update based on the ID: ");
            viewContent();
            int val= int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which parameter to update:\n 1. Platform/Provider\n 2. Username\n 3. Password");
            string val2 = Console.ReadLine();
            string updatequery="";
            if (val2 == "1")
            {
                    Console.WriteLine("Enter new Provider: ");
                    string prov = Console.ReadLine();
                    updatequery = "UPDATE employees SET Providers = '"+prov+"' WHERE AccountsID = " + val + "";
            }
            else if (val2 == "2")
            {
                    Console.WriteLine("Enter new UserName: ");
                    string usernameNew = Console.ReadLine();
                    updatequery = "UPDATE employees SET Username = '" + usernameNew + "' WHERE AccountsID = " + val + "";
            }

            else if (val2 == "3")
            {
                    Console.WriteLine("Enter new Password : ");
                    string passWord = Console.ReadLine();
                    updatequery = "UPDATE employees SET passwords = '" + passWord + "' WHERE AccountsID = " + val + "";
            }
            try
            {
                SqlCommand sqlupdate = new SqlCommand(updatequery, sqlConnection);
                sqlupdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }   
     
    }
}
