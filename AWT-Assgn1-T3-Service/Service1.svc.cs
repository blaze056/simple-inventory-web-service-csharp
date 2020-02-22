using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AWT_Assgn1_T3_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string HelloWorld(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        static MySqlConnection getConnection()
        {
           string myConnectionString = "Database=pns5;DataSource = mysql.mcscw3.le.ac.uk; User Id = pns5; Password = quaiGh4e";
           MySqlConnection connection = new MySqlConnection(myConnectionString);
           return connection;
         }

        public string SearchCommodity(string value)  // Method to search the db by typeno or feature (name).
        {
            string Message = "", Keyword = value, Keyword2 = "", queryString = "";
            bool gotfeaturename = false;
            MySqlConnection connection = getConnection();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM featuretable WHERE feature LIKE" + "'" + Keyword + "'", connection);
            MySqlDataReader msdr = cmd.ExecuteReader();
            while (msdr.Read())
            {
                Keyword2 = msdr.GetValue(0).ToString();
                if (msdr.GetValue(2).ToString() == Keyword)
                {
                    gotfeaturename = true;
                    connection.Close();
                }
                break;
            }

            MySqlConnection connection2 = getConnection();
            connection2.Open();
            if (gotfeaturename == true)
            {
                queryString = "SELECT * FROM commodityinfotable WHERE typeno LIKE" + "'" + Keyword2 + "'";
            }
            else
            {
                queryString = "SELECT * FROM commodityinfotable WHERE typeno LIKE" + "'" + Keyword + "'";
            }

            MySqlCommand cmd2 = new MySqlCommand(queryString, connection2);
            MySqlDataReader msdr2 = cmd2.ExecuteReader();
            while (msdr2.Read())
            {
                {
                    Message = Message + msdr2.GetValue(0) + " - " + msdr2.GetValue(1) + " - " + msdr2.GetValue(2) + " - " + msdr2.GetValue(3) + " - " + msdr2.GetValue(4) + " - " + msdr2.GetValue(5) + " - " + msdr2.GetValue(6) + " - " + msdr2.GetValue(7) + "    ";
                }
            }
            connection2.Close();
            return Message;
        }


        public string AddCommodity(CommDetails CommInfo)  // Method to add a commodity into the database
        {
            string Message;
            MySqlConnection connection = getConnection();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO commodityinfotable VALUES (@Id,@Name,@Typeno,@Type,@Price,@Brand,@Size,@Stock)", connection);

            cmd.Parameters.AddWithValue("@Id", CommInfo.Id);
            cmd.Parameters.AddWithValue("@Name", CommInfo.Name);
            cmd.Parameters.AddWithValue("@Typeno", CommInfo.Typeno);
            cmd.Parameters.AddWithValue("@Type", CommInfo.Type);
            cmd.Parameters.AddWithValue("@Price", CommInfo.Price);
            cmd.Parameters.AddWithValue("@Brand", CommInfo.Brand);
            cmd.Parameters.AddWithValue("@Size", CommInfo.Size);
            cmd.Parameters.AddWithValue("@Stock", CommInfo.Stock);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = CommInfo.Name + " Details inserted successfully";
            }
            else
            {
                Message = CommInfo.Name + " Details not inserted successfully";
            }
            
            connection.Close();
            return Message;
        }

        public string ListAllLaptops()  // Method to list all laptops from the database
        {
            string querystring, Message = "";
            MySqlConnection connection = getConnection();
            connection.Open();
            querystring = "SELECT * FROM commodityinfotable WHERE type = 'laptop'";
            MySqlCommand cmd = new MySqlCommand(querystring, connection);

            MySqlDataReader msdr = cmd.ExecuteReader();
            while (msdr.Read())
            {
                Message = Message + msdr.GetValue(0) + " - " + msdr.GetValue(1) + " - " + msdr.GetValue(2) + " - " + msdr.GetValue(3) + " - " + msdr.GetValue(4) + " - " + msdr.GetValue(5) + " - " + msdr.GetValue(6) + " - " + msdr.GetValue(7) + "    ";
            }

            connection.Close();
            return Message;
        }

        public string AddNewFeature(string Typeno, string Featureno, string Feature)  // Method to add a new feature to a commodity type
        {
            string Message;
            MySqlConnection connection = getConnection();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO featuretable VALUES (@Typeno,@Featureno,@Feature)", connection);

            cmd.Parameters.AddWithValue("@Typeno", Typeno);
            cmd.Parameters.AddWithValue("@Featureno", Featureno);
            cmd.Parameters.AddWithValue("@Feature", Feature);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "New feature for commodity type with typeno" + Typeno +  "inserted successfully!";
            }
            else
            {
                Message = Typeno + " Details not inserted successfully";
            }

            connection.Close();
            return Message;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
