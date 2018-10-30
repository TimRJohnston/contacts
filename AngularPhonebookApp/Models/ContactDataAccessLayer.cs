using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPhonebookApp.Models
{
    public class ContactDataAccessLayer
    {
        string connectionString = @"Server=localhost\SQLEXPRESS01;Database=TestDB;Trusted_Connection=True;";
        //View all contacts
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                List<Contact> lstcontact = new List<Contact>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllContacts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Contact contact = new Contact();
                        contact.ID = Convert.ToInt32(rdr["Id"]);
                        contact.Name = rdr["Name"].ToString();
                        contact.Number = rdr["Number"].ToString();                        
                        lstcontact.Add(contact);
                    }
                    con.Close();
                }
                return lstcontact;
            }
            catch
            {
                throw;
            }
        }
        //Add contact
        public int AddContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", contact.Name);
                    cmd.Parameters.AddWithValue("@Number", contact.Number);                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Update contact
        public int UpdateContact(Contact contact)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", contact.ID);
                    cmd.Parameters.AddWithValue("@Name", contact.Name);
                    cmd.Parameters.AddWithValue("@Number", contact.Number);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get single contact
        public Contact GetContactData(int id)
        {
            try
            {
                Contact contact = new Contact();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblPhoneBook WHERE Id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        contact.ID = Convert.ToInt32(rdr["Id"]);
                        contact.Name = rdr["Name"].ToString();
                        contact.Number = rdr["Number"].ToString();                        
                    }
                }
                return contact;
            }
            catch
            {
                throw;
            }
        }
        //Delete a contact
        public int DeleteContact(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
