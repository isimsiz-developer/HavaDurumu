using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace havadurumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory ;
            label2.Text="Tarih: "+DateTime.Now.ToShortDateString();
            label3.Text="Saat: "+ DateTime.Now.ToShortTimeString();
            string api = "6246b269c981521ee72552d0c3ca1b57";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Mersin,33960&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument weadther = XDocument.Load(connection);
            var temp = weadther.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var havaDurum = weadther.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var rüzgar_hızı = weadther.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var Esinti = weadther.Descendants("gusts").ElementAt(0).Attribute("value").Value;
            var yönü = weadther.Descendants("direction").ElementAt(0).Attribute("name").Value;
            var Nem= weadther.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var basınc= weadther.Descendants("pressure").ElementAt(0).Attribute("value").Value;
            var gündoğ= weadther.Descendants("sun").ElementAt(0).Attribute("rise").Value;
            var günbat= weadther.Descendants("sun").ElementAt(0).Attribute("set").Value;
           var his1= weadther.Descendants("feels_like").ElementAt(0).Attribute("value").Value;



            his.Text="Hissedilen sıcaklık: "+his1.ToString();
            bat.Text = "Gün Batımı: " + günbat.ToString();
            doğ.Text = "Gün Doğumu: " + (gündoğ).ToString();
            basınç.Text="Basınç: "+basınc.ToString()+ " hPa";
            nem.Text= "Nem: %"+ Nem.ToString();
            hız.Text = "Hızı: "+rüzgar_hızı.ToString()+"m/s";
            esinti.Text="Esinti: "+Esinti.ToString();
            yön.Text="Yönü: "+yönü.ToString();
            label4.Text=temp.ToString();
            label5.Text=havaDurum.ToString();
            switch (label5.Text)
            { case("parçalı bulutlu"):
                    string resimYolu = Path.Combine(uygulamaDizini, "hava\\pracalı.png");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image resim = Image.FromFile(resimYolu);
                    pictureBox1.Image = resim;
                    break;
                case ("kapalı"):
                    string resimYolu1 = Path.Combine(uygulamaDizini, "hava\\kapalı.png");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image resim1 = Image.FromFile(resimYolu1);
                    pictureBox1.Image = resim1;
                    break;
                case ("açık"):
                    string resimYolu2 = Path.Combine(uygulamaDizini, "hava\\Açık.png");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image resim2 = Image.FromFile(resimYolu2);
                    pictureBox1.Image = resim2;
                    break;
                case ("az bulutlu"):
                    string resimYolu3 = Path.Combine(uygulamaDizini, "hava\\pracalı.png");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image resim3 = Image.FromFile(resimYolu3);
                    pictureBox1.Image = resim3;
                    break;
                default:
                    break;
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
