using System;
using System.Data;
using System.Data.SqlClient;
//string connectionString = @"Server=\\.\pipe\MSSQL$SQLEXPRESS\sql\query;Database=lab7;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true";
class Program
{
    static string connectionString = @"Data Source=\\.\pipe\MSSQL$SQLEXPRESS\sql\query; Initial Catalog= lab7; Integrated Security =True";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. Delete a customer");
            Console.WriteLine("3. Update customer ");
            Console.WriteLine("4. Show all customers");
            Console.WriteLine("5. Show customer by ID");
            Console.WriteLine("--------------------------------------------");

            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    DeleteCustomer();
                    break;
                case 3:
                    UpdateCustomer();
                    break;
                case 4:
                    ShowAllCustomers();
                    break;
                case 5:
                    ShowCustomerByID();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string NAME = Console.ReadLine();

        Console.Write("Enter mobile number: ");
        string PHONENUMBER = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO CUSTOMERS (NAME, PHONENUMBER) VALUES (@NAME, @PHONENUMBER)";
            SqlCommand command = new SqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@NAME", NAME);
            command.Parameters.AddWithValue("@PHONENUMBER", PHONENUMBER);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Customer added successfully.");
            else
                Console.WriteLine("Failed.");
        }
    }

    static void DeleteCustomer()
    {
        Console.Write("Enter customer ID to delete: ");
        int ID = int.Parse(Console.ReadLine());


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteQuery = "DELETE FROM CUSTOMERS WHERE ID = @ID";
            SqlCommand command = new SqlCommand(deleteQuery, connection);
            command.Parameters.AddWithValue("@ID", ID);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Customer deleted successfully.");
            else
                Console.WriteLine("Customer with the specified ID was not found.");
        }
    }

    static void UpdateCustomer()
    {
        Console.Write("Enter customer ID to update: ");
        int ID = int.Parse(Console.ReadLine());


        Console.Write("Enter new customer name: ");
        string NAME = Console.ReadLine();

        Console.Write("Enter new mobile number: ");
        string PHONENUMBER = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateQuery = "UPDATE CUSTOMERS SET name = @newName, mobile_number = @newMobileNumber WHERE id = @customerId";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@NAME", NAME);
            command.Parameters.AddWithValue("@PHONENUMBER", PHONENUMBER);
            command.Parameters.AddWithValue("@ID", ID);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Customer information updated successfully.");
            else
                Console.WriteLine("Customer with the specified ID was not found.");
        }
    }



    static void ShowCustomerByID()
    {
        Console.Write("Enter customer ID to search: ");
        int ID = int.Parse(Console.ReadLine());


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM CUSTOMERS WHERE ID = @ID";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@ID", ID);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine();
                Console.WriteLine($" ID: {reader["ID"]}  Name: {reader["NAME"]}  Mobile Number: {reader["PHONENUMBER"]}");

            }
            else
            {
                Console.WriteLine("Customer with the specified ID was not found.");
            }
        }
    }
    static void ShowAllCustomers()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM CUSTOMERS";
            SqlCommand command = new SqlCommand(selectQuery, connection);

            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("CUSTOMERS List:");
            Console.WriteLine();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["ID"]}  Name: {reader["NAME"]} Mobile : {reader["PHONENUMBER"]}");

                Console.WriteLine();
            }
        }
    }
}

    //static void DisplayCustomers(SqlConnection connection)
    //{
    //    string query = "SELECT * FROM CUSTOMERS";

    //    using (SqlCommand command = new SqlCommand(query, connection))
    //    {
    //        using (SqlDataReader reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["NAME"]}, Mobile: {reader["PHONENUMBER"]}");
    //            }
    //        }
    //    }
    //}

    //static void AddCustomer(SqlConnection connection, string NAME, string PHONENUMBER)
    //{
    //    string query = "INSERT INTO CUSTOMERS (NAME, PHONENUMBER) VALUES (NAME, PHONENUMBER)";

    //    using (SqlCommand command = new SqlCommand(query, connection))
    //    {
    //        command.Parameters.AddWithValue("NAME", NAME);
    //        command.Parameters.AddWithValue("PHONENUMBER", PHONENUMBER);

    //        int rowsAffected = command.ExecuteNonQuery();

    //        if (rowsAffected > 0)
    //        {
    //            Console.WriteLine("New customer added successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Failed to add a new customer.");
    //        }
    //    }
    //}

    //static void DeleteCustomer(SqlConnection connection, int ID)
    //{
    //    string query = "DELETE FROM CUSTOMERS WHERE ID = 3";

    //    using (SqlCommand command = new SqlCommand(query, connection))
    //    {
    //        command.Parameters.AddWithValue("ID", ID);

    //        int rowsAffected = command.ExecuteNonQuery();

    //        if (rowsAffected > 0)
    //        {
    //            Console.WriteLine($"Customer with ID {ID} deleted successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"Customer with ID {ID} not found.");
    //        }
    //    }
    //}

