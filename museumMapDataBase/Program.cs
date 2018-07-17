using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace museumMapDataBase
{
    static class Program
    {
        //table-names
        public const string t_intezmeny = "Intezmeny";
        
        public const string t_intezmenyMegjegyzesek = "MegjegyzesekIntezmeny";

        public const string t_kontakt = "Kontakt";
        public const string t_program_kontakt = "Program";

        public const string t_csatlakozasGyujt = "CsatlakozasGyujtemeny";
        public const string t_csatlakozasSzakanyagok = "CsatlakozasSzakanyagok";

        public const string t_feltoltesRekordok = "FeltoltesRekordok";
        public const string t_feltoltesKepes = "FeltoltesKepesRekordok";
        public const string t_feltoltesEuropeana = "FeltoltesEuropeana";
        public const string t_feltoltesVirtualis = "FeltoltesVirtualis";
        public const string t_feltoltesMegjegyzes = "FeltoltesMegjegyzes";
       

        public const string t_kapcsolatfelvetel = "Kapcsolatfelvetel";
        public const string t_peas = "Peas";

        

        // column names
       
        public const string c_id = "ID";

        public const string c_inev = "Intezmeny_Neve";
        public const string c_szekhely = "Szekhely";
        public const string c_levelezesi = "Levelezesi_cim";
        public const string c_szerzodes = "Szerzodeskotes_datuma";
        public const string c_iktato = "Iktato_szam";
        public const string c_europeana = "Europeana_csatlakozassal";
        public const string c_onlineData = "Online_data_hasznalattal";
        public const string c_kozfog = "Kozfoglalkoztatasi_programban_reszt_vesz";
        public const string c_partner = "Partner";

        public const string c_intezmKepv = "Intezmeny_kepviseloje";

       
        public const string c_megjIntezmeny = "Megjegyzes1";
        public const string c_megjFeltoltes = "Megjegyzes2";

        public const string c_kontakt = "Kontakt_neve";
        public const string c_kontaktEmail = "E_mail";
        public const string c_progKontakt = "Programok_kontaktneve";
        public const string c_progEmail = "E_mail";

        
       
        public const string c_gyujtemeny = "Gyujtemenykezelo_rendszer";
        public const string c_szakanyagok = "Szakanyagok";

        public const string c_feltoltott = "Feltoltott_rekordok_szama";
        public const string c_feltoltesDatum = "Feltoltes_datuma";
        public const string c_feltoltottKepes = "Feltoltott_kepes_rekordok_szama";
        public const string c_europeanaFrissites = "Europeana_frissites_idopontja";
        public const string c_virtualis = "Virtualis_kiallitasok_feltoltesenek_datuma";
        
        public const string c_kapcsolatFelvDatum = "Kapcsolatfelvetel_datuma";
        public const string c_leiras = "Leiras";
        public const string c_peas = "Peas_bejegyzes";


        static void DBInit()
        {
            List<string> commands = new List<string>();

           SQLiteConnection.CreateFile("MuseumMapDB.sqlite");

           SQLiteConnection m_dbConnection;

           m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
           m_dbConnection.Open();

           commands.Add( "create table "+ t_intezmeny + " ("+c_id+" varchar(20),"+ c_inev+" varchar(20),"+ c_szekhely+" varchar(20),"+ c_levelezesi+" varchar(20),"+
                c_intezmKepv + " varchar(20)," +  c_szerzodes +" varchar(20),"+ c_iktato+" varchar(20),"+c_europeana+" varchar(20),"+c_onlineData +" varchar(20),"+
               c_kozfog+" varchar(20),"+ c_partner+ " varchar(20) )");

          

           commands.Add("create table " +t_kontakt+" ("+c_id+" varchar(20),"+c_kontakt+" varchar(20),"+c_kontaktEmail+" varchar(20) )");

           commands.Add("create table " +t_program_kontakt+" ("+c_id+" varchar(20),"+c_progKontakt+" varchar(20),"+c_progEmail+" varchar(20) )" );

           commands.Add("create table " +t_csatlakozasGyujt+" ("+c_id+" varchar(20),"+c_gyujtemeny+" varchar(20) ) ");

           commands.Add("create table " + t_csatlakozasSzakanyagok + " (" + c_id + " varchar(20), "  + c_szakanyagok + " varchar(20) )");


           commands.Add("create table " +t_feltoltesRekordok+" ("+c_id+" varchar(20),"+c_feltoltott+" varchar(20),"+
               c_feltoltesDatum+" varchar(20) )");
            commands.Add("create table " + t_feltoltesKepes + " (" + c_id + " varchar(20),"  +c_feltoltottKepes + " varchar(20))");

            commands.Add("create table " + t_feltoltesEuropeana + " (" + c_id + " varchar(20),"  + c_europeanaFrissites + " varchar(20))");

            commands.Add("create table " + t_feltoltesVirtualis + " (" + c_id + " varchar(20),"+ c_virtualis + " varchar(20))");

            commands.Add("create table " + t_feltoltesMegjegyzes + " (" + c_id + " varchar(20)," + c_megjFeltoltes + " varchar(20))");

            commands.Add( "create table " +t_kapcsolatfelvetel+ " ("+c_id+" varchar(20),"+c_kapcsolatFelvDatum+" varchar(20),"+c_leiras + " varchar(20))" );

            commands.Add("create table " + t_peas + " (" + c_id + " varchar(20)," + c_peas + " varchar(20) )");

            commands.Add( "create table " +t_intezmenyMegjegyzesek +" ("+c_id+" varchar(20),"+c_megjIntezmeny+" varchar(20))");


            for (int i = 0; i < commands.Count; i++) {
                SQLiteCommand command = new SQLiteCommand(commands[i], m_dbConnection);
                command.ExecuteNonQuery();
            }
           


            m_dbConnection.Close();

        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists("MuseumMapDB.sqlite") == false)
                DBInit();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        

        }
    }
}
