using System;
using System.Data;
using System.Data.SqlClient;

namespace _18_8_23_Assign_6
{
    internal class Program
    {
        static SqlDataReader reader;
        static SqlConnection con = new SqlConnection("Server=DESKTOP-R52GF1S;Database=ProductInventoryDb;Trusted_Connection=true");
        static SqlCommand cmd;
        public static void ViewProducts()
        {
            cmd = new SqlCommand("Select * From ProductInventory", con);
            con.Open();
            reader = cmd.ExecuteReader();
            Console.WriteLine("ProductId\tProductName\tPrice\t   Quantity\t\tMfDate\t\t\t\tExpDate\t");
            while (reader.Read())
            {
                Console.WriteLine("    " + reader["ProductId"] + "            " + reader["ProductName"] + "         " + reader["Price"] + "            " + reader["Quantity"] + "              " + reader["MfDate"] + "              " + reader["ExpDate"]);
            }
        }
        public static void AddProduct()
        {
            cmd = new SqlCommand("Insert Into ProductInventory(ProductId,ProductName,Price,Quantity,MfDate,ExpDate) Values (@id,@name,@price,@quantity,@MFD,@ED)", con);
            con.Open();
            Console.WriteLine("Enter New Product Id");
            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter New Product Name");
            cmd.Parameters.AddWithValue("@name", Console.ReadLine());
            Console.WriteLine("Enter New Price");
            cmd.Parameters.AddWithValue("@price", decimal.Parse(Console.ReadLine()));
            Console.WriteLine("Enter New Quantity");
            cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter New Manufacture Date");
            cmd.Parameters.AddWithValue("@MFD", DateTime.Parse(Console.ReadLine()));
            Console.WriteLine("Enter New Expiration Date");
            cmd.Parameters.AddWithValue("@ED", DateTime.Parse(Console.ReadLine()));
            int nor = cmd.ExecuteNonQuery();
            if (nor >= 1)
                Console.WriteLine("1 Rows Affected");
        }
        public static void UpdateProduct()
        {
            cmd = new SqlCommand("Update ProductInventory Set Quantity=@quantity where ProductId=@id", con);
            con.Open();
            Console.WriteLine("Enter Id to Update");
            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter New Quantity");
            cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));
            int nor = cmd.ExecuteNonQuery();
            if (nor >= 1)
                Console.WriteLine("1 Rows has been Updated");
            else
                Console.WriteLine("No Such ID in the Table");
        }
        public static void RemoveProduct()
        {
            cmd = new SqlCommand("Delete From ProductInventory where ProductId=@id", con);
            con.Open();
            Console.WriteLine("Enter Product Id to Delete");
            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
            int nor = cmd.ExecuteNonQuery();
            if (nor >= 1)
                Console.WriteLine("1 Rows has been Deleted");
            else
                Console.WriteLine("No Such ID in the Table");
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Now Database is Connected");
            repeat:
                Console.WriteLine("Available Operation to Perform\n1. View Product Inverntory\n2. Add New Product\n3. Update Product Quantity\n4. Remove Product\n");
                Console.WriteLine("What You wanna do?");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            ViewProducts();
                            break;
                        }
                    case 2:
                        {
                            AddProduct();
                            break;
                        }
                    case 3:
                        {
                            UpdateProduct();
                            break;
                        }
                    case 4:
                        {
                            RemoveProduct();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You did a GRAVE MISTAKE entering WRONG NUMBER. Now You gotta START from the BEGINNING\n");
                            break;
                        }
                }
                Console.WriteLine("Wanna Try Again? \nIf Yes Type '1'");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                    goto repeat;
                else
                    Console.WriteLine("Good Bye!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
