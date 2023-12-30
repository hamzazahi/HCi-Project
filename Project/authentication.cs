using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BakeryManagementSystem
{
    public class Authentication
    {
        private string connectionString = @"Data Source=LAPTOP-T\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";



        public CustomerDetails GetCustomerDetailsById(int customerId)
        {
            CustomerDetails customerDetails = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT id, FullName, address_, phone FROM loginn WHERE id = @CustomerId", con))
            {
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customerDetails = new CustomerDetails
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        FullName = reader.GetString(reader.GetOrdinal("FullName")),
                        Address = reader.GetString(reader.GetOrdinal("address_")),
                        Phone = reader.GetDecimal(reader.GetOrdinal("phone"))
                    };
                }
            }
            // Exception handling should be added here

            return customerDetails;
        }

    }

    public class CustomerDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public decimal Phone { get; set; }
        // You can add other properties as needed
    }
}
