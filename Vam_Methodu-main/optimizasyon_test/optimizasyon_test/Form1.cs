using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace optimizasyon_test
{
    public partial class Form1 : Form
    {
        public List<List<TextBox>> textboxmatris = new List<List<TextBox>>();
        
        public int matris_x=0;
        public int matris_y=0;
        public int artis = 0;
        public string temp_item;
        public Form1()
        {

            InitializeComponent();
        }
        //Dinamik olarak oluşturulan textboxların sadece nümerik ifadeleri kabul etmesini sağlayan event.
        void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            //Fabrika ve Şehir sayısının boş oluo olmadığı kontrol edildi.
            if (fabrika_input.Text == "")
            {
                MessageBox.Show("Fabrika sayısı boş olamaz!");
            }
            if (sehir_input.Text == "")
            {
                MessageBox.Show("Şehir sayısı boş olamaz!");
            }
            int tempx = 0;
            int tempy = 0;
        
            //Eğer fabrika ve şehir sayısı boş değilse işlemlere başlandı.
            if (fabrika_input.Text != "" && sehir_input.Text != "")
            {

                if (Convert.ToInt32(fabrika_input.Text) <= 15 && Convert.ToInt32(sehir_input.Text) <= 15 && Convert.ToInt32(fabrika_input.Text) != 0 && Convert.ToInt32(sehir_input.Text) != 0)
                {
                  
                    matris_x = Convert.ToInt32(fabrika_input.Text);
                    matris_y = Convert.ToInt32(sehir_input.Text);
                   
                  //Değerler formundan bir nesne oluşturulup oluşturulacak iki boyutlu dizinin boyutları Değerler formuna atandı.
                    degerler deger = new degerler(matris_x,matris_y, textboxmatris);
                    deger.Value_x = matris_x;
                    deger.Value_y = matris_y;
                //////////////////////////////////////


                    TextBox[] line = new TextBox[(matris_x) + 1];
                    TextBox[] column = new TextBox[(matris_y) + 1];
                    Label[] baslikdizisi = new Label[(matris_x) + 1];
                    Label[] basliksehirr = new Label[(matris_y) + 1];

                    //Dinamik textboxlar oluşturuldu ve gerekli propertyler atandı.
                    //Sütun kısmı
                    for (int i = 0; i < line.Length; i++)
                    {
                    
                        var baslik = new Label();
                       
                        baslikdizisi[i] = baslik;
                        baslik.Width = 75;
                        baslik.Height = 25;
                        baslik.Visible = true;
                        baslik.Name = "baslik";
                        baslik.Location = new Point(25, 50 + artis);
                        baslik.Text = "F" + (i + 1).ToString();
                    
                       
                        deger.Controls.Add(baslik);
                       
                     
                        //Talep Yazdıran Kısım
                        if (i+1  == line.Length)
                        {
                           
                            baslikdizisi[i] = baslik;
                            baslik.Width = 75;
                            baslik.Height = 25;
                         
;                            baslik.Visible = true;
                            baslik.Location = new Point(25, 50 + artis);
                            baslik.Text = "Talep";
                          

                            deger.Controls.Add(baslik);
                        
                         
                            //Çakışma durumundaki textboxın y koordinatı bir değişkene atandı.
                            tempy = 50 + artis;
                        }


                        textboxmatris.Add(new List<TextBox>());
                    
                        //Satır Kısmı
                        for (int j = 0; j < column.Length; j++)
                        {
                            
                            var txtt = new TextBox();
                         
                            var basliksehir = new Label();
                            basliksehirr[j] = basliksehir;
                            basliksehir.Width = 25;
                            basliksehir.Height = 25;
                            basliksehir.Text = (j + 1).ToString();
                            basliksehir.Visible = true;
                            if(i+1<line.Length)
                            {
                                txtt.Name = "input";
                            }
                            else
                            {
                                txtt.Name = "Talep";
                            }

                            basliksehir.Location = new Point(100 + (j) * 32, 10);
                            deger.Controls.Add(basliksehir);
                           
                            txtt.KeyPress += txt_KeyPress;
                            column[j] = txtt;
                            txtt.Width = 25;
                            txtt.Height = 25;
                            txtt.Location = new Point(100 + (j * 32), 50 + artis);
                            txtt.Visible = true;
                           
                            deger.Controls.Add(txtt);

                        
                            //Arz Yazdıran Kısım
                            if (j + 1 == column.Length)
                            {
                                txtt.Name = "Arz";
                               
                                basliksehirr[j] = basliksehir;
                                basliksehir.Width = 50;
                                basliksehir.Height = 25;
                                basliksehir.Visible = true;
                                basliksehir.Location = new Point(100 + (j) * 32, 10);
                                basliksehir.Text = "Arz";       
                                deger.Controls.Add(basliksehir);
                                //Çakışma durumundaki textboxın x koordinatı bir değişkene atandı.
                                tempx = 100 + (j * 32);
                            }
                             

                            textboxmatris[i].Add(txtt);
                            
                        }
                        artis += 40;
                   

                    }
                  
                    //Arz ve Talebin Çakışma noktasındaki textbox Silindi
                    foreach (Control item in deger.Controls)
                    {
                        if (item.Location.X == tempx && item.Location.Y == tempy)
                        {
                            item.Text = "";
                            deger.Controls.Remove(item);
                            break; 
                        }
                    }
                   
                    deger.Show();
                    this.Hide();

                   

                }

                else
                {
                    MessageBox.Show("Matris boyutları hatalı!");
                }

            }

        }

        
        private void fabrika_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void fabrika_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }

        private void sehir_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
