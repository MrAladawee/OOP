namespace CreditCalculator
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> data = new Dictionary<int, int>()
        {
            { 0, 31 },
            { 1, 28 },
            { 2, 31 },
            { 3, 30 },
            { 4, 31 },
            { 5, 30 },
            { 6, 31 },
            { 7, 31 },
            { 8, 30 },
            { 9, 31 },
            { 10, 30 },
            { 11, 31 },
        };


        public Form1()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile(@"BackGr/KFBwhite_ww_400x600.jpg");
            button1.BackgroundImage = Image.FromFile(@"BackGr/DarkTheme.png");

            label1.Text = "����� ������������:";
            label2.Text = String.Format("������� ��������: {0} ���.", trackBar1.Value);

            label4.Text = "���������� ������:";
            label5.Text = String.Format("������� ��������: {0}%", trackBar2.Value);

            label6.Text = "���� ������������:";
            label7.Text = String.Format("������� ��������: {0} �����", trackBar3.Value);

            label8.Text = "��������� ���������:";
            label9.Text = "����� (���.):";
            label10.Text = "� ����� ������:";

            label11.Text = "���� ������������:";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.BackColor == DefaultBackColor)
            {
                this.BackColor = Color.Black;
                this.BackgroundImage = Image.FromFile(@"BackGr/KFBBlack_ww_400x600.jpg");
                button1.BackgroundImage = Image.FromFile(@"BackGr/WhiteTheme.png");

                foreach (Label label in Controls.OfType<Label>())
                {
                    label.ForeColor = Color.White;
                }


                foreach (TrackBar trackBar in Controls.OfType<TrackBar>())
                {
                    trackBar.BackColor = Color.Black;
                }

                Form2 form2 = new Form2(Color.Black);

            }

            else if (this.BackColor == Color.Black)
            {
                this.BackColor = DefaultBackColor;
                this.BackgroundImage = Image.FromFile(@"BackGr/KFBwhite_ww_400x600.jpg");
                button1.BackgroundImage = Image.FromFile(@"BackGr/DarkTheme.png");

                foreach (Label label in Controls.OfType<Label>())
                {
                    label.ForeColor = Color.Black;
                }

                foreach (TrackBar trackBar in Controls.OfType<TrackBar>())
                {
                    trackBar.BackColor = Color.White;
                }

                Form2 form2 = new Form2(DefaultBackColor);

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format("������� ��������: {0} ���.", trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = String.Format("������� ��������: {0}%", trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value == 1 || (trackBar3.Value > 20 && trackBar3.Value % 10 == 1))
            {
                label7.Text = String.Format("������� ��������: {0} �����", trackBar3.Value);
            }
            else if (trackBar3.Value == 2 || trackBar3.Value == 3 || trackBar3.Value == 4 ||
                ((trackBar3.Value > 20 && ((trackBar3.Value % 10 == 2 || trackBar3.Value % 10 == 3 || trackBar3.Value % 10 == 4)))))
            {
                label7.Text = String.Format("������� ��������: {0} ������", trackBar3.Value);
            }
            else { label7.Text = String.Format("������� ��������: {0} �������", trackBar3.Value); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.BackColor);

            int index = 0;

            double sum = Convert.ToDouble(trackBar1.Value);          // ����� ������������
            double percent = Convert.ToDouble(trackBar2.Value) / (12 * 100); // ����������� ������� �� ������� ������
            double percent_ = Convert.ToDouble(trackBar2.Value); // ����������� ������� �� ������� ������
            int time = Convert.ToInt32(trackBar3.Value);             // ����� ������������


            int time_Credit_Y = Convert.ToInt32(dateTimePicker1.Value.ToString("yyyy"));     // ��� ������������
            int time_Credit_M = Convert.ToInt32(dateTimePicker1.Value.ToString("MM"));      // ����� ������������

            double sum_ahead = Convert.ToDouble(textBox1.Text);                         // ����� ���������� ���������
            int time_ahead_Y = Convert.ToInt32(dateTimePicker2.Value.ToString("yyyy")); // ��� � ��������� ����������
            int time_ahead_M;                                                           // ����� � ��������� ����������

            double sum_of_payment_annuity = 0;
            double sum_of_payment_percent = 0;
            double sum_of_payment_sum = 0;

            // ���������� ������� �� ���������� ���������
            if (time_ahead_Y - time_Credit_Y == 0)
            {
                time_ahead_M = Convert.ToInt32(dateTimePicker2.Value.ToString("MM")) - 1 - time_Credit_M;
            }
            else
            {
                int difference = time_ahead_Y - time_Credit_Y;
                time_ahead_M = Convert.ToInt32(dateTimePicker2.Value.ToString("MM")) - 1 + 12 * difference;
            }

            double annuity_payment = Math.Round(sum * (percent * Math.Pow((1 + percent), time)) / (Math.Pow((1 + percent), time) - 1), 2);
            double percent_payment;
            double sum_payment;

            for (int i = 0; i < time_ahead_M; i++)
            {
                // ������� ������� �� �����
                percent_payment = Math.Round((sum * percent_ * data[time_Credit_M]) / (100 * 365), 2);
                sum_payment = Math.Round(annuity_payment - percent_payment, 2);

                // ���������� ����� ������
                sum_of_payment_annuity += annuity_payment;
                sum_of_payment_percent += percent_payment;
                sum_of_payment_sum += sum_payment;

                // ��������� �����
                sum = Math.Round(sum - sum_payment, 2);

                // ��������� ������
                time_Credit_M = (time_Credit_M + 1) % 12;

                time -= (i + 1);

                form2.dataGridView1.Rows.Add(annuity_payment, percent_payment, sum_payment, sum);
                form2.dataGridView1.Rows[index].HeaderCell.Value = (index + 1).ToString();
                index++;
            }

            sum -= sum_ahead;
            sum_of_payment_annuity += sum_ahead;

            if (sum > 0)
            {
                annuity_payment = Math.Round(sum * (percent * Math.Pow((1 + percent), time)) / (Math.Pow((1 + percent), time) - 1), 2);
                for (int i = 0; i < time; i++)
                {
                    // ������� ������� �� �����
                    percent_payment = Math.Round((sum * percent_ * data[time_Credit_M]) / (100 * 365), 2);
                    sum_payment = Math.Round(annuity_payment - percent_payment, 2);

                    if (sum - sum_payment < 0)
                    {
                        sum_payment = sum - percent_payment;
                        sum = 0;

                        sum_of_payment_annuity += annuity_payment;
                        sum_of_payment_percent += percent_payment;
                        sum_of_payment_sum += sum_payment;

                        form2.dataGridView1.Rows.Add(annuity_payment, percent_payment, sum_payment, sum);
                        form2.dataGridView1.Rows[index].HeaderCell.Value = (index + 1).ToString();
                        index++;
                    }

                    else
                    {
                        // ��������� �����
                        sum = Math.Round(sum - sum_payment, 2);

                        // ���������� ����� ������
                        sum_of_payment_annuity += annuity_payment;
                        sum_of_payment_percent += percent_payment;
                        sum_of_payment_sum += sum_payment;

                        // ��������� ������
                        time_Credit_M = (time_Credit_M + 1) % 12;

                        form2.dataGridView1.Rows.Add(annuity_payment, percent_payment, sum_payment, sum);
                        form2.dataGridView1.Rows[index].HeaderCell.Value = (index + 1).ToString();
                        index++;
                    }
                }
            }

            form2.label7.Text = string.Format("{0} ���.", Math.Round(sum_of_payment_annuity, 2));
            form2.label4.Text = string.Format("{0} ���.", Math.Round((-Convert.ToDouble(trackBar1.Value) + sum_of_payment_annuity), 2));

            form2.ShowDialog();
        }


    }
}