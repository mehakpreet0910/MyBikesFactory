using MyBikesFactory.Business;
using MyBikesFactory.Business.Enums;
using MyBikesFactory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBikesFactory.UI
{
    public partial class MainForm : Form
    {
        private List<Bike> listOfBikes = BikeXmlData.Load();
        private bool thereAreUnsavedChanges = false;
        private Form? previousForm = null;
        public MainForm()
        {
            InitializeComponent();
            RefreshDisplayList();
        }

        public MainForm(Form originForm) : this()
        {
            previousForm = originForm;
        }

        #region Support Methods

        private Bike? FindBikeBySerialNumber(int serialnumber)
        {
            Bike? bikeFound = null;
            foreach (var bike in listOfBikes)
            {
                if (bike.SerialNumber == serialnumber)
                {
                    bikeFound = bike; break;
                }
            }
            return bikeFound;
        }
        private Bike? FindBikeBySerialNumber2(int serialnumber)
        {
            foreach (var bike in listOfBikes)
            {
                if (bike.SerialNumber == serialnumber)
                    return bike;
            }
            return null;
        }
        private Bike? FindBikeBySerialNumber3(int serialnumber)
        {

                     
            return listOfBikes.FirstOrDefault(s => s.SerialNumber == serialnumber);
        }
        private void RefreshDisplayList()
        {
            lstBikes.Items.Clear();

            foreach (var bike in listOfBikes)
            {
                bool include = false;

                if (rbAll.Checked)
                    include = true;
                else if (rbMountain.Checked && bike is MountainBike)
                    include = true;
                else if (rbRoad.Checked && bike is RoadBike)
                    include |= true;
                if (include)
                {
                    lstBikes.Items.Add(bike.ToString());

                }

            }
        }

        private bool AllFieldsAreOk()
        {
            if (cbBikeType.Text == "")
            {
                MessageBox.Show("Please select a bike type");
                return false;
            }
            else if (txtSerialNumber.Text == "" || !Validator.ValidateSerialNumber(txtSerialNumber.Text))
            {
                MessageBox.Show("Serial Number is required and should contain numbers only");
                return false;
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Please inform a name");
                return false;
            }
            else if (txtModel.Text == "")
            {
                MessageBox.Show("Please inform a model");
                return false;
            }
            else if (!Validator.ValidateModel(txtModel.Text))
            {
                MessageBox.Show("Model should contain 5 characters (numbers or letters)");
                return false;
            }
            else if (cbColor.Text == "")
            {
                MessageBox.Show("Please select a color");
                return false;
            }
            else if (txtManufacturingYear.Text == "")
            {
                MessageBox.Show("Please inform a weight");
                return false;
            }
            else if (!Validator.ValidateManufacturingYear(txtManufacturingYear.Text))
            {
                MessageBox.Show("Manufacture Year should be a number  and contain only 4 ");
                return false;
            }
            else if (cbBikeType.Text == "Mountain" && cbSuspensionType.Text == "")
            {
                MessageBox.Show("Please select a suspension type");
                return false;
            }
            else if (cbBikeType.Text == "Road" && cbTireType.Text == "")
            {
                MessageBox.Show("Please select a tire type");
                return false;
            }
            return true;
        }

        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbBikeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBikeType.Text == "Mountain")
            {
                cbSuspensionType.Enabled = true;
                cbTireType.Enabled = false;
                cbSuspensionType.SelectedIndex = 0;
                cbTireType.SelectedIndex = -1;
            }

            else
            {
                cbSuspensionType.Enabled = false;
                cbTireType.Enabled = true;
                cbSuspensionType.SelectedIndex = -1;
                cbTireType.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BikeXmlData.Save(listOfBikes);

            MessageBox.Show("The list of bikes has been added");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AllFieldsAreOk())
                return;
            else if (!Validator.ValidateUniqueSerialNumber(txtSerialNumber.Text, listOfBikes))
            {
                MessageBox.Show("This serial number is already used");
                return;
            }

            Bike bikeToAdd;
            if (cbBikeType.Text == "Mountain")
            {
                ESuspensionType suspensionType;
                if (cbSuspensionType.Text == "Front")
                    suspensionType = ESuspensionType.Front;
                else if (cbSuspensionType.Text == "Rear")
                    suspensionType = ESuspensionType.Rear;
                else
                    suspensionType = ESuspensionType.Dual;
                bikeToAdd = new MountainBike(suspensionType);
            }
            else
            {
                ETireType tireType;
                if (cbTireType.Text == "Regular")
                    tireType = ETireType.Regular;
                else if (cbTireType.Text == "Commuter")
                    tireType = ETireType.Commuter;

                else
                    tireType = ETireType.Gravel;
                bikeToAdd = new RoadBike(tireType);
            }

            bikeToAdd.SerialNumber = Convert.ToInt32(txtSerialNumber.Text);
            bikeToAdd.Name = txtName.Text;
            bikeToAdd.Model = txtModel.Text;
            bikeToAdd.ManufacturingYear = Convert.ToInt32(txtManufacturingYear.Text);

            if (cbColor.Text == "Black")
                bikeToAdd.Color = EColor.Black;
            else if (cbColor.Text == "Blue")
                bikeToAdd.Color = EColor.Blue;
            else if (cbColor.Text == "Green")
                bikeToAdd.Color = EColor.Green;
            else
                bikeToAdd.Color = EColor.Red;
            bikeToAdd.Color = (EColor)Enum.Parse(typeof(EColor), cbColor.Text);

            listOfBikes.Add(bikeToAdd);

            cbBikeType.SelectedIndex = -1;
            txtSerialNumber.Text = "";
            txtName.Text = "";
            txtModel.Text = "";
            cbColor.SelectedIndex = -1;
            txtManufacturingYear.Text = "";
            cbSuspensionType.SelectedIndex = -1;
            cbTireType.SelectedIndex = -1;

            RefreshDisplayList();

            MessageBox.Show("The bike has been added");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to exit?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!AllFieldsAreOk())
                return;
            else if (txtSerialNumber.Text != txtOriginalSerialNumber.Text)
            {
                if (!Validator.ValidateUniqueSerialNumber(txtSerialNumber.Text, listOfBikes))
                {
                    MessageBox.Show("This serial number is already used");
                    return;
                }
            }



            var bikeToUpdate = FindBikeBySerialNumber(Convert.ToInt32(txtOriginalSerialNumber.Text));

            if (bikeToUpdate is MountainBike && cbBikeType.Text == "Road" ||
                bikeToUpdate is RoadBike && cbBikeType.Text == "Mountain")
            {
                MessageBox.Show("It is not possible to change the type.Alternatively," +
                    "you may remove and add this bike with a different type");
                return;
            }

            if (cbBikeType.Text == "Mountain")
            {
                if (cbSuspensionType.Text == "Front")
                    (bikeToUpdate as MountainBike).SuspensionType = ESuspensionType.Front;
                else if (cbSuspensionType.Text == "Rear")
                    (bikeToUpdate as MountainBike).SuspensionType = ESuspensionType.Rear;
                else
                    (bikeToUpdate as MountainBike).SuspensionType = ESuspensionType.Dual;
                

            }
            else
            {
                if (cbTireType.Text == "Regular")
                    (bikeToUpdate as RoadBike).TireType = ETireType.Regular;
                else if (cbTireType.Text == "Commuter")
                    (bikeToUpdate as RoadBike).TireType = ETireType.Commuter;
                else
                    (bikeToUpdate as RoadBike).TireType = ETireType.Gravel ;
                

            }

            bikeToUpdate.SerialNumber = Convert.ToInt32(txtSerialNumber.Text);
            bikeToUpdate.Name = txtName.Text;
            bikeToUpdate.Model = txtModel.Text;
            bikeToUpdate.ManufacturingYear = Convert.ToInt32(txtManufacturingYear.Text);

             if (cbColor.Text == "Black")
                bikeToUpdate.Color = EColor.Black;

            else if (cbColor.Text == "Blue")
                bikeToUpdate.Color = EColor.Blue;
            else if (cbColor.Text == "Green")
                bikeToUpdate.Color = EColor.Green;
            else
               bikeToUpdate.Color = EColor.Red;
            

            RefreshDisplayList();

            MessageBox.Show("The bike has been updated");
            return;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSerialNumber.Text == "" || !Validator.ValidateSerialNumber(txtSerialNumber.Text))
            {
                MessageBox.Show("Serial Number is required and should be numeric");
                return;
            }

            int serialnumber = Convert.ToInt32(txtSerialNumber.Text);
            var bikeFound = FindBikeBySerialNumber(serialnumber);

            if (bikeFound == null)
            {
                MessageBox.Show("Bike not found");
                return;
            }
            string message = bikeFound.ToString().Replace(",", Environment.NewLine);
            MessageBox.Show(message);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = lstBikes.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Please select a bike");
                return;
            }

            var result = MessageBox.Show("Do youn really want to remove?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            listOfBikes.RemoveAt(index);
            lstBikes.Items.RemoveAt(index);
        }

        private void lstBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBikes.SelectedIndex < 0)
                return;

            var bike = listOfBikes[lstBikes.SelectedIndex];
            if (bike is MountainBike)
            {
                cbBikeType.SelectedIndex = 0;
                var bikeAsMountain = (MountainBike)bike;
                cbSuspensionType.SelectedIndex = (int)bikeAsMountain.SuspensionType;
            }
            else
            {
                cbBikeType.SelectedIndex = 1;
                var bikeAsRoad = (RoadBike)bike;
                cbTireType.SelectedIndex = (int)bikeAsRoad.TireType;
            }

            txtSerialNumber.Text = bike.SerialNumber.ToString();
            txtOriginalSerialNumber.Text = txtSerialNumber.Text;
            txtName.Text = bike.Name;
            txtModel.Text = bike.Model;
            cbColor.SelectedIndex = (int)bike.Color;
            txtManufacturingYear.Text = bike.ManufacturingYear.ToString();
        }

        private void rbMountain_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDisplayList();
            lstBikes.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void rbRoad_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDisplayList();
            lstBikes.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message;
            MessageBoxIcon icon;
            if (thereAreUnsavedChanges)
            {
                message = "*** THERE ARE UNSAVED CHANGES!***\n\n" +
                                    "Do you really want to exit";
                icon = MessageBoxIcon.Warning;
            }

            else
            {
                message = "Do you really want to exit";
                icon = MessageBoxIcon.Information;
            }

            var result = MessageBox.Show(message,
                 "Confirmation",
                 MessageBoxButtons.YesNo,
                 icon);
            if (result == DialogResult.No)
                e.Cancel = true;

            if (previousForm != null)
                previousForm.Show();
        
    }
    }
}
