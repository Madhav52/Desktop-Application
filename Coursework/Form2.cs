using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            BindGrid();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void BindGrid()
        {
            Student obj = new Student();
            List<Student> listStudents = obj.List();
            Bindchart(listStudents);



        }
        private void Bindchart(List<Student> lst)
        {
            if (lst != null)
            {
                var result = lst
                    .GroupBy(l => l.Courses)
                    .Select(cl => new
                    {
                        Courses = cl.First().Courses,
                        Count = cl.Count().ToString()
                    }).ToList();
                DataTable dt = Utility.ConvertToDataTable(result);
                chart1.DataSource = dt;
                chart1.Name = "Courses";
                chart1.Series["Series1"].XValueMember = "Courses";
                chart1.Series["Series1"].YValueMembers = "Count";
                this.chart1.Titles.Remove(this.chart1.Titles.FirstOrDefault());
                this.chart1.Titles.Add("Weekly Enrollment Chart");
                chart1.Series["Series1"].Enabled = true;
                chart1.Series["Series1"].IsValueShownAsLabel = true;
                

            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
