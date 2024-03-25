using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace görseluygulamalar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        //ÖRNEK1:Butona bastıkça listboxa sayı yazdıran ve temizledikten sonra kaldığı yerden devam eden sayaç

        int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            sayac++;
            listBox1.Items.Add(sayac);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        /* Örnek2: Enqueu ve Push işlemleri
        Stack:son giren ilk çıkar .. Queue :ilk giren ilk çıkar*/

        Queue kuyruk = new Queue();
        int kuyruksira = 0;

        Stack yigin = new Stack();
        int yiginsira = 0;

        void ListeleQueue()
        {
            listBox2.Items.Clear();
            foreach (var item in kuyruk)
            {
                listBox2.Items.Add(item);

            }
        }
        void ListeleStack()
        {
            listBox2.Items.Clear();
            foreach (var item in yigin)
            {
                listBox2.Items.Add(item);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            kuyruk.Enqueue(kuyruksira);
            kuyruksira++;
            ListeleQueue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kuyruk.Dequeue();
            ListeleQueue();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yigin.Push(yiginsira);
            yiginsira++;
            ListeleStack();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yigin.Pop();
            ListeleStack();
        }

        //ÖRNEK3: TabIndex'i çift olan TextBox ı silmek
        //in bir döngüde koleksiyon elemanlarını işlemek, as bir tür dönüşümü yapmak,is bir tür kontrolü yapmak 
        private void button7_Click(object sender, EventArgs e)
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
        //ÖRNEK4: GroupBox ın içindeki nesne sayısını saydırmak
        private void button8_Click(object sender, EventArgs e)
        {
            int syc = 0;

            Control Gbox = ((Button)sender).Parent;

            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    foreach (Control item2 in (item as GroupBox).Controls)
                    {
                        if (item2.Parent == Gbox)
                        {
                            syc++;
                        }
                    }
                }
            }
            MessageBox.Show("Nesne Sayısı" + syc);

        }
        //ÖRNEK5: Buton9 a basıldığında tüm textboxların içini temizleme
        private void button9_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is GroupBox)
                {
                    temizle(item);
                }

            }
            /*hepsini değilde sadece o textboxı temizlemek istiyorsak  button9_click koduna
            Control Gbox1 = ((Button)sender).Parent;
            temizle(Gbox1); 
            yazmamız yeterli*/

            void temizle(Control Gbox1)
            {

                foreach (Control item in this.Controls)
                {
                    if (item is GroupBox)
                    {
                        foreach (Control item2 in item.Controls)
                        {
                            if ((item2 is TextBox) && (item2.Parent == Gbox1))
                            {
                                (item2 as TextBox).Clear();
                            }

                        }

                    }

                }
            }
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }
        //ÖRNEK6: Kaç tane textboxa yazı yazdığımızı label a yazdıran ve textboxları temizleyen kod
        private void button13_Click(object sender, EventArgs e)
        {
            int counter = 0;
            {
                Control Gbox3 = ((Button)sender).Parent;


                foreach (Control item in this.Controls)
                {
                    if (item is GroupBox)
                    {
                        foreach (Control item2 in item.Controls)
                        {
                            if ((item2 is TextBox) && (item2.Parent == Gbox3) && ((item2 as TextBox).Text.Length > 0))
                            {
                                (item2 as TextBox).Clear();
                                counter++;

                                foreach (Control item3 in item.Controls)
                                {
                                    if ((item3 is Label) && (item3.Parent == Gbox3))
                                    {

                                        (item3 as Label).Text = counter.ToString();

                                    }

                                }

                            }
                        }


                    }
                }

            }
        }
        //ÖRNEK7:Combobox
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Nevşehir");
            comboBox1.Items.Add("Konya");
            comboBox1.Items.Add("İstanbul");
            comboBox1.Items.Add("Ankara");



            //örnek 8 için combobox 
            foreach (Control item0 in this.Controls)
            {
                if (item0 is ComboBox)
                {
                    (item0 as ComboBox).Items.Clear();
                    (item0 as ComboBox).Items.Add("+");
                    (item0 as ComboBox).Items.Add("-");
                    (item0 as ComboBox).Items.Add("*");
                    (item0 as ComboBox).Items.Add("/");

                }
            }
            //örnek 9 için
            comboBox3.Items.Add("TextBox");
            comboBox3.Items.Add("ListBox");
            comboBox3.Items.Add("label");


            //örnek13 için
            comboBox4.Items.Add("Toplama");
            comboBox4.Items.Add("Çıkarma");
            comboBox4.Items.Add("Çarpma");
            comboBox4.Items.Add("Bölme");



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Ürgüp");
                listBox3.Items.Add("Avanos");
                listBox3.Items.Add("Göreme");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Meram");
                listBox3.Items.Add("Karatay");
                listBox3.Items.Add("Selçuk");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Keçiören");
                listBox3.Items.Add("Mamak");
                listBox3.Items.Add("Kızılay");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Fatih");
                listBox3.Items.Add("Bakırköy");
                listBox3.Items.Add("Beyoğlu");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "NEVŞEHİR")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (textBox1.Text == "KONYA")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if (textBox1.Text == "ANKARA")
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (textBox1.Text == "İSTANBUL")
                {
                    comboBox1.SelectedIndex = 3;
                }

                //comboBox1.SelectedIndex = Convert.ToInt32(textBox21.Text);
            }
        }
        //örnek8
        private void button15_Click(object sender, EventArgs e)
        {
            float sayi1 = 0;
            float sayi2 = 0;
            float sonuc = 0;
            string ids = "";

            foreach (Control item1 in this.Controls)
            {
                if (item1 is GroupBox)
                {
                    foreach (Control item2 in item1.Controls)
                    {
                        if ((item2 is TextBox) && (item2.TabIndex == 0))
                        {
                            sayi1 = Convert.ToInt32((item2 as TextBox).Text);
                            Console.WriteLine(sayi1);
                        }
                        else if ((item2 is TextBox) && (item2.TabIndex == 1))
                        {
                            sayi2 = Convert.ToInt32((item2 as TextBox).Text);
                            Console.WriteLine(sayi2);
                        }
                    }


                }
            }
            foreach (Control item4 in this.Controls)
            {
                if (item4 is ComboBox)
                {
                    ids = (item4 as ComboBox).Text;
                    if (ids == "+")
                    {
                        sonuc = sayi1 + sayi2;
                    }
                    else if (ids == "-")
                    {
                        sonuc = sayi1 - sayi2;
                    }
                    else if (ids == "*")
                    {
                        sonuc = sayi1 * sayi2;
                    }
                    else if (ids == "/")
                    {
                        sonuc = sayi1 / sayi2;
                    }
                }


                foreach (Control item5 in this.Controls)
                {
                    if (item5 is GroupBox)
                    {
                        foreach (Control item6 in item5.Controls)
                        {
                            if (item6 is Label)
                            {
                                (item6 as Label).Text = Convert.ToString(sonuc);
                            }
                        }
                    }
                }
            }
        }
        //örnek9: groupbox içindeki elemanları sayan
        private void button16_Click(object sender, EventArgs e)
        {
            int lsayac = 0;
            int tsayac = 0;
            int lisayac = 0;

            if (comboBox3.Text == "TextBox")
            {
                foreach (Control control in groupBox13.Controls)
                {
                    if (control is TextBox)
                    {
                        tsayac++;
                    }
                }
                textBox26.Text = "textbox sayısı:" + tsayac;
            }
            else if (comboBox3.Text == "ListBox")
            {
                foreach (Control control in groupBox13.Controls)
                {
                    if (control is ListBox)
                    {
                        lisayac++;
                    }
                }
                textBox26.Text = "listbox sayısı:" + lisayac;

            }
            if (comboBox2.Text == "label")
            {

                foreach (Control control in groupBox13.Controls)
                {
                    if (control is Label)
                    {
                        lsayac++;
                    }
                }
                textBox26.Text = "label sayısı:" + lsayac;
            }
        }

        //örnek10 dosya okuma satırca
        private void button17_Click(object sender, EventArgs e)
        {
            StreamReader sr1 = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir;
            while ((satir = sr1.ReadLine()) != null)
            {
                listBox5.Items.Add(satir);
            }
            sr1.Close();

        }

        //örnek11 dosyayı harf harf alt alta yazdırma
        private void button18_Click(object sender, EventArgs e)
        {
            {
                var fs = new FileStream("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt", FileMode.Open);

                for (int i = 0; i < fs.Length; i++)
                {
                    listBox6.Items.Add((char)fs.ReadByte());
                }
                fs.Close();
            }
        }

        //örnek12 dosyayı harf harf alt alta yazdırma
        private void button19_Click(object sender, EventArgs e)
        {
            var fs = new FileStream("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt", FileMode.Open);

            for (int i = 0; i < fs.Length; i++)
            {
                listBox7.Items.Add((char)fs.ReadByte());
            }
            fs.Close();
        }

        //örnek13 matematik işlem 
        private void button20_Click(object sender, EventArgs e)
        {
            double sayi1 = Convert.ToDouble(textBox28.Text);
            double sayi2 = Convert.ToDouble(textBox27.Text);
            double sonuc = 0;

            if (comboBox4.SelectedIndex == 0)
            {
                sonuc = sayi1 + sayi2;
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                sonuc = sayi1 - sayi2;
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                sonuc = sayi1 * sayi2;
            }
            else if (comboBox4.SelectedIndex == 3)
            {
                if (sayi2 == 0)
                {
                    MessageBox.Show("Sayı sıfıra bölünemez!");
                }
                else
                {
                    sonuc = sayi1 / sayi2;
                }
            }

            label9.Text = sonuc.ToString();
        }
        //örnek14 textle ilgililer
        private void button21_Click(object sender, EventArgs e)
        {
            StreamReader st = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir;

            while ((satir = st.ReadLine()) != null)
            {
                listBox8.Items.Add(satir);
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            string kelime = Convert.ToString(textBox30.Text);
            bool varmi = false;

            for (int i = 0; i < listBox8.Items.Count; i++)
            {
                if (listBox8.Items[i].ToString().Contains(kelime))
                {
                    varmi = true;
                    break;
                }
            }

            if (varmi)
            {
                label10.Text = "Var";
            }
            else
            {
                label10.Text = "Yok";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            StreamReader st = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir;

            while ((satir = st.ReadLine()) != null)
            {
                foreach (char karakter in satir)
                {
                    listBox8.Items.Add(karakter);
                }

                /*  var fs = new FileStream("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt", FileMode.Open);

                  for (int i = 0; i < fs.Length; i++)
                  {
                      listBox8.Items.Add((char)fs.ReadByte());
                      fs.Close();
                  }*/

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            int karakter;
            int karakterSayisi = 0;

            while ((karakter = sw.Read()) != -1)
            {
                listBox8.Items.Add((char)karakter);
                karakterSayisi++;
            }

            MessageBox.Show("Karakter sayısı: " + karakterSayisi);

            fs.Close();
            sw.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            StreamReader st = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir;
            string alinanIsım = Convert.ToString(textBox29.Text.Trim());

            while ((satir = st.ReadLine()) != null)
            {
                satir = satir.Trim();
                string isim = satir.Substring(0, alinanIsım.Length).Trim();

                if (isim.Equals(alinanIsım))
                {
                    string numara = satir.Substring(alinanIsım.Length).Trim();
                    MessageBox.Show(numara);
                    break;
                }
            }
            st.Close();
        }

        //örnek15
        private void button26_Click(object sender, EventArgs e)
        {
            StreamReader sr2 = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir1;
            string ad = "";
            string no = "";
            while ((satir1 = sr2.ReadLine()) != null)
            {
                no = satir1.Substring(0, 11);
                ad = satir1.Substring(12);
                listBox9.Items.Add(ad + " " + no);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            StreamReader sr3 = new StreamReader("C:\\Users\\esman\\OneDrive\\Masaüstü\\okul\\görseltext.txt");
            string satir2;
            string ad = "";
            string vize = "";
            string final = "";
            while ((satir2 = sr3.ReadLine()) != null)
            {
                ad = satir2.Substring(6);
                final = satir2.Substring(3, 2);
                vize = satir2.Substring(0, 2);
                int viz = Convert.ToInt32(final);
                int fin = Convert.ToInt32(vize);

                listBox10.Items.Add((viz + fin) / 2 + " " + ad);
            }
        }
        //Substring(3, 2): 3. karakterden başlayarak 2 karakter alınacaktır. Merhaba kelimesi mesela "haba" alınır.
    }
}
  
     

    






        







    

