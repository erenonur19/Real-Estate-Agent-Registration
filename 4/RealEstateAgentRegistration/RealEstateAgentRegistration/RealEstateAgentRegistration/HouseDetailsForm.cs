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
    public partial class HouseDetailsForm : Form
    {
        Property property = new Property();
        public HouseDetailsForm()
        {
            InitializeComponent();
        }

        //fill the datagridview with house details
        private void HouseDetails_Load(object sender, EventArgs e)
        {
            LoadDataGridviewProperty();
        }


        //search propery by id
        private void btnHouseIdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //get the property id
                int id = Convert.ToInt32(txtHouseId.Text);

                //get the property data using id
                DataTable propertyData = property.getPropertyById(id);

                //display the property data
                txtOwnerId.Text = propertyData.Rows[0]["owner_id"].ToString();
                txtSize.Text = propertyData.Rows[0]["house_size"].ToString();
                txtPrice.Text = propertyData.Rows[0]["house_price"].ToString();
                txtAddress.Text = propertyData.Rows[0]["house_address"].ToString();
                txtComment.Text = propertyData.Rows[0]["house_comment"].ToString();
                cmbFloor.SelectedItem = propertyData.Rows[0]["house_floor"].ToString();
                cmbNumOfRooms.SelectedItem = propertyData.Rows[0]["room_no"].ToString();
                cmbRentSale.SelectedItem = propertyData.Rows[0]["type"].ToString();
            }
            catch 
            {
                if (txtHouseId.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter The House Id First", "House Id Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearAllFields();
                }
                else
                {
                    MessageBox.Show("This House Id Does Not Exists", "House Id Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearAllFields();
                }
               
            }

           
           
        }

        // open a new form to select the property owner
        private void btnSelectOwner_Click(object sender, EventArgs e)
        {

            OwnersListForm ownersF = new OwnersListForm();
            ownersF.ShowDialog();

            txtOwnerId.Text = ownersF.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        //insert new house properties
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                int size = Convert.ToInt32(txtSize.Text); // int size ?
                string price = txtPrice.Text;
                int owner = Convert.ToInt32(txtOwnerId.Text); //int owner ?
                string rentSale = cmbRentSale.Text.ToString();
                string numOfRooms = cmbNumOfRooms.Text.ToString();
                string floor = cmbFloor.Text.ToString();
                string address = txtAddress.Text;
                string comment = txtComment.Text;

               
                property = new Property(0, owner, rentSale, numOfRooms, floor, price, address, size, comment);

                if (verifyTextBoxes())
                {

                    if (property.insertHouse(property))
                    {

                        MessageBox.Show("New house added", "Add House", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridviewProperty();

                        //clear textboxes and comboboxes
                        clearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("New house not added", "Add House", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter The Required Fileds(Size-Address-Price-Owner)", "Add House", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Property Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        //upddate the selected property
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtHouseId.Text); //int houseid ?
                int size = Convert.ToInt32(txtSize.Text); // int size ?
                string price = txtPrice.Text;
                int owner = Convert.ToInt32(txtOwnerId.Text); //int ownerid ?
                string rentSale = cmbRentSale.Text.ToString();
                string numOfRooms = cmbNumOfRooms.Text.ToString();
                string floor = cmbFloor.Text.ToString();
                string address = txtAddress.Text;
                string comment = txtComment.Text;

               
                property = new Property(id, owner, rentSale, numOfRooms, floor, price, address, size, comment);

                if (verifyTextBoxes())
                {

                    if (property.updateHouse(property))
                    {

                        MessageBox.Show("House Detail(s) Updated", "Edit Detail(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridviewProperty();

                        //clear textboxes and comboboxes
                        clearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("House detail(s) Not Updated", "Edit Detail(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter The Required Fileds(Size-Address-Price-Owner)", "Edit Detail(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Property Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtHouseId.Text);

                if(MessageBox.Show("Are You Sure You Want To Delete This House ?","Delete House",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (property.deleteHouse(id))
                    {
                        MessageBox.Show("House Deleted", "Delete House", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGridviewProperty();

                        //clear textboxes and comboboxes
                        clearAllFields();

                    }
                    else
                    {
                        MessageBox.Show("House Not Deleted", "Delete House", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("House Id Error", "Delete House", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowImage_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you want to cancel? The information you have entered will be lost!";
            string title = "Congratulations!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        

        //create a func to verify if any of the required fields is empty
        public bool verifyTextBoxes()
        {
            string owner = txtOwnerId.Text.Trim();
            string size = txtSize.Text.Trim();
            string price = txtPrice.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (size.Equals("") || price.Equals("") || address.Equals("") || owner.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //fill the datagridview
        public void LoadDataGridviewProperty()
        {

            dataGridView1.DataSource = property.getAllProperty("house");

        }

        public void clearAllFields()
        {
            txtHouseId.Text = "";
            txtSize.Text = "";
            txtPrice.Text = "";
            txtOwnerId.Text = "";
            txtComment.Text = "";
            txtAddress.Text = "";
            cmbFloor.SelectedIndex = -1;
            cmbNumOfRooms.SelectedIndex = -1;
            cmbRentSale.SelectedIndex = -1;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
