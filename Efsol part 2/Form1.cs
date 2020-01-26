using System;
using System.Linq;
using System.Windows.Forms;

namespace Efsol_part_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           DialogResult result= MessageBox.Show("1.Этот калькулятор не умеет считать длинные выражения,поэтому вводите два числа! \r\n 2.Этот калькулятор не умеет обрабатывать отрицательные числа,поэтому используйте только положительные!\r\n \r\n Вы согласны с условиями использования данной программы?\r\n При нажатии кнопки Нет программа завершит свою работу!", "Инструкция",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result == DialogResult.No)
                Close();
            if (result == DialogResult.Yes)
                MessageBox.Show("2,3+2,3\r\n2,3-2,3\r\n2,3*2,3\r\n2,3/2,3", "Примеры ввода данных",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string virag = textBox1.Text;
            string start = "";
            string end = "";
            char plus = '+';
            char minus = '-';
            char umnog = '*';
            char del = '/';
            if (virag.Contains(plus))
            {
                int index = virag.IndexOf(plus);
                 start = virag.Substring(0, index);
                 end = virag.Substring(index+1);
                double ch1 = double.Parse(start);
                double ch2 = double.Parse(end);
                double otvet = ch1 + ch2;
                textBox2.Text = ch1.ToString() + "\r\n" + "+" + "\r\n" + ch2.ToString() + "\r\n" + "________" + "\r\n" + otvet.ToString();
            }
            if (virag.Contains(minus))
            {
                int index = virag.IndexOf(minus);
                start = virag.Substring(0, index);
                end = virag.Substring(index+1);
                double ch1 = double.Parse(start);
                double ch2 = double.Parse(end);
                double otvet = ch1 - ch2;
                textBox2.Text = ch1.ToString() + "\r\n" + "-" + "\r\n" + ch2.ToString() + "\r\n" + "________" + "\r\n" + otvet.ToString();
            }
            if (virag.Contains(umnog))
            {
                int index = virag.IndexOf(umnog);
                start = virag.Substring(0, index);
                end = virag.Substring(index + 1);
                double ch1 = double.Parse(start);
                double ch2 = double.Parse(end);
                double otvet = ch1 * ch2;
                int count1 = BitConverter.GetBytes(decimal.GetBits((decimal)ch1)[3])[2];
                int count2 = BitConverter.GetBytes(decimal.GetBits((decimal)ch2)[3])[2];
                double temp1 = ch1 * Math.Pow(10, count1);
                double temp2 = ch2 * Math.Pow(10, count2);
                if (otvet == 0)
                    textBox2.Text = ch1 + "\r\n" + "*" + "\r\n" + ch2 + "\r\n" + "_______" + "\r\n" + "0";
                else
                    textBox2.Text = ch1 + "\r\n" + "*" + "\r\n" + ch2 + "\r\n" + "Домножим до целых" + "\r\n" + temp1 + "\r\n" + "*" + "\r\n" + temp2 + "\r\n" + "________" + "\r\n" + temp2 * temp1 + "\r\n" + "Перенесем запятую" + "\r\n" + "________" + "\r\n" + otvet;
            }
            if (virag.Contains(del))
            {
                int index = virag.IndexOf(del);
                start = virag.Substring(0, index);
                end = virag.Substring(index + 1);
                double ch1 = double.Parse(start);
                double ch2 = double.Parse(end);
                double otvet = ch1 / ch2;
                if (ch2 == 0)
                {
                    MessageBox.Show("Попытка деления на ноль!");
                    return;
                }
                int count1 = BitConverter.GetBytes(decimal.GetBits((decimal)ch1)[3])[2];
                int count2 = BitConverter.GetBytes(decimal.GetBits((decimal)ch2)[3])[2];
                double temp1 = ch1 * Math.Pow(10, count1);
                double temp2 = ch2 * Math.Pow(10, count2);
                string zap = ",";
                string str = otvet.ToString();
                int z = 1;
                if (str.Length != 1)
                {
                    z = str.Length - 1;
                    int index1 = str.IndexOf(zap);
                    str = str.Remove(index1, index1);
                }
                string b = "";
                foreach (char element in str)
                {
                    b += element + ",";
                }
                for (int i = 0; i < z; i++)
                    textBox3.Text += b;
                string[] sb = textBox3.Text.Split(',');
                int[] a = new int[z];
                for (int i = 0; i < z; i++)
                {
                    a[i] = int.Parse(sb[i]);
                    textBox4.Text += a[i] + " ";
                }
                int k = 0;
                foreach (char c in ch1.ToString())
                {
                    k++;
                }
                textBox2.Text += ch1.ToString() + " ║";
                textBox2.Text += ch2.ToString() + "\r\n";
                for (int i = 0; i < k; i++)
                {
                    textBox2.Text += "  ";
                }
                textBox2.Text += "╠════════" + "\r\n";
                for (int i = 0; i < k; i++)
                {
                    textBox2.Text += "  ";
                }
                textBox2.Text += otvet.ToString() + "\r\n" + "\r\n";
                for (int i = 0; i < z; i++)
                {
                    while (temp1 < temp2)
                    {
                        temp1 *= 10;
                    }
                    double x = temp1 - temp2 * a[i];
                    textBox2.Text += temp1 + "\r\n" + "-" + "\r\n" + (temp2 * a[i]) + "\r\n" + "________" + "\r\n" + x + "\r\n";
                    temp1 -= temp2 * a[i];
                }
            }
            
        }
    }
}
