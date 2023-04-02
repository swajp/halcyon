using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Halcyon.src;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace Halcyon
{
    public static class SqlRepository
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Halcyon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public enum Roles
        {
            USER = 0,
            ADMIN = 1,
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User((int)reader["Id"]
                                             , reader["Username"].ToString()
                                             , (byte[])reader["PasswordHash"]
                                             , (byte[])reader["PasswordSalt"]
                                             , (int)reader["RoleId"]);

                            //user.Roles = GetRoles(user);
                            users.Add(user);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return users;
        }

        public static List<User> GetUsers(string searchString)
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Username LIKE @Search";
                    cmd.Parameters.AddWithValue("Search", "%" + searchString + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User((int)reader["Id"]
                                             , reader["Username"].ToString()
                                             , (byte[])reader["PasswordHash"]
                                             , (byte[])reader["PasswordSalt"]
                                             , (int)reader["RoleId"]);
                            //user.Roles = GetRoles(user);
                            users.Add(user);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return users;
        }

        public static User? GetUser(string username)
        {
            User? user = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "select * from Users where Username=@Username";
                    cmd.Parameters.AddWithValue("Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User((int)reader["Id"],reader["Username"].ToString(), (byte[])reader["PasswordHash"], (byte[])reader["PasswordSalt"], (int)reader["RoleId"]);
                            //user.Roles = GetRoles(user);
                        }
                    }
                }
                sqlConnection.Close();
            }
            return user;
        }

        public static void CreateUser(string username,string password)
        {
            byte[] salt, hash;

            HMACSHA512 hmac = new HMACSHA512();

            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            salt = hmac.Key;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Users (Username, PasswordHash, PasswordSalt, RoleId) VALUES (@username, @hash, @salt, @roleId)";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("hash", hash);
                    cmd.Parameters.AddWithValue("salt", salt);
                    cmd.Parameters.AddWithValue("roleId", Roles.USER);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public static void GetData(string tableName, List<string> columnNames, ListView listView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string query = "SELECT " + string.Join(", ", columnNames.ToArray()) + " FROM " + tableName;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        listView.Items.Clear();
                        listView.Columns.Clear();

                        foreach (string columnName in columnNames)
                        {
                            string neco = Regex.Replace(columnName, "(\\B[A-Z])", " $1");
                            listView.Columns.Add(neco, -2, HorizontalAlignment.Left);
                        }

                        while (reader.Read())
                        {
                            string[] row = new string[columnNames.Count];
                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                row[i] = reader[columnNames[i]].ToString();
                            }
                            ListViewItem item = new ListViewItem(row);
                            listView.Items.Add(item);
                        }
                    }
                    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }
        public static void ExportListViewToCsv(ListView listView, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    sw.Write(listView.Columns[i].Text);
                    if (i < listView.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();

                foreach (ListViewItem item in listView.Items)
                {
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        sw.Write(item.SubItems[i].Text);
                        if (i < item.SubItems.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
        public static void DeleteRecord(string tableName,string columnName,string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = $"DELETE FROM {tableName} WHERE {columnName}={id}";
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public static void AddRecord(string selectedEdit, List<string> data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (selectedEdit == "Users")
                {
                    byte[] salt, hash;

                    HMACSHA512 hmac = new HMACSHA512();

                    hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data[1]));
                    salt = hmac.Key;

                    string query = "INSERT INTO Users (Username, PasswordHash, PasswordSalt, RoleId) VALUES (@value1, @hash, @salt, @value2)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);
                        command.Parameters.AddWithValue("@value2", data[2]);
                        command.Parameters.AddWithValue("hash", hash);
                        command.Parameters.AddWithValue("salt", salt);
                        command.ExecuteNonQuery();
                    }
                }
                if (selectedEdit == "Works")
                {
                    string query = "INSERT INTO Works (Name, Description) VALUES (@value1, @value2)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);
                        command.Parameters.AddWithValue("@value2", data[1]);
                        command.ExecuteNonQuery();
                    }
                }
                else if (selectedEdit == "Employees")
                {
                    string query = "INSERT INTO Employees (Job, FirstName, LastName, BirthDate, Email, PhoneNumber) VALUES (@value1, @value2, @value3, @value4, @value5, @value6)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);
                        command.Parameters.AddWithValue("@value2", data[1]);
                        command.Parameters.AddWithValue("@value3", data[2]);
                        command.Parameters.AddWithValue("@value4", Convert.ToDateTime(data[3]));
                        command.Parameters.AddWithValue("@value5", data[4]);
                        command.Parameters.AddWithValue("@value6", data[5]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public static void EditRecord(string selectedEdit, List<string> data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (selectedEdit == "Users")
                {
                    string query = "UPDATE Users SET Username=@value2, RoleId=@value3 WHERE Id=@value1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);
                        command.Parameters.AddWithValue("@value2", data[1]);
                        if (data[2] == "1")
                        {
                            command.Parameters.AddWithValue("@value3", 1);
                        }
                        else if (data[2] == "0")
                        {
                            command.Parameters.AddWithValue("@value3", 0);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                else if (selectedEdit == "Employees")
                {
                    string query = "UPDATE Employees SET Job=@value2, FirstName=@value3, LastName=@value4, BirthDate=@value5, Email=@value6, PhoneNumber=@value7 WHERE EmployeeId=@value1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);//id
                        command.Parameters.AddWithValue("@value2", data[1]);//job
                        command.Parameters.AddWithValue("@value3", data[2]);//first
                        command.Parameters.AddWithValue("@value4", data[3]);//last
                        command.Parameters.AddWithValue("@value5", Convert.ToDateTime(data[4]));//brith
                        command.Parameters.AddWithValue("@value6", data[5]);//email
                        command.Parameters.AddWithValue("@value7", data[6]);//phonen
                        command.ExecuteNonQuery();
                    }
                }
                else if (selectedEdit == "Works")
                {
                    string query = "UPDATE Works SET Name=@value2, Description=@value3  WHERE WorkId=@value1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value1", data[0]);
                        command.Parameters.AddWithValue("@value2", data[1]);
                        command.Parameters.AddWithValue("@value3", data[2]);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
