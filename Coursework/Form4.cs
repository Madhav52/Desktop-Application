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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

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
                dataGridStudentStat.DataSource = dt;
                


            }
        }
    }
}
