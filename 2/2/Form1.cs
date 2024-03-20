namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr1 = new StreamReader("C:\\Users\\ESMANUR\\Desktop\\esmanur.txt");
            string satir;
            while ((satir = sr1.ReadLine()) != null)
            {
                listBox1.Items.Add(satir);
            }
            sr1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fs = new FileStream("C:\\Users\\ESMANUR\\Desktop\\esmanur.txt", FileMode.Open);

            for (int i = 0; i < fs.Length; i++)
            {
                listBox2.Items.Add((char)fs.ReadByte());
            }
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var fs = new FileStream("C:\\Users\\ESMANUR\\Desktop\\sub,.txt", FileMode.Open);

            for (int i = 0; i < fs.Length; i++)
            {
                listBox3.Items.Add((char)fs.ReadByte());
            }
            fs.Close();
        }
    }
}





    


   // private void button4_Click(object sender, EventArgs e)
   // {


    //}

   /* private void Form1_Load(object sender, EventArgs e)
    {

    }*/


/* if (textBox2.Text == "Esmanur")
 {
     StreamReader sr2 = new StreamReader("C:\\Users\\ESMANUR\\Desktop\\sub,.txt");
     string str;
     while ((str = sr2.ReadLine()) == "Esmanur");
     {
         listBox3.Items.Add(str.Substring(7));
     }
     sr2.Close();

 }*/