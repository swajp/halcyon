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
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            List<object[]> results = new List<object[]>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // sestavení dotazu na získání dat z tabulky
                string columnsSelect = string.Join(",", columns);
                string sql = $"SELECT {columnsSelect} FROM {tableName}";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        data = new object[table.Columns.Count];
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            data[i] = table.Rows[0][i];
                        }
                    }
                }
            }
        }
    }
}
