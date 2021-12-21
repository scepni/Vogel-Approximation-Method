using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace optimizasyon_test
{

    public partial class degerler : Form
    {

        int[,] matris;
        int Matris_x;
        int Matris_y;
        int sonuc = 0;
        string sonucstring = "";
        List<List<TextBox>> tbMatris;
        public degerler(int value_x, int value_y, List<List<TextBox>> TextBoxMatris)
        {
            InitializeComponent();

            Matris_x = value_x;
            Matris_y = value_y;
            matris = new int[Matris_x + 1, Matris_y + 1];
            this.Value_x = value_x;
            this.Value_y = value_y;

            tbMatris = TextBoxMatris;

        }

        public int Value_x { get; set; }
        public int Value_y { get; set; }
        private void degerler_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void degerler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Matris_x = Value_x + 1;
            Matris_y = Value_y + 1;

            MatrisOlustur();

            button1.Enabled = false;


        }

        public void MatrisOlustur()
        {
            Form1 f1 = new Form1();

            //Bir matris oluşturuldu; x ve y boyutlarına fabrika ve şehir değişkenleri atandı.



            bool[,] boolarray = new bool[Matris_x, Matris_y];
            List<int> primeNumbers = new List<int>();

            foreach (Control x in this.Controls)
            {

                if (x is TextBox)
                {
                    if (((TextBox)x).Text != "")
                    {


                        primeNumbers.Add(Convert.ToInt32(((TextBox)x).Text));
                    }

                }

            }
            //Matris oluşturuldu.
            int k = 0;
            for (int i = 0; i < Matris_x; i++)
            {
                for (int j = 0; j < Matris_y; j++)
                {

                    if (k < primeNumbers.Count)
                    {

                        matris[i, j] = primeNumbers[k];


                    }
                    k++;
                }
            }

            BoolDiziOlustur(boolarray); //Tüm indexleri false olan bir bool dizisi oluşturdu.
            /*
              while (true)
              {
                  if (Kontrol_Arz_Talep_sifir(matris, boolarray) == true)
                  {

                      minnHesapla(matris, Matris_x, Matris_y, boolarray);

                  }
                  else
                  {

                      break;
                  }
              }
            */
            //if silinen kontrol(min1,min2)!=true ,
            //satir_sutun_ceza_hesapla
            //Indexe Ata
            //Sutun Sildir


        }
        public void minnHesapla(int[,] mat, int n, int m)
        {



            int min1, min2;
            int satircezasi = 0;
            int sutuncezasi = 0;
            int tempj = 0;
            int tempk = 0;
            int tempi = 0;
            int tempt = 0;
            List<int> satircezasilist = new List<int>();
            List<int> sutuncezasilist = new List<int>();
            min1 = min2 = int.MaxValue;
            //Satir cezaları Hesaplandı
            for (int i = 0; i < mat.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < mat.GetLength(1) - 1; j++)
                {
                    if (mat[i, j] < min1)
                    {
                        min2 = min1;
                        min1 = mat[i, j];
                        tempj = j;
                        tempi = i;
                    }
                    else if (mat[i, j] < min2)
                    {
                        min2 = mat[i, j];
                        tempj = j;
                        tempi = i;
                    }
                    satircezasi = min2 - min1;
                }
                satircezasilist.Add(satircezasi);



                min1 = min2 = int.MaxValue;
            }
            //Sütun cezaları Hesaplandı
            for (int t = 0; t < mat.GetLength(1) - 1; t++)
            {
                //Sütundaki minimum iki sayı bulundu ve farkları hesaplanarak her bir sütunun sutun cezasına ulaşıldı.
                for (int k = 0; k < mat.GetLength(0) - 1; k++)
                {
                    if (mat[k, t] < min1)
                    {
                        min2 = min1;
                        min1 = mat[k, t];
                        tempk = k;
                        tempt = t;
                    }
                    else if (mat[k, t] < min2)
                    {
                        min2 = mat[k, t];
                        tempk = k;
                        tempt = t;
                    }
                    sutuncezasi = min2 - min1;
                }
                sutuncezasilist.Add(sutuncezasi);


                min1 = min2 = int.MaxValue;

            }

            satir_sutun_ceza_hesapla(mat, satircezasilist, sutuncezasilist);
        }

        public void satir_sutun_ceza_hesapla(int[,] mat, List<int> satircezasilist, List<int> sutuncezasilist)
        {

            int maxsatircezasi = 0;
            int maxsutuncezasi = 0;
            //En büyük satır ve sütun cezasının olduğu indeks hesaplandı.
            maxsatircezasi = satircezasilist.Max(r => r);
            maxsutuncezasi = sutuncezasilist.Max(r => r);

            int indexsatir = 0;
            int indexsutun = 0;
            int arz;
            int talep;
            int yeniarz;
            int yenitalep;
            //Maksimum satır ve maksimum sütun cezaları kontrol edilerek satır ya da sütun işlemi yapılacağı kontrol edildi.
            if (maxsatircezasi > maxsutuncezasi)
            {
                for (int i = 0; i < satircezasilist.Count; i++)
                {
                    if (maxsatircezasi == satircezasilist[i])
                    {
                        indexsatir = i;

                    }

                }

                int minsatir = mat[indexsatir, 0];
                for (int t = 0; t < mat.GetLength(0) - 1; t++)
                {

                    if (minsatir > mat[indexsatir, t])
                    {
                        minsatir = mat[indexsatir, t];

                        indexsutun = t;
                    }


                }

                arz = mat[indexsatir, mat.GetLength(1) - 1];
                talep = mat[mat.GetLength(0) - 1, indexsutun];
                //Satır Cezasının Büyük Olduğu Durumlar
                if (arz >= talep)
                {
                    yenitalep = 0;
                    yeniarz = arz - talep;
                    mat[indexsatir, mat.GetLength(1) - 1] = yeniarz;
                    mat[mat.GetLength(0) - 1, indexsutun] = yenitalep;

                    IndexeAta(minsatir, talep, mat, indexsatir, indexsutun);
                    Sutunsil(indexsutun, mat);


                }
                else
                {
                    yenitalep = talep - arz;
                    yeniarz = 0;
                    mat[indexsatir, mat.GetLength(1) - 1] = yeniarz;
                    mat[mat.GetLength(0) - 1, indexsutun] = yenitalep;
                    IndexeAta(minsatir, arz, mat, indexsatir, indexsutun);
                    Satirsil(indexsatir, mat);



                }

            }
            //Sütun cezası daha büyükse aşağıdaki işlem yapıldı.
            else
            {
                // Sutunsil(indexsatir, boolarray);
                for (int i = 0; i < sutuncezasilist.Count; i++)
                {
                    if (maxsutuncezasi == sutuncezasilist[i])
                    {
                        indexsutun = i;
                    }

                }
                int minsutun = mat[0, indexsutun];
                for (int t = 0; t < mat.GetLength(0) - 1; t++)
                {

                    if (minsutun > mat[t, indexsutun])
                    {
                        minsutun = mat[t, indexsutun];
                        indexsatir = t;
                    }


                }
                arz = mat[indexsatir, mat.GetLength(1) - 1];
                talep = mat[mat.GetLength(0) - 1, indexsutun];
                if (arz >= talep)
                {
                    yenitalep = 0;
                    yeniarz = arz - talep;
                    mat[indexsatir, mat.GetLength(1) - 1] = yeniarz;
                    mat[mat.GetLength(0) - 1, indexsutun] = yenitalep;

                    arz = yeniarz;
                    IndexeAta(minsutun, talep, mat, indexsatir, indexsutun);
                    Sutunsil(indexsutun, mat);


                }
                else
                {
                    yenitalep = talep - arz;
                    yeniarz = 0;
                    mat[indexsatir, mat.GetLength(1) - 1] = yeniarz;
                    mat[mat.GetLength(0) - 1, indexsutun] = yenitalep;
                    IndexeAta(minsutun, arz, mat, indexsatir, indexsutun);

                    Satirsil(indexsatir, mat);

                }


            }



        }

        public void IndexeAta(int minsatir, int ifade, int[,] mat, int indexsatir, int indexsutun)
        {
            int Location_x = 0;
            int Location_y = 0;


            Label l1 = new Label();

            l1.Width = 20;
            l1.Height = 10;
            l1.Visible = true;
            l1.Font = new Font("Consolas", 8, FontStyle.Bold);
            l1.ForeColor = Color.Red;
            /*
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {

                    if (((TextBox)item).Text == minsatir.ToString() && ((TextBox)item).Name == "input")
                    {

                        Location_x = ((TextBox)item).Location.X;
                        Location_y = ((TextBox)item).Location.Y;
                    }
                }


            }
            */

            if (tbMatris[indexsatir][indexsutun].Text == minsatir.ToString() && tbMatris[indexsatir][indexsutun].Name == "input")
            {
                Location_x = tbMatris[indexsatir][indexsutun].Location.X;
                Location_y = tbMatris[indexsatir][indexsutun].Location.Y;
            }
            l1.Location = new Point(Location_x + 4, Location_y + 22);
            l1.Text = ifade.ToString();

            sonuc += ifade * minsatir;
            sonucstring += "(" + ifade.ToString() + " * " + minsatir.ToString() + ")" + "+";

            this.Controls.Add(l1);
        }
        public void BoolDiziOlustur(bool[,] boolarray)
        {


            for (int i = 0; i < boolarray.GetLength(0); i++)
            {
                for (int j = 0; j < boolarray.GetLength(1); j++)
                {
                    boolarray[i, j] = false;
                }
            }


        }

        public bool SilinenKontrol(bool[,] array, int x, int y)
        {
            if (array[x, y] == true)
            {

                return true;
            }
            else
            {

                return false;

            }




        }




        public void Satirsil(int silinen_satir, int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(1) - 1; i++)
            {
                mat[silinen_satir, i] = int.MaxValue;
            }
            /*
            int i;
            for (i = silinen_satir; i < mat.GetLength(0)-1; i++)
            {
                for (int j  = 0;  j  < mat.GetLength(1);  j ++)
                {
                    mat[i, j] = mat[i + 1, j];
                }
            }
              */
        }

        public void Sutunsil(int silinen_sutun, int[,] mat)
        {

            for (int i = 0; i < mat.GetLength(0) - 1; i++)
            {
                mat[i, silinen_sutun] = int.MaxValue;
            }
            /*
             int i;
             for (i =0 ; i < mat.GetLength(0); i++)
             {
                 for (int j = silinen_sutun; j < mat.GetLength(1)-1; j++)
                 {
                     mat[i, j] = mat[i, j+1];
                 }
             }
             for (int t = 0; t < mat.GetLength(0); t++)
             {
                 for (int k = 0; k < mat.GetLength(1); k++)
                 {
                     MessageBox.Show(mat[t, k].ToString());
                 }
             }
            */
        }



        public bool Kontrol_Arz_Talep_sifir(int[,] mat, bool[,] boolarray)
        {
            int talep_sifirsayac = -1;
            int arz_sifirsayac = -1;
            for (int j = 0; j < mat.GetLength(1) - 1; j++)
            {

                if (mat[j, mat.GetLength(1) - 1] == 0)
                {

                    arz_sifirsayac++;

                }

            }
            for (int i = 0; i < mat.GetLength(0) - 1; i++)
            {
                if (mat[mat.GetLength(0) - 1, i] == 0)
                {

                    talep_sifirsayac++;
                }
            }
            if (talep_sifirsayac != mat.GetLength(1) - 2 || arz_sifirsayac != mat.GetLength(0) - 2)
            {
                //Programdaki Tüm arz ve talebin 0 olmadığı ve programın çalışmaya devam ettiği durum
                return true;

            }
            else
            {
                //Programın Bittiği durum
                return false;
            }
            /* while (true)
             {
                 if (talep_sifirsayac != mat.GetLength(1) - 1 || arz_sifirsayac != mat.GetLength(0) - 1)
                 {

                     satir_sutun_ceza_hesapla(mat, boolarray, maxsatircezasi, maxsutuncezasi, satircezasilist, sutuncezasilist);
                     break;
                 }
                 else
                 {
                     MessageBox.Show("Program Bitti");
                     break;
                 }
             }
            */
        }
        int sayacclick = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sayacclick < (Matris_x + Matris_y) - 1)
            {
                minnHesapla(matris, Matris_x, Matris_y);

            }
            else if (sayacclick == (Matris_x + Matris_y) - 1)
            {
                Label l1 = new Label();
                l1.Location = new Point(100, 552);
                l1.Width = 500;
                l1.Font = new Font("Consolas", 24, FontStyle.Bold);
                if (sonucstring[sonucstring.Length - 1] == '+')
                {
                    sonucstring.Remove(sonucstring.Length - 1);
                    sonucstring += "= ";
                    sonucstring += sonuc.ToString();
                }
                l1.Text = sonuc.ToString();
                this.Controls.Add(l1);
            }

            sayacclick++;
        }
    }
}
