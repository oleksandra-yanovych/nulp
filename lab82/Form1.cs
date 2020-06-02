using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace lab82
{
    public partial class Form1 : Form
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        public Form1()
        {
            InitializeComponent();
            EditLabel(0);
        }
        void button1_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(1);

        }
        void MainButton(int check)
        {
            if (check == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (check == 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }
        void EditLabel(int check)
        {
            if (check == 0)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SearchBtn.Hide();
                SortNum.Hide();
                SortPhNumber.Hide();
                SortRating.Hide();
            }
            if (check == 1)
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                button6.Show();
                DeleteBtn.Hide();
                SortNum.Hide();
                SortPhNumber.Hide();
                SortRating.Hide();
            }
            if (check == 2)
            {
                DeleteBtn.Show();
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                SearchBtn.Hide();
                SortNum.Hide();
                SortPhNumber.Hide();
                SortRating.Hide();
            }
            if (check == 3)
            {
                SearchBtn.Show();
                label1.Show();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SortNum.Hide();
                SortPhNumber.Hide();
                SortRating.Hide();
            }
            if (check == 4)
            {
                SearchBtn.Hide();
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                button6.Hide();
                DeleteBtn.Hide();
                SortNum.Show();
                SortPhNumber.Show();
                SortRating.Show();
            }
        }
        void button3_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(3);
        }
        void AddService(string number, string city, string street, string point, string phone)
        {
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            data.Add(new Service_Data { Num = number, Сity = city, Street = street, Rating = point, PhNumber = phone });
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);


        }
        void DeleteService(string number)
        {
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            data.RemoveAll(x => x.Num == number);
            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }
        void SearchService(string number)
        {
            textBox1.Text = "";
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            Service_Data FoundData = data.Find(found => found.Num == number);
            string info = "      " + FoundData.Num + "         " + FoundData.Сity + "           " + FoundData.Street + "           " + FoundData.Rating + "               " + FoundData.PhNumber;
            textBox1.AppendText("╔═════════╤═══════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("    Number   │    City    │  Street  │    Point    │ Phone number");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═══════╪════════╪════════╪═══════════╣");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(info);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═══════╧════════╧════════╧═══════════╝");

            string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (serialize.Count() > 1)
            {
                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                File.WriteAllText(FilePath, serialize, Encoding.UTF8);
            }
            EditLabel(0);
            MainButton(1);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            AddService(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchService(textBox2.Text);
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteService(textBox2.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MainButton(0);
            EditLabel(2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EditLabel(4);
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("    Number   │    City    │  Street  │    Point    │ Phone number");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("       " + data[i].Num + "          " + data[i].Сity + "           " + data[i].Street + "            " + data[i].Rating + "                 " + data[i].PhNumber);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortNum_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            List<Service_Data> SortData = data.OrderBy(o => o.Num).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("    Number   │    City    │  Street  │    Point    │ Phone number");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Num + "          " + SortData[i].Сity + "           " + SortData[i].Street + "            " + SortData[i].Rating + "                 " + SortData[i].PhNumber);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortPhNumber_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            List<Service_Data> SortData = data.OrderBy(o => o.PhNumber).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("    Number   │    City    │  Street  │    Point    │ Phone number");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Num + "          " + SortData[i].Сity + "           " + SortData[i].Street + "            " + SortData[i].Rating + "                 " + SortData[i].PhNumber);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void SortRating_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<List<Service_Data>>(File.ReadAllText(FilePath));
            List<Service_Data> SortData = data.OrderBy(o => o.Rating).ToList();
            textBox1.Text = "";
            textBox1.AppendText("╔═════════╤═════════╤════════╤════════╤═══════════╗");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("    Number   │    City    │  Street  │    Point    │ Phone number");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            for (int i = 0; i < data.Count; i++)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("     " + SortData[i].Num + "          " + SortData[i].Сity + "           " + SortData[i].Street + "            " + SortData[i].Rating + "                 " + SortData[i].PhNumber);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("╠═════════╪═════════╪════════╪════════╪═══════════╣");
            }
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("╚═════════╧═════════╧════════╧════════╧═══════════╝");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            EditLabel(0);
            MainButton(1);
        }
    }

    public class Service_Data
    {
        private string number;
        private string city;
        private string point;
        private string street;
        private string phone;

        public string Num
        {
            get { return number; }
            set { number = value; }
        }
        public string Сity
        {
            get { return city; }
            set { city = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string Rating
        {
            get { return point; }
            set { point = value; }
        }
        public string PhNumber
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}
