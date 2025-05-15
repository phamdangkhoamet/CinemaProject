using CinemaProject.Controller;
using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class uc_addStaff : UserControl
    {
        private StaffDAO staffDAO = new StaffDAO();
        public uc_addStaff()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPW.Text;
            if (!decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                MessageBox.Show("Salary không hợp lệ!");
                return;
            }

            Staff updated = new Staff(email, password, salary);
            if (staffDAO.UpdateStaff(email, updated))
                RefreshGrid();
            else
                MessageBox.Show("Không tìm thấy nhân viên.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPW.Text;
            if (!decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                MessageBox.Show("Salary không hợp lệ!");
                return;
            }

            Staff staff = new Staff(email, password, salary);
            staffDAO.AddStaff(staff);
            RefreshGrid();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void uc_addStaff_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = staffDAO.GetAllStaff();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (staffDAO.DeleteStaff(email))
                RefreshGrid();
            else
                MessageBox.Show("Không tìm thấy nhân viên để xóa.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPW.Text = row.Cells["Password"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();
            }
        }
    }
}
