using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class Zahranici : UserControl
    {
        public Zahranici()
        {
            InitializeComponent();
            StazeniDat();
        }

        List<string> staty;

        private void StazeniDat()
        {
            string url = "https://www.mfcr.cz/cs/kontrola-a-regulace/legislativa/legislativni-dokumenty/2023/vyhlaska-c-341-2023-sb-53892";

            // Stežení obsahu webu
            string htmlObsah = StahniHtml(url);
            staty = VyberData(htmlObsah);
        }

        private static string StahniHtml(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }

        private static List<string> VyberData(string htmlContent)
        {
            List<string> staty = new List<string>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.OptionDefaultStreamEncoding = Encoding.UTF8;
            doc.LoadHtml(htmlContent);

            // Vyberu elementy z webu s tagem <tr>
            var castiWebu = doc.DocumentNode.SelectNodes("//tr");

            if (castiWebu != null)
            {
                foreach (var node in castiWebu)
                {
                    // Vyberu jednotlive objekty z webu pomoci hledani stylu na webove strance
                    string nazevStatu = HttpUtility.HtmlDecode(node.SelectSingleNode(".//td[@class='leftAlign']")?.InnerText?.Trim());
                    string mena = HttpUtility.HtmlDecode(node.SelectSingleNode(".//td[@class='centerAlign']")?.InnerText?.Trim());

                    string styleTag = node.SelectSingleNode(".//td[@class='centerAlign'][@style='white-space:nowrap']")?.InnerText?.Trim();

                    int cenaStatu;
                    // Naplnim promennou, pokud nastane selhani nastavi se na 0
                    if (!int.TryParse(styleTag, out cenaStatu))
                    {
                        cenaStatu = 0; 
                    }

                    // Kontrola jestli se naslo jmeno statu
                    if (!string.IsNullOrEmpty(nazevStatu))
                    {
                        staty.Add(nazevStatu + " " + cenaStatu + " " + mena);
                    }
                }
            }
            return staty;
        }

        Panel panelZeme;


        public void Vygeneruj(int pocet)        //Vygeneruje ovládací prvky pro určitý počet navštívených zemí
        {
            this.Controls.Clear();
            for (int i = 0; i < pocet; i++)
            {
                panelZeme = new Panel();
                panelZeme.Width = 500;
                panelZeme.Name = "panelZeme" + i;
                panelZeme.Height = 150;
                panelZeme.Location = new Point(10, (panelZeme.Height + 10) * i);

                ComboBox comboBoxVyberZeme = new ComboBox();
                Label labelVyberZeme = new Label();
                Label labelPrijezd = new Label();
                Label labelOdjezd = new Label();
                DateTimePicker datumPrijezdu = new DateTimePicker();   
                DateTimePicker casPrijezdu = new DateTimePicker();
                DateTimePicker datumOdjezdu = new DateTimePicker();
                DateTimePicker casOdjezdu = new DateTimePicker();

                // 
                // comboBox pro vybrání státu
                // 
                comboBoxVyberZeme.FormattingEnabled = true;
                comboBoxVyberZeme.Location = new Point(51, 17);
                comboBoxVyberZeme.Name = "comboBox1";
                comboBoxVyberZeme.Size = new Size(250, 21);
                comboBoxVyberZeme.TabIndex = 1;
                comboBoxVyberZeme.Items.AddRange(staty.ToArray());
                comboBoxVyberZeme.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxVyberZeme.SelectedIndex = 0;
                // 
                // label vyber zemi
                // 
                labelVyberZeme.AutoSize = true;
                labelVyberZeme.Location = new Point(48, 1);
                labelVyberZeme.Name = "label1";
                labelVyberZeme.Size = new Size(100, 15);
                labelVyberZeme.TabIndex = 2;
                labelVyberZeme.Text = "Vyberte zemi " + (i + 1);        
                // 
                // label prijezd
                // 
                labelPrijezd.AutoSize = true;
                labelPrijezd.Location = new Point(4, 65);
                labelPrijezd.Name = "label2";
                labelPrijezd.Size = new Size(41, 13);
                labelPrijezd.TabIndex = 4;
                labelPrijezd.Text = "Příjezd:";
                // 
                // label odjezd
                // 
                labelOdjezd.AutoSize = true;
                labelOdjezd.Location = new Point(4, 98);
                labelOdjezd.Name = "label3";
                labelOdjezd.Size = new Size(40, 13);
                labelOdjezd.TabIndex = 5;
                labelOdjezd.Text = "Odjezd:";
                if (i > 0)  //prijezdy po prvnim budou mi vlastnost enabled na false aby nesly upravit
                {
                    // 
                    // dateTimePicker pro datum prijezdu
                    // 
                    datumPrijezdu.Location = new Point(51, 63);
                    datumPrijezdu.Name = "dateTimePickerDatumPrijezdu";
                    datumPrijezdu.Size = new Size(200, 20);
                    datumPrijezdu.Enabled = false;
                    datumPrijezdu.TabIndex = 1;
                    // 
                    // dateTimePicker pro cas prijezdu
                    // 
                    casPrijezdu.Format = DateTimePickerFormat.Time;
                    casPrijezdu.Location = new Point(257, 63);
                    casPrijezdu.Name = "dateTimePickerCasPrijezdu";
                    casPrijezdu.Size = new Size(200, 20);
                    casPrijezdu.Enabled = false;
                    casPrijezdu.TabIndex = 2;
                }
                else
                {
                    // 
                    // dateTimePicker pro datum prijezdu
                    // 
                    datumPrijezdu.Location = new Point(51, 63);
                    datumPrijezdu.Name = "dateTimePickerDatumPrijezdu";
                    datumPrijezdu.Size = new Size(200, 20);
                    datumPrijezdu.TabIndex = 1;
                    // 
                    // dateTimePicker pro cas prijezdu
                    // 
                    casPrijezdu.Format = DateTimePickerFormat.Time;
                    casPrijezdu.Location = new Point(257, 63);
                    casPrijezdu.Name = "dateTimePickerCasPrijezdu";
                    casPrijezdu.Size = new Size(200, 20);
                    casPrijezdu.TabIndex = 2;
                }
                // 
                // dateTimePicker pro datum odjezdu
                // 
                datumOdjezdu.Location = new Point(51, 96);
                datumOdjezdu.Name = "dateTimePickerDatumOdjezd";
                datumOdjezdu.Size = new Size(200, 20);
                datumOdjezdu.TabIndex = 3;
                datumOdjezdu.ValueChanged += PrenastavHodnotu;
                // 
                // dateTimePicker pro cas odjezdu
                // 
                casOdjezdu.Format = DateTimePickerFormat.Time;
                casOdjezdu.Location = new Point(257, 96);
                casOdjezdu.Name = "dateTimePickerCasOdjezd";
                casOdjezdu.Size = new Size(200, 20);
                casOdjezdu.TabIndex = 4;
                casOdjezdu.ValueChanged += PrenastavHodnotu;


                panelZeme.Controls.Add(comboBoxVyberZeme);

                panelZeme.Controls.Add(datumPrijezdu);
                panelZeme.Controls.Add(casPrijezdu);

                panelZeme.Controls.Add(datumOdjezdu);
                panelZeme.Controls.Add(casOdjezdu);

                panelZeme.Controls.Add(labelVyberZeme);
                panelZeme.Controls.Add(labelPrijezd);
                panelZeme.Controls.Add(labelOdjezd);

                this.Controls.Add(panelZeme);


            }

        }

        private void PrenastavHodnotu(object sender, EventArgs e)
        {
            DateTimePicker zmenenyDTP = (DateTimePicker)sender; // najdu si původní datetimepicker

            // najdu si jeho nadřazený panel
            Panel panelRodic = (Panel)zmenenyDTP.Parent;

            // ziskam si index nadřazeného panelu
            int indexPanelu = int.Parse(panelRodic.Name.Replace("panelZeme", ""));

            // zkontroluju jestli to není poslední panel
            if (indexPanelu < this.Controls.Count - 1)
            {
                // najdu následující panel
                Panel nasledujiciPanel = (Panel)this.Controls.Find("panelZeme" + (indexPanelu + 1), true)[0];

                DateTimePicker nasledujiciPrijezd;
                if (zmenenyDTP.Name== "dateTimePickerDatumOdjezd")
                {
                    // najdu v něm datetimepicker podle názvu
                    nasledujiciPrijezd = (DateTimePicker)nasledujiciPanel.Controls.Find("dateTimePickerDatumPrijezdu", true)[0];

                }
                else
                {
                    nasledujiciPrijezd = (DateTimePicker)nasledujiciPanel.Controls.Find("dateTimePickerCasPrijezdu", true)[0];
                }

                // přiřadím mu jeho hodnotu
                nasledujiciPrijezd.Value = zmenenyDTP.Value;
            }
        }

    }
}
