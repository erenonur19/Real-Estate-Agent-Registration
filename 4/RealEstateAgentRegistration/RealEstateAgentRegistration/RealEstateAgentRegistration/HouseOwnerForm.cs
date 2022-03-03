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
    public partial class HouseOwnerForm : Form
    {
        People people = new People();

        public HouseOwnerForm()
        {
            InitializeComponent();
        }

        //show the datagridview
        private void HouseOwner_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadDataGridviewOwners();
            showOwnersCount();
        }

        //take data from datagridview to textboxes
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          

            txtId.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }


        //insert a new house owner
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;


            people = new People(id, fname, lname, phone, email, address);

            if (verifyTextBoxes())
            {
                if (people.insertPeople("house_owner", people))
                {
                    MessageBox.Show("New Owner Added", "Add Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridviewOwners();
                    showOwnersCount();

                    //clear textboxes
                    txtId.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";

                }
                else
                {
                    MessageBox.Show("New Owner Not Added", "Add Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter THe Owner First, Last Name + The Phone Number", "Add Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //update
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;

            try
            {
                int id = Convert.ToInt32(txtId.Text);

                if (verifyTextBoxes())
                {
                    if (people.updatePeople("house_owner", new People(id, fname, lname, phone, email, address)))
                    {
                        MessageBox.Show("Owner Updated", "Edit Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridviewOwners();
                        showOwnersCount();
                    }
                    else
                    {
                        MessageBox.Show("Owner Not Updated", "Edit Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter THe Owner First, Last Name and  Phone Number", "Add Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {

                MessageBox.Show("Owner Id Error", "Edit Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);

                if (people.deletePeople("house_owner", id))
                {
                    MessageBox.Show("Owner Deleted", "Delete Owner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridviewOwners();
                    showOwnersCount();

                    //clear textboxes
                    txtId.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPhone.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";


                }
                else
                {
                    MessageBox.Show("Owner Not Deleted", "Delete Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Owner Id Error", "Delete Owner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //display the selected house owner data from datagridview to textbox
        public bool verifyTextBoxes()
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string phone = txtPhone.Text;

            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //fill the datagridview
        public void LoadDataGridviewOwners()
        {


            dataGridView1.DataSource = people.getAllPeople("house_owner");

        }

        public void showOwnersCount()
        {
            string Count = people.getAllPeople("house_owner").Rows.Count.ToString();
            if (Convert.ToInt32(Count) > 1)
            {
                lblCount.Text = Count + " Owners";
            }
            else
            {
                lblCount.Text = Count + " Owner";
            }
        }

        //show the details of selected owner's house
        private void btnShwDetails_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {// hangi kolona göre işlem yapacaksak onun index i ile karşılaştırıyoruz
                //MessageBox.Show("Ad: " + dataGridView1.CurrentRow.Cells[2].Value.ToString()
                //    + "\nSoyad: " + dataGridView1.CurrentRow.Cells[3].Value.ToString(), "Butondan Detay");


                try
                {
                    DetailsListForm detListform = new DetailsListForm();

                    int id = Convert.ToInt32(txtId.Text);

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `house` WHERE `owner_id`=@ownerId");
                    command.Parameters.Add("@ownerId", MySqlDbType.Int32).Value = id;

                    detListform.populateDataGridview(command);

                    detListform.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Please first select a row ");
                }



            }
        }

       
    }
}
