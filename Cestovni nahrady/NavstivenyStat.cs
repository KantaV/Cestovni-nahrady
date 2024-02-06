using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    internal class NavstivenyStat
    {
        private string nazevStatu="";
        private string mena = "";
        private int cenaZaDenVeStateVZahrMene = 0;
        private TimeSpan casVeState=TimeSpan.Zero;
        private DateTime datumPrijezdu=DateTime.Now;
        private DateTime datumOdjezdu=DateTime.Now;
        private double cenaZaDenVeStatePrevedeno = 0;

        public string NazevStatu
        {
            get { return nazevStatu;}
            set { nazevStatu = value;}
        }

        public TimeSpan CasVeState
        { 
            get { return casVeState;}
            set { casVeState = value;}
        }

        public DateTime DatumPrijezdu
        {
            get { return datumPrijezdu;}
            set { datumPrijezdu = value;}
        }

        public DateTime DatumOdjezdu
        {
            get { return datumOdjezdu;}
            set { datumOdjezdu = value;}
        }

        public double CeZaDenVeStatePrevedeno
        {
            get { return cenaZaDenVeStatePrevedeno; }
        }

        public NavstivenyStat(string nazevStatu,  int cena, string mena, DateTime datumPrijezdu, DateTime datumOdjezdu)
        {
            this.nazevStatu = nazevStatu;
            this.cenaZaDenVeStateVZahrMene = cena;
            this.mena = mena;
            this.datumPrijezdu = datumPrijezdu;
            this.datumOdjezdu = datumOdjezdu;
            if (datumOdjezdu >= datumPrijezdu)
            {
                this.casVeState = datumOdjezdu - datumPrijezdu;
                switch (mena)
                {
                    case "EUR":{
                        double kurz = ZiskejKurz("https://www.kurzy.cz/kurzy-men/nejlepsi-kurzy/EUR-euro");
                        this.cenaZaDenVeStatePrevedeno = cenaZaDenVeStateVZahrMene * kurz;
                        //MessageBox.Show("EURO" + kurz);
                        break;
                    }
                    case "USD":
                    {
                        double kurz = ZiskejKurz("https://www.kurzy.cz/kurzy-men/nejlepsi-kurzy/USD-americky-dolar");
                        this.cenaZaDenVeStatePrevedeno = cenaZaDenVeStateVZahrMene * kurz;
                        //MessageBox.Show("USD" + kurz);
                        break;
                    }
                    case "GBP":
                    {
                        double kurz = ZiskejKurz("https://www.kurzy.cz/kurzy-men/nejlepsi-kurzy/GBP-britska-libra/");
                        this.cenaZaDenVeStatePrevedeno = cenaZaDenVeStateVZahrMene * kurz;
                        //MessageBox.Show("GBP" + kurz);
                        break;
                    }
                    case "CHF":
                    {
                        double kurz = ZiskejKurz("https://www.kurzy.cz/kurzy-men/nejlepsi-kurzy/CHF-svycarsky-frank/");
                        this.cenaZaDenVeStatePrevedeno = cenaZaDenVeStateVZahrMene * kurz;
                        //MessageBox.Show("CHF" + kurz);
                        break;
                    }
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Datum návratu domů z pracovní cesty nemůže být před datem začátku!");
            }
        }

       private double ZiskejKurz(string url)
        {
            // Stežení obsahu webu
            string htmlObsah = DownloadHtml(url);
            return ParseHtml(htmlObsah);
        }

        private static string DownloadHtml(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }

        private static double ParseHtml(string htmlContent)
        {
            double kurz = 0;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.OptionDefaultStreamEncoding = System.Text.Encoding.UTF8;
            doc.LoadHtml(htmlContent);

            // Vyberu span se třídou "clrred"
            var clrredNode = doc.DocumentNode.SelectSingleNode("//span[@class='clrred']");

            if (clrredNode != null)
            {
                kurz = double.Parse(PrevedTeckyNaCarky(clrredNode.InnerText?.Trim()));
            }

            return kurz;
        }

        private static string PrevedTeckyNaCarky(string vstup)
        {
            //Tato metoda je potřeba protože string desetinneho cisla ve tvaru
            // 5.156416 nelze prevest, je potreba 5,156416
            string upraveny = new string(vstup?.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            upraveny = upraveny.Replace('.', ',');
            return upraveny;
        }

    }
}
