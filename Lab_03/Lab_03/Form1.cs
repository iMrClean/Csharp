using Lab_03.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_03
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToDo item = Create_ToDo();
            dataGridView1.Rows.Add(item.Id, item.Title, item.Description, item.Date, item.IsCompleted);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected) { 
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Column2"].Value.ToString();
                richTextBox1.Text = row.Cells["Column3"].Value.ToString();
                label4.Text = row.Cells["Column4"].Value.ToString();
            }
        }

        private ToDo Create_ToDo()
        {
            ToDo todo = new ToDo
            {
                Id = dataGridView1.RowCount + 1,
                Title = textBox1.Text,
                Description = richTextBox1.Text,
                Date = dateTimePicker1.Value,
                IsCompleted = false
            };
            return todo;
        }

    }
}
