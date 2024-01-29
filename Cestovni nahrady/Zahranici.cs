using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class Zahranici : UserControl
    {
        public Zahranici()
        {
            InitializeComponent();
        }

        Panel panelZeme;


        string[] statyZeme = {
            "Afghánistán", "Albánie", "Alžírsko", "Andorra", "Angola", "Argentina", "Arménie", "Austrálie a Oceánie – ostrovní státy",
            "Ázerbájdžán", "Bahamy", "Bahrajn", "Bangladéš", "Belgie", "Belize", "Benin", "Bermudy", "Bělorusko", "Bhútán", "Bolívie",
            "Bosna a Hercegovina", "Botswana", "Brazílie", "Brunej", "Bulharsko", "Burkina Faso", "Burundi", "Čad", "Černá Hora", "Čína",
            "Dánsko", "Džibutsko", "Egypt", "Ekvádor", "Eritrea", "Estonsko", "Etiopie", "Filipíny", "Finsko", "Francie", "Francouzská Guyana",
            "Gabon", "Gambie", "Ghana", "Gibraltar", "Gruzie", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Honduras", "Hongkong",
            "Chile", "Chorvatsko", "Indie", "Indonésie", "Irák", "Írán", "Irsko", "Island", "Itálie, Vatikán a San Marino", "Izrael",
            "Japonsko", "Jemen", "Jihoafrická republika", "Jižní Súdán", "Jordánsko", "Kambodža", "Kamerun", "Kanada", "Kapverdy",
            "Karibik – ostrovní státy", "Katar", "Kazachstán", "Keňa", "Kolumbie", "Komory", "Konžská republika (Brazzaville)",
            "Konžská demokratická republika (Kinshasa)", "Korejská lidově demokratická republika", "Korejská republika", "Kosovo",
            "Kostarika", "Kuba", "Kuvajt", "Kypr", "Kyrgyzstán", "Laos", "Lesotho", "Libanon", "Libérie", "Libye", "Lichtenštejnsko",
            "Litva", "Lotyšsko", "Lucembursko", "Macao", "Madagaskar", "Maďarsko", "Malajsie", "Malawi", "Maledivy", "Mali", "Malta",
            "Maroko", "Mauretánie", "Mauricius", "Mexiko", "Moldavsko", "Monako", "Mongolsko", "Mosambik", "Myanmar (Barma)", "Namibie",
            "Německo", "Nepál", "Niger", "Nigérie", "Nikaragua", "Nizozemsko", "Norsko", "Nový Zéland", "Omán", "Pákistán", "Panama",
            "Paraguay", "Peru", "Pobřeží Slonoviny", "Polsko", "Portugalsko a Azory", "Rakousko", "Rovníková Guinea", "Rumunsko", "Rusko",
            "Rwanda", "Řecko", "Salvador", "Saúdská Arábie", "Senegal", "Severní Makedonie", "Seychely", "Sierra Leone", "Singapur",
            "Spojené arabské emiráty", "Slovensko", "Slovinsko", "Somálsko", "Spojené státy americké", "Srbsko", "Srí Lanka", "Středoafrická republika",
            "Súdán", "Surinam", "Svatý Tomáš a Princův ostrov", "Svazijsko", "Sýrie", "Španělsko", "Švédsko", "Švýcarsko", "Tádžikistán",
            "Tanzanie", "Thajsko", "Tchaj-wan", "Togo", "Tunisko", "Turecko", "Turkmenistán", "Uganda", "Ukrajina", "Uruguay", "Uzbekistán",
            "Velká Británie", "Venezuela", "Vietnam", "Zambie", "Zimbabwe"
        };


        public void Vygeneruj(int pocet)        //Vygeneruje ovládací prvky pro určitý počet navštívených zemí
        {
            this.Controls.Clear();
            for (int i = 0; i < pocet; i++)
            {
                panelZeme = new Panel();
                panelZeme.Width = 500;
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
                comboBoxVyberZeme.Items.AddRange(statyZeme);
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
                // 
                // dateTimePicker pro datum prijezdu
                // 
                datumPrijezdu.Location = new Point(51, 63);
                datumPrijezdu.Name = "dateTimePicker1";
                datumPrijezdu.Size = new Size(200, 20);
                datumPrijezdu.TabIndex = 1;
                // 
                // dateTimePicker pro cas prijezdu
                // 
                casPrijezdu.Format = DateTimePickerFormat.Time;
                casPrijezdu.Location = new Point(257, 63);
                casPrijezdu.Name = "dateTimePicker2";
                casPrijezdu.Size = new Size(200, 20);
                casPrijezdu.TabIndex = 2;
                // 
                // dateTimePicker pro datum odjezdu
                // 
                datumOdjezdu.Location = new Point(51, 96);
                datumOdjezdu.Name = "dateTimePicker3";
                datumOdjezdu.Size = new Size(200, 20);
                datumOdjezdu.TabIndex = 3;
                // 
                // dateTimePicker pro cas odjezdu
                // 
                casOdjezdu.Format = DateTimePickerFormat.Time;
                casOdjezdu.Location = new Point(257, 96);
                casOdjezdu.Name = "dateTimePicker4";
                casOdjezdu.Size = new Size(200, 20);
                casOdjezdu.TabIndex = 4;


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
    }
}
