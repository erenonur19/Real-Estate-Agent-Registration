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
    public partial class DetailsListForm : Form
    {
        public DetailsListForm()
        {
            InitializeComponent();
        }

        private void DetailsListForm_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         public void populateDataGridview(MySqlCommand command)
         {
             dataGridView1.RowTemplate.Height = 40;

             //populate the datagridview
             Database dbfunc4 = new Database();

             dataGridView1.DataSource = dbfunc4.getData(command);

             //clear the selection from datagridview
             dataGridView1.ClearSelection();
         } 
    }
}
