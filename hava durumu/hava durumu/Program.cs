using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hava_durumu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string api = "6246b269c981521ee72552d0c3ca1b57";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Mersin,33960&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument weadther = XDocument.Load(connection);
            var temp=weadther.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var havaDurum= weadther.Descendants("weather").ElementAt(0).Attribute("value").Value;
            Console.WriteLine("Silifke İçin Sıcaklık= "+temp+"   ---> Hava Durumu: "+havaDurum);

            Console.ReadLine();
        }
    }
}
