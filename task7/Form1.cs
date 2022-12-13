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

            label1.Text = "Сумма кредитования:";
            label2.Text = String.Format("Текущее значение: {0} руб.", trackBar1.Value);

            label4.Text = "Процентная ставка:";
            label5.Text = String.Format("Текущее значение: {0}%", trackBar2.Value);

            label6.Text = "Срок кредитования:";
            label7.Text = String.Format("Текущее значение: {0} месяц", trackBar3.Value);

            label8.Text = "Досрочное погашение:";
            label9.Text = "Сумма (руб.):";
            label10.Text = "В каком месяце:";

            label11.Text = "Дата кредитования:";
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

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format("Текущее значение: {0} руб.", trackBar1.Value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = String.Format("Текущее значение: {0}%", trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3.Value == 1 || (trackBar3.Value > 20 && trackBar3.Value % 10 == 1))
            {
                label7.Text = String.Format("Текущее значение: {0} месяц", trackBar3.Value);
            }
            else if (trackBar3.Value == 2 || trackBar3.Value == 3 || trackBar3.Value == 4 || 
                ((trackBar3.Value > 20 && ( (trackBar3.Value % 10 == 2 || trackBar3.Value % 10 == 3 || trackBar3.Value % 10 == 4) ))))
            {
                label7.Text = String.Format("Текущее значение: {0} месяца", trackBar3.Value);
            }
            else { label7.Text = String.Format("Текущее значение: {0} месяцев", trackBar3.Value); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            

            double sum = Convert.ToDouble(trackBar1.Value);          // Сумма кредитования
            double percent = Math.Round(Convert.ToDouble(trackBar2.Value) / (12*100),2); // Ежемесячный процент от годовой ставки
            double percent_ = Convert.ToDouble(trackBar2.Value); // Ежемесячный процент от годовой ставки
            int time = Convert.ToInt32(trackBar3.Value);             // Время кредитования


            int time_Credit_Y = Convert.ToInt32(dateTimePicker1.Value.ToString("yyyy"));     // Год кредитования
            int time_Credit_M = Convert.ToInt32(dateTimePicker1.Value.ToString("MM")) - 1;      // Месяц кредитования

            double sum_ahead = Convert.ToDouble(textBox1.Text);                         // Сумма досрочного погашения
            int time_ahead_Y = Convert.ToInt32(dateTimePicker2.Value.ToString("yyyy")); // Год с досрочным погашением
            int time_ahead_M;                                                           // Месяц с досрочным погашением

            double sum_of_payment_annuity = 0;
            double sum_of_payment_percent = 0;
            double sum_of_payment_sum = 0;

            // Вычисление времени до досрочного погашения
            if (time_ahead_Y - time_Credit_Y == 0)
            {
                time_ahead_M = Convert.ToInt32(dateTimePicker2.Value.ToString("MM")) - 1 - time_Credit_M;
            }
            else
            {
                int difference = time_ahead_Y - time_Credit_Y;
                time_ahead_M = Convert.ToInt32(dateTimePicker2.Value.ToString("MM")) - 1 + 12*difference;
            }

            double annuity_payment = Math.Round(sum * (percent * Math.Pow((1 + percent), time)) / (Math.Pow((1 + percent), time) - 1),2);
            double percent_payment;
            double sum_payment;

            for (int i = 0; i < time_ahead_M; i++)
            {
                // текущие выплаты за месяц
                percent_payment = Math.Round((sum * percent_ * data[time_Credit_M]) / (100 * 365),2);
                sum_payment = Math.Round(annuity_payment - percent_payment,2);

                // Вычисление общих выплат
                sum_of_payment_annuity += annuity_payment;
                sum_of_payment_percent += percent_payment;
                sum_of_payment_sum += sum_payment;

                // Изменение суммы
                sum = Math.Round(sum - sum_payment,2);

                // Изменение месяца
                time_Credit_M = (time_Credit_M + 1) % 12;

                time -= (i + 1);

                form2.dataGridView1.Rows.Add(annuity_payment, percent_payment, sum_payment, sum);

            }

            sum -= sum_ahead;
            sum_of_payment_annuity += sum_ahead;

            if (sum > 0)
            {
                annuity_payment = Math.Round(sum * (percent * Math.Pow((1 + percent), time)) / (Math.Pow((1 + percent), time) - 1),2);
                for (int i = 0; i < time; i++)
                {
                    // текущие выплаты за месяц
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
                    }

                    else
                    {
                        // Изменение суммы
                        sum = Math.Round(sum - sum_payment, 2);

                        // Вычисление общих выплат
                        sum_of_payment_annuity += annuity_payment;
                        sum_of_payment_percent += percent_payment;
                        sum_of_payment_sum += sum_payment;

                        // Изменение месяца
                        time_Credit_M = (time_Credit_M + 1) % 12;

                        form2.dataGridView1.Rows.Add(annuity_payment, percent_payment, sum_payment, sum);
                    }
                }
            }

            form2.label7.Text = sum_of_payment_annuity.ToString();
            form2.label4.Text = Math.Round((-Convert.ToDouble(trackBar1.Value) + sum_of_payment_annuity),2).ToString();

            form2.ShowDialog();
        }


    }
}
