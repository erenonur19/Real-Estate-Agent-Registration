using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgentRegistration
{
    class Database
    {

        dbConnection connection = new dbConnection();

        //insert
        public Boolean ExecQuery(MySqlCommand command)
        {
            command.Connection = connection.getConnection;

            //opened connection here
            connection.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                connection.closeConnection();
                return true;
            }
            else
            {
                connection.closeConnection();
                return true;
            }
        }

        //update

        //delete

        //get data        
        public DataTable getData(MySqlCommand command)
        {
            command.Connection = connection.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);
            
            return table;
        }
    }
}
