using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Halcyon.src;
using System.Data;

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

        public static void GetData(string tableName, string[] columns, out object[] data)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string columnsSelect = string.Join(",", columns);
                string sql = $"SELECT {columnsSelect} FROM {tableName}";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        data = new object[table.Columns.Count];
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            data[i] = table.Rows[i].ItemArray;
                        }
                    }
                }
            }
        }
        public static void FillListView(string tableName, List<string> columnNames, ListView listView)
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
                            listView.Columns.Add(columnName, -2, HorizontalAlignment.Left);
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
    }
}
