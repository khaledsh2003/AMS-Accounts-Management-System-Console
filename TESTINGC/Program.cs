using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;





namespace TESTINGC
{
    class Program
    {
        static void Main(string[] args)
        {
         
            AMS sql1 = new AMS();
            sql1.ConnectSql(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            char GoAhead = 'y';
            while (GoAhead=='y')
            {
                sql1.PrintMenu();
                int choicE = int.Parse(Console.ReadLine());
                switch (choicE)
                {
                    case 1:
                        sql1.insertToDatabase();
                        break;
                    case 2:
                        sql1.deleteFromDatabase();
                        break;
                    case 3:
                        sql1.updateContent();
                        break;
                    case 4:
                        sql1.viewContent();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine("Do you want to do another operation? (y=yes,anycharacter=no)");
                GoAhead=char.Parse(Console.ReadLine());

            }
            Console.ReadLine();
        }
    }
}
