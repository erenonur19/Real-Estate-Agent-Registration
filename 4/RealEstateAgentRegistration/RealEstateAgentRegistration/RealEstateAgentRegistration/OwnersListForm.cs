using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateAgentRegistration
{
    public partial class OwnersListForm : Form
    {
        public OwnersListForm()
        {
            InitializeComponent();
        }

         private void OwnersListForm_Load(object sender, EventArgs e)
        {
            //populate the datagridview
            Database dbfunc3 = new Database();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `first_name`, `last_name` FROM `house_owner`");
            dataGridView1.DataSource = dbfunc3.getData(command);

            //clear the selection from datagridview
            dataGridView1.ClearSelection();
            
        }
        
        //close this from with double click
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
