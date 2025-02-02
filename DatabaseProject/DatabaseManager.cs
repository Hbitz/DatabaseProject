using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject
{
    internal class DatabaseManager<T> where T: class
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        public DatabaseManager(string tableName, string connectionString)
        {
            _tableName = tableName;
            _connectionString = connectionString;
        }

        public List<T> GetAll()
        {
            var results = new List<T>();
            string query = $"SELECT * FROM {_tableName}";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    // Skriv ut alla kolumnnamn för att se vad som returneras
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"Column {i}: {reader.GetName(i)}");
                    }

                    while (reader.Read())
                    {
                        var obj = Activator.CreateInstance<T>(); // huh?
                        foreach (var prop in typeof(T).GetProperties()) //and this whole section
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                            {
                                prop.SetValue(obj, reader[prop.Name]);
                            }
                        }
                        results.Add(obj);
                    }
                }
            }

            return results;
        }

        public void Add(T entity)
        {
            var properties = typeof(T).GetProperties();
            var columnNames = string.Join(", ", properties.Select(p => p.Name));
            var parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            string query = $"INSERT INTO {_tableName} ({columnNames}) VALUES ({parameterNames})";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var prop in properties)
                    {
                        command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(int id, T entity)
        {
            var properties = typeof(T).GetProperties();
            var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
            string query = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var prop in properties)
                    {
                        command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = $"DELETE FROM {_tableName} WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        


        public void CreateTest(T entity)
        {
            //Todo
        }

        public void ReadTest()
        {
            //todo
        }
        
        public void UpdateTest(int id, T entity)
        {
            //todo
        }

        public void DeleteTest(int id)
        {
            //todo
        }
    }
}
