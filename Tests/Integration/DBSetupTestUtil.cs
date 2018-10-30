using AngularPhonebookApp.Models;
using AngularPhonebookApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Tests.Integration
{
    public class DBSetupTestUtil
    {
        private readonly string _connectionString;
        protected readonly List<object> Rows = new List<object>();

        public DBSetupTestUtil(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddRow(string ContactName, string Number, String SessionID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO tblPhoneBook (ContactName,Number, SessionID) VALUES (@ContactName,@Number,@SessionID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {                    
                    command.Parameters.AddWithValue("@ContactName", ContactName);
                    command.Parameters.AddWithValue("@Number", Number);
                    command.Parameters.AddWithValue("@SessionID", SessionID);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteAllData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM tblPhoneBook";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Contact> GetAllData()
        {
            List<Contact> lstcontact = new List<Contact>();
            string query = "SELECT * FROM tblPhoneBook";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Contact contact = new Contact();
                    contact.ID = Convert.ToInt32(rdr["Id"]);
                    contact.ContactName = rdr["ContactName"].ToString();
                    contact.Number = rdr["Number"].ToString();
                    lstcontact.Add(contact);
                }
                connection.Close();
            }
            return lstcontact;
        }
    }
}
