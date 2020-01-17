namespace Coursework
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridStudentStat = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentStat)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridStudentStat
            // 
            this.dataGridStudentStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStudentStat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.TotalStudents});
            this.dataGridStudentStat.Location = new System.Drawing.Point(12, 12);
            this.dataGridStudentStat.Name = "dataGridStudentStat";
            this.dataGridStudentStat.Size = new System.Drawing.Size(416, 235);
            this.dataGridStudentStat.TabIndex = 0;
            // 
            // Course
            // 
            this.Course.HeaderText = "Courses";
            this.Course.Name = "Course";
            // 
            // TotalStudents
            // 
            this.TotalStudents.HeaderText = "Total Students";
            this.TotalStudents.Name = "TotalStudents";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 266);
            this.Controls.Add(this.dataGridStudentStat);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridStudentStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalStudents;
    }
}