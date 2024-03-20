using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace gorselprogramlama
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        int sayac = 0;
        private void bas_Click(object sender, EventArgs e)
        {
            sayac++;
            listBox3.Items.Add(sayac);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

        }

        ////////////////////



        Queue kuyruk = new Queue();
        int sira = 0;

        Stack yigin = new Stack();
        int sayac1 = 0;
        void ListeleStack()
        {
            listBox2.Items.Clear();
            foreach (var item in yigin)//nesneler içinde gezmemizi saðlýyor.
            {
                listBox2.Items.Add(item);
            }

        }
        void ListeleQueue()
        {
            listBox2.Items.Clear();
            foreach (var item in kuyruk)
            {
                listBox2.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            kuyruk.Enqueue(sira);
            sira++;
            ListeleQueue();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kuyruk.Dequeue();
            ListeleQueue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yigin.Push(sayac1);
            sayac1++;
            ListeleStack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yigin.Pop();
            ListeleStack();

        }

        ////////////////////

        private void button6_Click(object sender, EventArgs e)
        {
            Control Gbox = ((Button)sender).Parent;

            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item2 in (item as GroupBox).Controls)
                    {
                        if (item2 is TextBox && item2.Parent == Gbox && (item2 as TextBox).TabIndex % 2 == 0)
                        {
                            (item2 as TextBox).Clear();
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            Control Gbox = ((Button)sender).Parent;


            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item2 in (item as GroupBox).Controls)
                    {
                        if (item2.Parent == Gbox)
                        {
                            sayac++;
                        }
                    }
                }
            }
            MessageBox.Show("nesne sayýsý:" + sayac);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*
            if(comboBox1.SelectedIndex == 0)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Avanons");
                listBox3.Items.Add("göreme");
                listBox3.Items.Add("ürgüp");

            }
            else if(comboBox1.SelectedIndex == 1) 
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("meran");
                listBox3.Items.Add("selçuklu");
                listBox3.Items.Add("karatay");
            }
            */
            if (comboBox1.Text == "nevþehir")
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Avanons");
                listBox3.Items.Add("göreme");
                listBox3.Items.Add("ürgüp");

            }
            else if (comboBox1.Text == "konya")
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("meran");
                listBox3.Items.Add("selçuklu");
                listBox3.Items.Add("karatay");
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            comboBox1.Items.Add("nevþehir");
            comboBox1.Items.Add("konya");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("nevþehir");
            comboBox1.Items.Add("konya");

            comboBox2.Items.Add("label");
            comboBox2.Items.Add("textbox");
            comboBox2.Items.Add("listbox");

            string line;
            StreamReader streamReader = new("C:\\Users\\ESMANUR\\Desktop\\programlama dilleri\\c#\\gorselprogramlama");
            line=streamReader.ReadLine();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*if (textBox8.Text == "nevþehir")
            {
                comboBox1.Text = "nevþehir";
            }
            else if (textBox8.Text == "konya")
            {
                comboBox1.Text = "konya";
            }*/

            comboBox1.SelectedIndex = (int)Convert.ToInt32(textBox8.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int sayac1 = 0;
            int sayac2 = 0;
            int sayac3 = 0;

            if (comboBox2.Text == "label")
            {

                foreach (Control control in groupBox6.Controls)
                {
                    if (control is Label)
                    {
                        sayac1++;
                    }
                }
                textBox11.Text = "label sayýsý:" + sayac1;
            }
            else if(comboBox2.Text == "textbox")
            {
                foreach(Control control in groupBox6.Controls)
                {
                    if (control is TextBox) 
                    {
                        sayac2++;
                    
                    }
                }
                textBox11.Text = "textbox sayýsý:" + sayac2;
            }
            else if (comboBox2.Text == "listbox")
            {
                foreach(Control control in groupBox6.Controls)
                {
                    if(control is ListBox) 
                    {
                        sayac3++;
                    }
                }
                textBox11.Text = "listbox sayýsý:" + sayac3;
            }
        }
    }
}


