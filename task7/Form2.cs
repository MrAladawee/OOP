using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCalculator
{
    public partial class Form2 : Form
    {
        public Form2(Color color)
        {
            InitializeComponent();

            Form1 form1 = new Form1();

            if (color == DefaultBackColor)
            {
                this.BackColor = DefaultBackColor;
                this.BackgroundImage = Image.FromFile(@"BackGr/ResultWhite.jpg");
                dataGridView1.BackgroundColor = Color.White;
            }

            else
            {
                this.BackColor = Color.Black;
                this.BackgroundImage = Image.FromFile(@"BackGr/ResultBlack.jpg");
                dataGridView1.BackgroundColor = Color.Black;

                foreach (Label label in Controls.OfType<Label>())
                {
                    label.ForeColor = Color.White;
                }

            }

            label1.Text = "График платежей";
            label2.Text = "Полная сумма выплат:";
            label3.Text = "Переплата:";

            dataGridView1.Columns[0].HeaderText = "Аннуитетный платеж";
            dataGridView1.Columns[1].HeaderText = "Платеж по процентам";
            dataGridView1.Columns[2].HeaderText = "Платеж по кредиту";
            dataGridView1.Columns[3].HeaderText = "Остаток";

            DataGridViewCellStyle style = dataGridView1.ColumnHeadersDefaultCellStyle;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

    }
}
