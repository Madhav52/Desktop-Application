using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindGrid();
            btnUpdate.Visible = false;
            dataGridView1.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {  

            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter your first name!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if(txtLastName.Text == "" || txtLastName.Text==null)
            {
                MessageBox.Show("Please enter your last name!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "" || txtAddress.Text==null)
            {
                MessageBox.Show("Please enter your address!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtContactNo.Text == "" || txtContactNo.Text==null)
            {
                MessageBox.Show("Please enter your valid Phone Number!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (gender.SelectedItem == null)
            {
                MessageBox.Show("Please select your Gender!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEmail.Text=="" || txtEmail.Text == null)
            {
                MessageBox.Show("Please enter your valid Email!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (enrolProgram.SelectedItem == null)
            {
                MessageBox.Show("Please select your enrolled program!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rBtnPending.Checked == false && rBtnPublished.Checked == false)
            {
                MessageBox.Show("Please select status!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Student obj = new Student();
                obj.firstName = txtFirstName.Text;
                obj.lastName = txtLastName.Text;
                obj.Address = txtAddress.Text;
                obj.Email = txtEmail.Text;
                obj.BirthDate = dob.Value;
                obj.ContactNo = txtContactNo.Text;
                obj.Gender = gender.SelectedItem.ToString();
                obj.RegisterDate = regDate.Value;
                obj.Courses = enrolProgram.SelectedItem.ToString();
                if (rBtnPending.Checked == true)
                {
                    obj.Status = rBtnPending.Text;
                }

                else if (rBtnPublished.Checked == true)
                {
                    obj.Status = rBtnPublished.Text;
                }
  
                obj.Add(obj);
                MessageBox.Show("Data is Sucessfully saved", "Information Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                BindGrid();
                Clear();

            }
        }
        private void BindGrid()
        {
            Student obj = new Student();
            List<Student> listStudents = obj.List();
            DataTable dt = Utility.ConvertToDataTable(listStudents);
            dataGridStudent.DataSource = dt;
            



        }
        private void Clear()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            dob.Value = DateTime.Today;
            txtContactNo.Text = "";
            gender.SelectedItem = null;
            regDate.Value = DateTime.Today;
            enrolProgram.SelectedItem = null;
            if (rBtnPending.Checked)
            {
                rBtnPending.Checked = false;
            }
            else
            {
                rBtnPublished.Checked = false;
            }

        }

        private void dataGridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Student obj = new Student();
            if (e.ColumnIndex == 0)
            {
                //get the value of clicked rows id column
                string value = dataGridStudent[2, e.RowIndex].Value.ToString();
                int id = 0;
                if (String.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Invalid Data");
                }
                else
                {
                    id = int.Parse(value);
                    Student s = obj.List().Where(X => X.Id == id).FirstOrDefault();
                    txtId.Text = s.Id.ToString();
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    obj.firstName = txtFirstName.Text;
                    obj.lastName = txtLastName.Text;
                    obj.Address = txtAddress.Text;
                    obj.Email = txtEmail.Text;
                    obj.BirthDate = dob.Value;
                    obj.ContactNo = txtContactNo.Text;
                    obj.Gender = gender.SelectedItem.ToString();
                    obj.RegisterDate = regDate.Value;
                    obj.Courses = enrolProgram.SelectedItem.ToString();
                    if (rBtnPending.Checked == true)
                    {
                        obj.Status = rBtnPending.Text;
                    }

                    else if (rBtnPublished.Checked == true)
                    {
                        obj.Status = rBtnPublished.Text;
                    }
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
            else if (e.ColumnIndex == 1)
            {
                string value = dataGridStudent[2, e.RowIndex].Value.ToString();
                obj.Delete(int.Parse(value));
                BindGrid();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            // obj.Id = int.Parse(txtId.Text);
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            obj.firstName = txtFirstName.Text;
            obj.lastName = txtLastName.Text;
            obj.Address = txtAddress.Text;
            obj.Email = txtEmail.Text;
            obj.BirthDate = dob.Value;
            obj.ContactNo = txtContactNo.Text;
            obj.Gender = gender.SelectedItem.ToString();
            obj.RegisterDate = regDate.Value;
            obj.Courses = enrolProgram.SelectedItem.ToString();
            if (rBtnPending.Checked == true)
            {
                obj.Status = rBtnPending.Text;
            }

            else if (rBtnPublished.Checked == true)
            {
                obj.Status = rBtnPublished.Text;
            }
            obj.Edit(obj);
            BindGrid();
            Clear();
            btnSave.Visible = true;
            MessageBox.Show("Data is Sucessfully Updated", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you really want to cancel?", "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            int rowIndex = dataGridStudent.CurrentCell.RowIndex;
            string message = "Do you really want to delete this Record?";
            string title = "Delete Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.OK)
            {
                //get the value of the clicked rows id column
                string value = dataGridStudent[0, rowIndex].Value.ToString();
                obj.Delete(int.Parse(value));
                BindGrid();
                MessageBox.Show("Record is Sucessfully Deleted", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Clear();

        }
        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridStudent.CurrentCell.RowIndex;
            if (dataGridStudent.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string firstName = dataGridStudent.SelectedRows[0].Cells[1].Value + string.Empty;
                string lastName = dataGridStudent.SelectedRows[0].Cells[2].Value + string.Empty;
                string Address = dataGridStudent.SelectedRows[0].Cells[3].Value + string.Empty;
                string Email = dataGridStudent.SelectedRows[0].Cells[4].Value + string.Empty;
                string ContactNo = dataGridStudent.SelectedRows[0].Cells[6].Value + string.Empty;
                string Gender = dataGridStudent.SelectedRows[0].Cells[7].Value + string.Empty;
                string Courses = dataGridStudent.SelectedRows[0].Cells[9].Value + string.Empty;
                string Status = dataGridStudent.SelectedRows[0].Cells[10].Value + string.Empty;

                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtAddress.Text = Address;
                txtEmail.Text = Email;
                txtContactNo.Text = ContactNo;
                gender.Text = Gender;
                enrolProgram.Text = Courses;
                if (rBtnPending.Text == Status)
                {
                    rBtnPending.Checked = true;
                }
                else if (rBtnPublished.Text == Status)
                {
                    rBtnPublished.Checked = true;
                }
                else
                {
                    MessageBox.Show("Status was not selected before");
                }
                btnSave.Visible = false;
                btnUpdate.Visible = true;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

           
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            form3.ShowDialog();
            

            

        }

        private void dataGridStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //new object of Student
            Student obj = new Student();

            //get input value of registered date
            DateTime registeredDate = dateTimePicker1.Value;

            //invoke the List method of Student class which return a List of Student
            List<Student> listStudents = obj.List();

            // invoke the FindWeek method which returns array containing week start and end date
            DateTime[] dateArray = obj.FindWeek(registeredDate);

            // invoke WeekStudent method which returns a list of student of a week
            List<Student> weeklyStudents = obj.WeeklyStudent(dateArray, listStudents);


            // group the list by course and create two columns i.e. course and count
            var result = weeklyStudents
                    .GroupBy(l => l.Courses)
                    .Select(cl => new
                    {
                        Courses = cl.First().Courses,
                        Count = cl.Count().ToString()
                    }).ToList();

            dataGridView1.Show();
            dataGridStudent.Hide();

            
            //convert the result to datatable and show in a datagrid view
            DataTable dt = Utility.ConvertToDataTable(result);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void regDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void enrolProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Name")
                {
                    Student obj = new Student();

                    //original list of student
                    List<Student> listStudents = obj.List();

                    //list after sorting
                    List<Student> lst = obj.Sort(listStudents, "Name");

                    //adding sorted list to datatable
                    DataTable dt = Utility.ConvertToDataTable(lst);
                    dataGridStudent.DataSource = dt;
                }
                else
                {
                    Student obj = new Student();

                    //original list of student
                    List<Student> listStudents = obj.List();

                    //list after sorting
                    List<Student> lst = obj.Sort(listStudents, "Registration Date");

                    //adding sorted list to datatable
                    DataTable dt = Utility.ConvertToDataTable(lst);
                    dataGridStudent.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Invalid Input! Please, select any value.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
