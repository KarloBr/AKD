using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using Csv;


namespace AKD_zadatak_Karlo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            


        }

        public static void Glavni(string izvorPath, string odljevPath)
        {

            string[] files = Directory.GetFiles(izvorPath, "*", SearchOption.TopDirectoryOnly);
            
            foreach (string datoteka in files)
            {

                FileInfo fileInfoFile = new FileInfo(datoteka);

                if (fileInfoFile.Extension == ".csv")
                {
                    Console.WriteLine(datoteka);
                    CopyCSVFile(datoteka, odljevPath);
                }
                else if (fileInfoFile.Extension == ".xml")
                {
                    Console.WriteLine(datoteka);
                    CopyXMLFile(datoteka, odljevPath);
                }

            }

            MessageBox.Show("Gotovo");
            Application.Exit();
        }





        static void GenerateCSVFileOUT(string odljevPath)
        {
            File.AppendAllText(String.Format("{0}\\Odrediste.csv", odljevPath), "šifra;naziv;mjesto troška;datum aktivacije;smještaj\n", System.Text.Encoding.UTF8);
        }

        //------------------------------------------

        static void CopyXMLFile(string datoteka, string odljevPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(datoteka);

            XmlNodeList sifraL = xmlDoc.GetElementsByTagName("šifra");
            XmlNodeList nazivL = xmlDoc.GetElementsByTagName("naziv");
            XmlNodeList mjestoL = xmlDoc.GetElementsByTagName("mjesto_troška");
            XmlNodeList datumL = xmlDoc.GetElementsByTagName("datum_aktivacije");
            XmlNodeList smjestajL = xmlDoc.GetElementsByTagName("smještaj");


            var list = new List<Contact>();

            for (int i = 0; i < smjestajL.Count; i++)
            {
                var contact = new Contact()
                {
                    Smjestaj = smjestajL[i].InnerText.ToString(),
                    Datum = datumL[i].InnerText.ToString(),
                    Naziv = nazivL[i].InnerText.ToString(),
                    MjestoTroska = mjestoL[i].InnerText.ToString(),
                    Sifra = sifraL[i].InnerText.ToString()
                };
                list.Add(contact);

                Console.WriteLine(
                  $"{sifraL[i].InnerText.ToString()}\t{nazivL[i].InnerText.ToString()}\t{mjestoL[i].InnerText.ToString()}\t{datumL[i].InnerText.ToString()}\t{smjestajL[i].InnerText.ToString()}");

            }


            string[] sveSifre = new string[smjestajL.Count];

            if (!File.Exists(String.Format("{0}\\Odrediste.csv", odljevPath)))
            {
                GenerateCSVFileOUT(odljevPath);
            }


            foreach (var c in list)
            {

                if (KriviDatum(c.Datum) || JeLiDvojnik(odljevPath, c.Sifra))
                {
                    File.AppendAllText(String.Format("{0}\\Neispravna_Imovina.csv", odljevPath), $"\n{c.Sifra};{c.Naziv};{c.MjestoTroska};{c.Datum};{c.Smjestaj}", System.Text.Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(String.Format("{0}\\Odrediste.csv", odljevPath), $"{c.Sifra};{c.Naziv};{c.MjestoTroska};{c.Datum};{c.Smjestaj}\n", System.Text.Encoding.UTF8);
                }

            }
        }


        //------------------------------------------------------------------


        static void CopyCSVFile(string datoteka, string odljevPath)
        {
            var lines = File.ReadAllLines(datoteka, System.Text.Encoding.UTF8);

            var list = new List<Contact>();

            int brojTZ = 0;
            brojTZ = lines[0].Count(f => (f == ';'));

            char razvdajac;
            if (brojTZ > 0)
                razvdajac = ';';
            else
                razvdajac = '	';



            string[] zaglavlje = lines[0].Split(razvdajac);

            int Isifra = Array.IndexOf(zaglavlje, "�ifra");
            int Inaziv = Array.IndexOf(zaglavlje, "naziv");
            int ImjestoTroska = Array.IndexOf(zaglavlje, "mjesto tro�ka");
            int Idatum = Array.IndexOf(zaglavlje, "datum aktivacije");
            int Ismjestaj = Array.IndexOf(zaglavlje, "smje�taj");


            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(razvdajac);

                if (values.Length == 5)
                {
                    var contact = new Contact() { Smjestaj = values[Ismjestaj], Datum = values[Idatum], Naziv = values[Inaziv], MjestoTroska = values[ImjestoTroska], Sifra = values[Isifra] };
                    list.Add(contact);
                }
            }

            list.ForEach(x => Console.WriteLine($"{x.Sifra}\t{x.Naziv}\t{x.MjestoTroska}\t{x.Datum}\t{x.Smjestaj}"));

            string[] sveSifre = new string[lines.Length];

            if (!File.Exists(String.Format("{0}\\Odrediste.csv", odljevPath)))
            {
                GenerateCSVFileOUT(odljevPath);
            }

            
            foreach (var c in list)
            {
                
                if (KriviDatum(c.Datum) || JeLiDvojnik(odljevPath, c.Sifra))
                {
                    File.AppendAllText(String.Format("{0}\\Neispravna_Imovina.csv", odljevPath), $"\n{c.Sifra};{c.Naziv};{c.MjestoTroska};{c.Datum};{c.Smjestaj}", System.Text.Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(String.Format("{0}\\Odrediste.csv", odljevPath), $"{c.Sifra};{c.Naziv};{c.MjestoTroska};{c.Datum};{c.Smjestaj}\n", System.Text.Encoding.UTF8);
                }

            }
        }


        //-----------------------------------------------

        static bool KriviDatum(string datum)
        {
            if (!(Regex.IsMatch(datum, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}")))
            {
                return true;
            }

            var values = datum.Split('.');

            int dan = int.Parse(values[0]);
            int mjesec = int.Parse(values[1]);

            int[] mjeseci30 = {4,6,9,11};

            if (dan > 31 || dan < 1 || mjesec > 12 || mjesec < 1 ||
                (mjeseci30.Contains(mjesec) && dan==31) || (mjesec==2 && dan>29))
            {
                return true;
            }

            return false;
        }


        static bool JeLiDvojnik(string odljevPath, string sifra)
        {

            if (!File.Exists(String.Format("{0}\\Odrediste.csv", odljevPath)))
            {
                return false;
            }
       
            var lines = File.ReadAllLines(String.Format("{0}\\Odrediste.csv", odljevPath), System.Text.Encoding.UTF8);

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(';');

                if (sifra == values[0])
                {
                    return true;
                }
            }

            return false;
        }

    }

    public class Contact
    {
        public string Smjestaj { get; set; }
        public string Datum { get; set; }
        public string Naziv { get; set; }
        public string MjestoTroska { get; set; }
        public string Sifra { get; set; }
    }
}
