using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace museumMapDataBase
{
    public partial class Urlap : Form
    {
        public Urlap()
        {
            InitializeComponent();

            LW_intezmenyMegj.View = View.Details;
            LW_intezmenyMegj.FullRowSelect = true;
            LW_intezmenyMegj.GridLines = true;
            LW_intezmenyMegj.Columns.Add("Megjegyzés", 500, HorizontalAlignment.Left);

            lw_kontakt.View = View.Details;
            lw_kontakt.FullRowSelect = true;
            lw_kontakt.GridLines = true;
            lw_kontakt.Columns.Add("Kontakt neve", 150, HorizontalAlignment.Left);
            lw_kontakt.Columns.Add("E-mail cím", 180, HorizontalAlignment.Left);

            lw_progKontakt.View = View.Details;
            lw_progKontakt.FullRowSelect = true;
            lw_progKontakt.GridLines = true;
            lw_progKontakt.Columns.Add("Programok kontaktneve", 150, HorizontalAlignment.Left);
            lw_progKontakt.Columns.Add("E-mail cím", 180, HorizontalAlignment.Left);

            lw_gyujtemeny.View = View.Details;
            lw_gyujtemeny.FullRowSelect = true;
            lw_gyujtemeny.GridLines = true;
            lw_gyujtemeny.Columns.Add("Gyűjteménykezelő rendszer", 200, HorizontalAlignment.Left);

            lw_szakanyagok.View = View.Details;
            lw_szakanyagok.FullRowSelect = true;
            lw_szakanyagok.GridLines = true;
            lw_szakanyagok.Columns.Add("Szakanyagok", 200, HorizontalAlignment.Left);

            lv_kapcsolatfelvetel.View = View.Details;
            lv_kapcsolatfelvetel.FullRowSelect = true;
            lv_kapcsolatfelvetel.GridLines = true;
            lv_kapcsolatfelvetel.Columns.Add("Kapcsolatfelvétel dátuma", 134, HorizontalAlignment.Left);
            lv_kapcsolatfelvetel.Columns.Add("Leírás", 150, HorizontalAlignment.Left);

            lv_peas.View = View.Details;
            lv_peas.FullRowSelect = true;
            lv_peas.GridLines = true;
            lv_peas.Columns.Add("Peas bejegyzés", 250, HorizontalAlignment.Left);


            lv_feltoltottRekordok.View = View.Details;
            lv_feltoltottRekordok.FullRowSelect = true;
            lv_feltoltottRekordok.GridLines = true;
            lv_feltoltottRekordok.Columns.Add("Feltöltött rekordok száma", 150, HorizontalAlignment.Left);
            lv_feltoltottRekordok.Columns.Add("Feltöltés dátuma", 150, HorizontalAlignment.Left);

            lv_kepes.View = View.Details;
            lv_kepes.FullRowSelect = true;
            lv_kepes.GridLines = true;
            lv_kepes.Columns.Add("Feltöltött képes rekordok száma", 200, HorizontalAlignment.Left);

            lv_europeana.View = View.Details;
            lv_europeana.FullRowSelect = true;
            lv_europeana.GridLines = true;
            lv_europeana.Columns.Add("Europeana frissítés időpontja", 200, HorizontalAlignment.Left);

            lv_virtualis.View = View.Details;
            lv_virtualis.FullRowSelect = true;
            lv_virtualis.GridLines = true;
            lv_virtualis.Columns.Add("Virtuális kiállítások feltöltésének dátuma", 200, HorizontalAlignment.Left);

            lv_feltoltesMegjegyzes.View = View.Details;
            lv_feltoltesMegjegyzes.FullRowSelect = true;
            lv_feltoltesMegjegyzes.GridLines = true;
            lv_feltoltesMegjegyzes.Columns.Add("Megjegyzés", 170, HorizontalAlignment.Left);
        }
        
        private void addData(List<string> resultList, string fieldName, SQLiteDataReader reader)
        {

            if (reader[fieldName] != DBNull.Value)
            {
                resultList.Add((string)reader[fieldName]);
            }
            else
            {
                resultList.Add("");
            }

        }

    

        public void initUrlap(string id)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql;
            int numberOfResults;
            List<string> results = new List<string>();
            SQLiteCommand command;
            SQLiteDataReader reader;

            
            sql = "select " + Program.c_id + "," + Program.c_inev + "," + Program.c_szekhely
                + "," + Program.c_levelezesi+ "," + Program.c_intezmKepv +" from " + Program.t_intezmeny+ 
                " where " + Program.c_id + " like '" + id+ "'";

             command = new SQLiteCommand(sql, m_dbConnection);
             reader = command.ExecuteReader();


           
            while (reader.Read())
            {
                results.Add((string)reader[Program.c_id]);

                addData(results, Program.c_inev, reader);
                addData(results, Program.c_szekhely, reader);
                addData(results, Program.c_levelezesi, reader);
                addData(results, Program.c_intezmKepv, reader);
            }
            

           
            tb_id.Text = results[0];
            tb_inev.Text = results[1];
            tb_szekhely.Text = results[2];
            tb_levelezesi.Text = results[3];
            tb_intezmKepv.Text = results[4];

            results.Clear();

            
            sql = "select " + Program.c_id + "," + Program.c_szerzodes + "," + Program.c_iktato
           + "," + Program.c_europeana + "," + Program.c_onlineData
            + "," + Program.c_kozfog +","+Program.c_partner +  " from " + Program.t_intezmeny +
           " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_szerzodes, reader);
                addData(results, Program.c_iktato, reader);
                addData(results, Program.c_europeana, reader);
                addData(results, Program.c_onlineData, reader);
                addData(results, Program.c_kozfog, reader);
                addData(results, Program.c_partner, reader);
            }
            
            tb_szerzodes.Text = results[0];
            tb_iktato.Text = results[1];
            if( results[2].Equals("true")) 
            {
                cb_europeana.Checked = true;
            }

            if (results[3].Equals("true"))
            {
                cb_onlineData.Checked = true;
            }

            if (results[4].Equals("true"))
            {
                cb_kozfog.Checked = true;
            }

            if(results[5] != null)
                if (results[5].Equals("true"))
                {
                cb_Partner.Checked = true;
                }

            results.Clear();



            
            sql = "select " + Program.c_megjIntezmeny  + " from " + Program.t_intezmenyMegjegyzesek +
           " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_megjIntezmeny, reader);
            }

            numberOfResults = reader.StepCount;

            for (int i = 0; i < numberOfResults; i++)
            {
                if(results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[ i]});
                    LW_intezmenyMegj.Items.Add(item1);
                }               
            }

            results.Clear();



           
            sql = "select " + Program.c_kontakt +", "+ Program.c_kontaktEmail +" from " + Program.t_kontakt +
           " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_kontakt, reader);
                addData(results, Program.c_kontaktEmail, reader);
            }

            numberOfResults = reader.StepCount;
            for (int i = 0; i < numberOfResults; i++)
            {
                ListViewItem item1 = new ListViewItem(new[] { results[2 * i], results[2 * i + 1] });
                lw_kontakt.Items.Add(item1);
            }
            results.Clear();




            
            sql = "select " + Program.c_progKontakt + ", " + Program.c_progEmail + " from " + Program.t_program_kontakt +
        " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_progKontakt, reader);
                addData(results, Program.c_progEmail, reader);
               
            }

            numberOfResults = reader.StepCount;
                  
            for (int i = 0; i < numberOfResults; i++)
            {
                ListViewItem item1 = new ListViewItem(new[] { results[2 * i], results[2 * i + 1] });
                lw_progKontakt.Items.Add(item1);
            }
            results.Clear();




            
            sql = "select " + Program.c_gyujtemeny + " from " + Program.t_csatlakozasGyujt +
           " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_gyujtemeny, reader);
            }

            numberOfResults = reader.StepCount;

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lw_gyujtemeny.Items.Add(item1);
                }
                    
            }
            results.Clear();



            
            sql = "select " + Program.c_szakanyagok + " from " + Program.t_csatlakozasSzakanyagok +
           " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_szakanyagok, reader);
            }

            numberOfResults = reader.StepCount;
        

            for (int i = 0; i < numberOfResults; i++)
            {
                if(results[i].Equals("") == false)
                {
                ListViewItem item1 = new ListViewItem(new[] { results[i] });
                lw_szakanyagok.Items.Add(item1);
                }
               
            }

            results.Clear();



            sql = "select " + Program.c_kapcsolatFelvDatum + ", " + Program.c_leiras + " from " + Program.t_kapcsolatfelvetel+
       " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_kapcsolatFelvDatum, reader);
                addData(results, Program.c_leiras, reader);
            }

            numberOfResults = reader.StepCount;
                       
            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[2*i].Equals("") == false || results[2 * i +1].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[2 * i], results[2 * i + 1] });
                    lv_kapcsolatfelvetel.Items.Add(item1);
                }
                    
            }
            results.Clear();



            
            sql = "select " + Program.c_peas + " from " + Program.t_peas +
          " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_peas, reader);
            }

            numberOfResults = reader.StepCount;
        

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lv_peas.Items.Add(item1);
                }

            }

            results.Clear();


           
            sql = "select " + Program.c_feltoltott + ", " + Program.c_feltoltesDatum + " from " + Program.t_feltoltesRekordok +
       " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_feltoltott, reader);
                addData(results, Program.c_feltoltesDatum, reader);
            }

            numberOfResults = reader.StepCount;
       
            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[2 * i].Equals("") == false || results[2 * i + 1].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[2 * i], results[2 * i + 1] });
                    lv_feltoltottRekordok.Items.Add(item1);
                }

            }
            results.Clear();


           
            sql = "select " + Program.c_feltoltottKepes + " from " + Program.t_feltoltesKepes +
          " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_feltoltottKepes, reader);
            }

            numberOfResults = reader.StepCount;


            

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lv_kepes.Items.Add(item1);
                }

            }

            results.Clear();

          
            sql = "select " + Program.c_europeanaFrissites + " from " + Program.t_feltoltesEuropeana +
          " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_europeanaFrissites, reader);
            }

            numberOfResults = reader.StepCount;



            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lv_europeana.Items.Add(item1);
                }

            }

            results.Clear();



           
            sql = "select " + Program.c_virtualis + " from " + Program.t_feltoltesVirtualis +
          " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_virtualis, reader);
            }

            numberOfResults = reader.StepCount;


            

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lv_virtualis.Items.Add(item1);
                }

            }

            results.Clear();

          
            sql = "select " + Program.c_megjFeltoltes + " from " + Program.t_feltoltesMegjegyzes+
         " where " + Program.c_id + " like '" + id + "'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                addData(results, Program.c_megjFeltoltes, reader);
            }

            numberOfResults = reader.StepCount;


          

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[i].Equals("") == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[i] });
                    lv_feltoltesMegjegyzes.Items.Add(item1);
                }

            }
            results.Clear();





            m_dbConnection.Close();

        }


        private void b_intezmeny_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "select " + Program.c_id + "," + Program.c_inev + " from " + Program.t_intezmeny+" where "+
                Program.c_id+ " like '" + tb_id.Text+ "'";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> results = new List<string>();

            while (reader.Read())
            {
                results.Add((string)reader[Program.c_id]);
                results.Add((string)reader[Program.c_inev]);
            }
            if(results.Count == 0)
            {
                if(tb_id.Text.Length !=0) { 
                sql = "insert into " + Program.t_intezmeny + " (" + Program.c_id + "," + Program.c_inev + ","+
                   Program.c_szekhely +","+ Program.c_levelezesi+ "," + Program.c_intezmKepv +
                   ") values ('" +tb_id.Text + "','"+ tb_inev.Text+"','"+
                   tb_szekhely.Text+"','"+tb_levelezesi.Text + "','" + tb_intezmKepv.Text+"' )";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                } else
                {
                    MessageBox.Show("Azonosító mező nem lehet üres!", "MuseumDB App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                sql = "update " + Program.t_intezmeny + " set " + 
                    Program.c_inev + " = '" + tb_inev.Text + "' , "+
                    Program.c_szekhely + " = '" + tb_szekhely.Text + "' , "+
                    Program.c_levelezesi + " = '" + tb_levelezesi.Text + "' , " +
                    Program.c_intezmKepv + " = '" + tb_intezmKepv.Text + "' where " +
                    Program.c_id + " like '" + tb_id.Text + "'";
                  

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();


            }
           

            m_dbConnection.Close();



        }

        private void b_intezmenySzerzodes_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            bool[] cbResults = new bool[4];
            string[] cbResultValues = new string[4];

            cbResults[0] = cb_europeana.Checked;
            cbResults[1] = cb_onlineData.Checked;
            cbResults[2] = cb_kozfog.Checked;
            cbResults[3] = cb_Partner.Checked;


            for (int i = 0; i < 4; i++)
            {
                if (cbResults[i])
                {
                    cbResultValues[i] = "true";
                }
                else
                {
                    cbResultValues[i] = "false";
                }
            }

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "select " + Program.c_id + "," + Program.c_inev + " from " + Program.t_intezmeny + " where " +
                Program.c_id + " like '" + tb_id.Text + "'";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> results = new List<string>();

            while (reader.Read())
            {
                results.Add((string)reader[Program.c_id]);
                results.Add((string)reader[Program.c_inev]);
            }
            if (results.Count == 0)
            {

                
            

                MessageBox.Show("No museum exists with this ID:"+ tb_id.Text, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                sql = "update " + Program.t_intezmeny + " set " +
                    Program.c_szerzodes + " = '" + tb_szerzodes.Text + "' , " +
                    Program.c_iktato + " = '" + tb_iktato.Text + "' , " +
                    Program.c_europeana + " = '" + cbResultValues[0] + "' , " +
                    Program.c_onlineData + " = '" + cbResultValues[1] + "' , " +
                    Program.c_kozfog + " = '" + cbResultValues[2] + "' , " +
                    Program.c_partner + " = '" + cbResultValues[3] + "' where " +
                    Program.c_id + " like '" + tb_id.Text + "'";


                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();


            }


            m_dbConnection.Close();



        }

        

        private void b_megjIntezmeny_Click(object sender, EventArgs e)
        {

            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();


            string sql = "insert into " + Program.t_intezmenyMegjegyzesek + " (" + Program.c_id + "," + Program.c_megjIntezmeny + ") values ('"+ tb_id.Text+
                "','" + tb_megjIntezmeny.Text + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

            ListViewItem item1 = new ListViewItem(new[] { tb_megjIntezmeny.Text });
            LW_intezmenyMegj.Items.Add(item1);

            tb_megjIntezmeny.Clear();

        }

        private void b_kontakt_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();


            string sql = "insert into " + Program.t_kontakt + " (" + Program.c_id + "," + Program.c_kontakt+","+ Program.c_kontaktEmail + 
                ") values ('" + tb_id.Text + "','" + tb_kontakt.Text + "','" + tb_kontaktEmail.Text + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

            ListViewItem item1 = new ListViewItem(new[] { tb_kontakt.Text, tb_kontaktEmail.Text });
            lw_kontakt.Items.Add(item1);

            tb_kontakt.Clear();
            tb_kontaktEmail.Clear();

        }

        private void b_program_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();


            string sql = "insert into " + Program.t_program_kontakt + " (" + Program.c_id + "," + Program.c_progKontakt + "," + Program.c_progEmail +
                ") values ('" + tb_id.Text + "','" + tb_progKontakt.Text+ "','" + tb_progEmail.Text + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

            ListViewItem item1 = new ListViewItem(new[] { tb_progKontakt.Text, tb_progEmail.Text });
            lw_progKontakt.Items.Add(item1);

            tb_progKontakt.Clear();
            tb_progEmail.Clear();

        }

        private void b_csatlakozas_Click(object sender, EventArgs e)
        {

            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command;

            if (tb_gyujtemeny.Text.Length != 0)
            {

                string sql = "insert into " + Program.t_csatlakozasGyujt + " (" + Program.c_id + "," + Program.c_gyujtemeny + 
                ") values ('" + tb_id.Text + "','" + tb_gyujtemeny.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item1 = new ListViewItem(new[] { tb_gyujtemeny.Text });
                lw_gyujtemeny.Items.Add(item1);

            }


            if (tb_szakanyagok.Text.Length != 0)
            {

                string sql = "insert into " + Program.t_csatlakozasSzakanyagok + " (" + Program.c_id  + "," + Program.c_szakanyagok +
               ") values ('" + tb_id.Text  + "','" + tb_szakanyagok.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item2 = new ListViewItem(new[] { tb_szakanyagok.Text });
                lw_szakanyagok.Items.Add(item2);

            }
          
            m_dbConnection.Close();
           
            tb_gyujtemeny.Clear();
            tb_szakanyagok.Clear();

        }

        private void b_kapcsolatfelvetel_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            SQLiteCommand command;
            if (tb_kapcsolatFelvDatum.Text.Length != 0 || tb_leiras.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_kapcsolatfelvetel + " (" + Program.c_id + "," + Program.c_kapcsolatFelvDatum + "," + Program.c_leiras +
                ") values ('" + tb_id.Text + "','" + tb_kapcsolatFelvDatum.Text + "','" + tb_leiras.Text  + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item1 = new ListViewItem(new[] { tb_kapcsolatFelvDatum.Text, tb_leiras.Text });
                lv_kapcsolatfelvetel.Items.Add(item1);
            }

            if (tb_peas.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_peas + " (" + Program.c_id  + "," + Program.c_peas +
               ") values ('" + tb_id.Text + "','" + tb_peas.Text +  "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item2 = new ListViewItem(new[] { tb_peas.Text });
                lv_peas.Items.Add(item2);

            }

           

            m_dbConnection.Close();

            tb_kapcsolatFelvDatum.Clear();
            tb_leiras.Clear();
            tb_peas.Clear();

        }

        private void b_feltoltes_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command;


            if (tb_feltoltott.Text.Length != 0 || tb_feltoltesDatum.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_feltoltesRekordok + " (" + Program.c_id + "," + Program.c_feltoltott + "," + Program.c_feltoltesDatum +
                ") values ('" + tb_id.Text + "','" + tb_feltoltott.Text + "','" + tb_feltoltesDatum.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item1 = new ListViewItem(new[] { tb_feltoltott.Text, tb_feltoltesDatum.Text });
                lv_feltoltottRekordok.Items.Add(item1);
            }
           

            if (tb_feltoltottKepes.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_feltoltesKepes + " (" + Program.c_id + "," + Program.c_feltoltottKepes  +
               ") values ('" + tb_id.Text + "','" + tb_feltoltottKepes.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item2 = new ListViewItem(new[] { tb_feltoltottKepes.Text });
                lv_kepes.Items.Add(item2);

            }

            if (tb_europeanaFrissites.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_feltoltesEuropeana + " (" + Program.c_id + "," + Program.c_europeanaFrissites +
              ") values ('" + tb_id.Text + "','" + tb_europeanaFrissites.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item3 = new ListViewItem(new[] { tb_europeanaFrissites.Text });
                lv_europeana.Items.Add(item3);

            }

            if (tb_virtualis.Text.Length != 0)
            {
                string sql = "insert into " + Program.t_feltoltesVirtualis + " (" + Program.c_id + "," + Program.c_virtualis +
            ") values ('" + tb_id.Text + "','" + tb_virtualis.Text + "')";

                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item4 = new ListViewItem(new[] { tb_virtualis.Text });
                lv_virtualis.Items.Add(item4);

            }


            if (tb_megjFeltoltes.Text.Length != 0)
            {

                string sql2 = "insert into " + Program.t_feltoltesMegjegyzes + " (" + Program.c_id + "," + Program.c_megjFeltoltes + ") values ('" + tb_id.Text +
                "','" + tb_megjFeltoltes.Text + "')";

                command = new SQLiteCommand(sql2, m_dbConnection);
                command.ExecuteNonQuery();

                ListViewItem item5 = new ListViewItem(new[] { tb_megjFeltoltes.Text });
                lv_feltoltesMegjegyzes.Items.Add(item5);

            }

           
            m_dbConnection.Close();
      
            tb_feltoltott.Clear();
            tb_feltoltesDatum.Clear();
            tb_feltoltottKepes.Clear();
            tb_europeanaFrissites.Clear();
            tb_virtualis.Clear();
            tb_megjFeltoltes.Clear();

        }

        private void LW_intezmenyMegj_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string megj = LW_intezmenyMegj.SelectedItems[0].SubItems[0].Text;


            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();


            string sql = "delete from " + Program.t_intezmenyMegjegyzesek + " where " + Program.c_id + " like '" + id + "' and " +
                        Program.c_megjIntezmeny + " like '" + megj + "' ";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

            LW_intezmenyMegj.Items.Remove(LW_intezmenyMegj.SelectedItems[0]);

            }
            
        }

        private void lw_kontakt_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string kontaktNeve = lw_kontakt.SelectedItems[0].SubItems[0].Text;
            string kontaktEmail = lw_kontakt.SelectedItems[0].SubItems[1].Text;


            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_kontakt + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_kontakt + " like '" + kontaktNeve + "' and " +  Program.c_kontaktEmail + 
                            " like '" +kontaktEmail + "'";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lw_kontakt.Items.Remove(lw_kontakt.SelectedItems[0]);

            }
            
        }

        private void lw_progKontakt_DoubleClick(object sender, EventArgs e)
        {

            string id = tb_id.Text;
            string ProgramokKontaktneve = lw_progKontakt.SelectedItems[0].SubItems[0].Text;
            string ProgEmail = lw_progKontakt.SelectedItems[0].SubItems[1].Text;


            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_program_kontakt + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_progKontakt + " like '" + ProgramokKontaktneve + "' and " + Program.c_progEmail +
                            " like '" + ProgEmail + "'";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lw_progKontakt.Items.Remove(lw_progKontakt.SelectedItems[0]);

            }
           
        }

        private void lw_gyujtemeny_DoubleClick(object sender, EventArgs e)
        {

            string id = tb_id.Text;
            string gyujtemeny = lw_gyujtemeny.SelectedItems[0].SubItems[0].Text;


            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_csatlakozasGyujt + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_gyujtemeny + " like '" + gyujtemeny + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lw_gyujtemeny.Items.Remove(lw_gyujtemeny.SelectedItems[0]);

            }
            

        }

        private void lw_szakanyagok_DoubleClick(object sender, EventArgs e)
        {

            string id = tb_id.Text;
            string szakanyagok = lw_szakanyagok.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_csatlakozasSzakanyagok + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_szakanyagok + " like '" + szakanyagok + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lw_szakanyagok.Items.Remove(lw_szakanyagok.SelectedItems[0]);

            }
           
        }

        private void lv_kapcsolatfelvetel_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string kapcsolatFelvDatum = lv_kapcsolatfelvetel.SelectedItems[0].SubItems[0].Text;
            string leiras = lv_kapcsolatfelvetel.SelectedItems[0].SubItems[1].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_kapcsolatfelvetel + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_kapcsolatFelvDatum + " like '" + kapcsolatFelvDatum + "' and " + Program.c_leiras +
                            " like '" + leiras + "'";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_kapcsolatfelvetel.Items.Remove(lv_kapcsolatfelvetel.SelectedItems[0]);

            }         
        }

        private void lv_peas_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string peas = lv_peas.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_peas + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_peas + " like '" + peas + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_peas.Items.Remove(lv_peas.SelectedItems[0]);

            }


        }

        private void lv_feltoltottRekordok_DoubleClick(object sender, EventArgs e)
        {

            string id = tb_id.Text;
            string feltoltottRekordok = lv_feltoltottRekordok.SelectedItems[0].SubItems[0].Text;
            string datum = lv_feltoltottRekordok.SelectedItems[0].SubItems[1].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_feltoltesRekordok + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_feltoltott + " like '" + feltoltottRekordok + "' and " + Program.c_feltoltesDatum +
                            " like '" + datum + "'";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_feltoltottRekordok.Items.Remove(lv_feltoltottRekordok.SelectedItems[0]);

            }


        }

        private void lv_kepes_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string kepes = lv_kepes.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_feltoltesKepes + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_feltoltottKepes + " like '" + kepes + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_kepes.Items.Remove(lv_kepes.SelectedItems[0]);

            }

        }

        private void lv_europeana_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string europeana = lv_europeana.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_feltoltesEuropeana + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_europeanaFrissites + " like '" + europeana + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_europeana.Items.Remove(lv_europeana.SelectedItems[0]);

            }



        }

        private void lv_virtualis_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string virtualis = lv_virtualis.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_feltoltesVirtualis + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_virtualis + " like '" + virtualis + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_virtualis.Items.Remove(lv_virtualis.SelectedItems[0]);

            }



        }

        private void lv_feltoltesMegjegyzes_DoubleClick(object sender, EventArgs e)
        {
            string id = tb_id.Text;
            string feltoltesMegjegyzes = lv_feltoltesMegjegyzes.SelectedItems[0].SubItems[0].Text;

            DialogResult dialogResult = MessageBox.Show("Biztosan törli?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SQLiteConnection m_dbConnection;

                m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
                m_dbConnection.Open();


                string sql = "delete from " + Program.t_feltoltesMegjegyzes + " where " + Program.c_id + " like '" + id + "' and " +
                            Program.c_megjFeltoltes + " like '" + feltoltesMegjegyzes + "' ";


                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                lv_feltoltesMegjegyzes.Items.Remove(lv_feltoltesMegjegyzes.SelectedItems[0]);

            }



        }
    }
}
