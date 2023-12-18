using Microsoft.EntityFrameworkCore;
using NPOI.HPSF;
using Task_2.Database;
using Task_2.Parser;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DownloadToDatabaseButton_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Enter the file path", "Œ¯Ë·Í‡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ExcelParser.ReadExcelFile(textBox1.Text);

                MessageBox.Show("File successfully downloded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetFileInformationButton_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Enter the file name with extention", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fileName = textBox2.Text;
            int defaultWidth = 150;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.Width = defaultWidth;
            }

            try
            {
                DatabaseActions.GetAllFile(dataGridView1, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetClassesInformationButton_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Enter the file name with extention", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int defaultWidth = 400;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.Width = defaultWidth;
            }

            var fileName = textBox2.Text;

            try
            {
                DatabaseActions.GetClassesInformation(dataGridView1, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetGroupInformationButton_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Enter the file name with extention", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int defaultWidth = 200;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                column.Width = defaultWidth;
            }

            var fileName = textBox2.Text;

            try
            {
                DatabaseActions.GetGroupsInformation(dataGridView1, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DownloadedFilesButton_Click(object sender, EventArgs e)
        {
            DatabaseActions.GetDownloadedFiles(dataGridView1);
        }
    }
}