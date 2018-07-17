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

    
    public partial class Form1 : Form
    {

        private class ComboboxItem
        {
            public string Name;
            public int Value;
            public ComboboxItem(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
               
                return Name;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void checkConditon(List<string> baseResults, List<string> condition)
        {
            for(int i = 0; i < baseResults.Count ; i+=3)
            {

                string elementID = baseResults[ i];
                if(condition.Contains(elementID) == false)
                {
                    baseResults.RemoveRange(i, 3);
                    i -= 3;
                }

            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
          

            cb_europeana.Items.Add(new ComboboxItem(" igen ", 1));
            cb_europeana.Items.Add(new ComboboxItem(" nem ", 0));
            cb_europeana.Items.Add(new ComboboxItem(" - ", -1));
           
            cb_onlineData.Items.Add(new ComboboxItem(" igen ", 1));
            cb_onlineData.Items.Add(new ComboboxItem(" nem ", 0));
            cb_onlineData.Items.Add(new ComboboxItem(" - ", -1));

            cb_kozfoglalkoztatasi.Items.Add(new ComboboxItem(" igen ", 1));
            cb_kozfoglalkoztatasi.Items.Add(new ComboboxItem(" nem ", 0));
            cb_kozfoglalkoztatasi.Items.Add(new ComboboxItem(" - ", -1));


            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql;
            int numberOfResults;

            sql = "select "+Program.c_id+ ","+  Program.c_inev+","+Program.c_partner + " from "+Program.t_intezmeny;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> results = new List<string>();

            while (reader.Read())
            {
                results.Add((string) reader[Program.c_id]);
               
                if(reader[Program.c_inev] != DBNull.Value)
                {
                    results.Add((string)reader[Program.c_inev]);
                }
                else
                {
                    results.Add(" ");
                }

                if (reader[Program.c_partner] != DBNull.Value) {
                    results.Add((string)reader[Program.c_partner]);
                } else
                    results.Add(" ");



            }
              

            numberOfResults = reader.StepCount;
 
            m_dbConnection.Close();

            NumResultLabel.Text = numberOfResults.ToString();

            resultListView.View = View.Details;                    
            
            resultListView.FullRowSelect = true;
           
            resultListView.GridLines = true;
      
            resultListView.Columns.Add("Azonosító", 100, HorizontalAlignment.Left);
            resultListView.Columns.Add("Intézmény Név", 500, HorizontalAlignment.Left);

            resultNotPartnerlistView.View = View.Details;
           
            resultNotPartnerlistView.FullRowSelect = true;
           
            resultNotPartnerlistView.GridLines = true;
            resultNotPartnerlistView.Columns.Add("Azonosító", 100, HorizontalAlignment.Left);
            resultNotPartnerlistView.Columns.Add("Intézmény Név", 500, HorizontalAlignment.Left);

            for (int i = 0; i < numberOfResults; i++)
            {
                if (results[3 * i + 2].Equals("true"))
                {
                    ListViewItem item1 = new ListViewItem(new[] { results[3 * i], results[3 * i + 1] });
                    resultListView.Items.Add(item1);
                }
                else
                {
                    ListViewItem item2 = new ListViewItem(new[] { results[3 * i], results[3 * i + 1] });
                    resultNotPartnerlistView.Items.Add(item2);
                }
            }


        }

        private void btnKeres_Click(object sender, EventArgs e)
        {
            string nev = tbIntezmenyNevKeres.Text;
            string statusz = tb_statuszKeres.Text;
            int europeanaValue = -1;
            int onlineDataValue = -1;
            int kozfogValue = -1;

            if ((ComboboxItem)cb_europeana.SelectedItem != null)
            {
                ComboboxItem europeana = (ComboboxItem)cb_europeana.SelectedItem;
                europeanaValue = europeana.Value;
            }
            
            if((ComboboxItem)cb_onlineData.SelectedItem != null)
            {
                ComboboxItem onlineData = (ComboboxItem)cb_onlineData.SelectedItem;
                onlineDataValue = onlineData.Value;
            }
           
            if((ComboboxItem)cb_kozfoglalkoztatasi.SelectedItem != null)
            {
                ComboboxItem kozfog = (ComboboxItem)cb_kozfoglalkoztatasi.SelectedItem;
                kozfogValue = kozfog.Value;

            }
           

            List<string> queryCommands = new List<string>();

            if(europeanaValue == 0)
            {
                queryCommands.Add(" and " + Program.c_europeana + " like 'false' ");
            }

            if (europeanaValue == 1)
            {
                queryCommands.Add(" and " + Program.c_europeana + " like 'true' ");
            }

            if (onlineDataValue == 0)
            {
                queryCommands.Add(" and " + Program.c_onlineData + " like 'false' ");
            }

            if (onlineDataValue == 1)
            {
                queryCommands.Add(" and " + Program.c_onlineData + " like 'true' ");
            }

            if (kozfogValue == 0)
            {
                queryCommands.Add(" and " + Program.c_kozfog + " like 'false' ");
            }

            if (kozfogValue == 1)
            {
                queryCommands.Add(" and " + Program.c_kozfog + " like 'true' ");
            }



            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=MuseumMapDB.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql;
            int numberOfResults;

            sql = "select " + Program.c_id + "," + Program.c_inev+","+ Program.c_partner + " from " + Program.t_intezmeny +
                " where " + Program.c_inev + " like '"+ tbIntezmenyNevKeres.Text+ "%'" ;

            for(int i = 0; i< queryCommands.Count; i++)
            {
                sql = sql + queryCommands[i];

            }

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> results = new List<string>();

            
            List<string> resultsNextQueryIds = new List<string>();
         

            while (reader.Read())
            {
                results.Add((string)reader[Program.c_id]);
               

                if (reader[Program.c_inev] != DBNull.Value)
                {
                    results.Add((string)reader[Program.c_inev]);
                }
                else
                {
                    results.Add(" ");
                }

                if (reader[Program.c_partner] != DBNull.Value)
                {
                    results.Add((string)reader[Program.c_partner]);
                }
                else
                {
                    results.Add(" ");
                }


            }


           
            if(tb_statuszKeres.TextLength != 0)
            {
                 sql = "select " + Program.c_id  + " from " + Program.t_feltoltesMegjegyzes +
                " where " + Program.c_megjFeltoltes + " like '" + tb_statuszKeres.Text + "%'";

            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                resultsNextQueryIds.Add((string)reader[Program.c_id]);    
            }

            checkConditon(results, resultsNextQueryIds);


            }

            


            m_dbConnection.Close();
            numberOfResults = results.Count / 3;
            NumResultLabel.Text = numberOfResults.ToString();

            resultListView.Clear();
            resultNotPartnerlistView.Clear();

            resultListView.View = View.Details;
            resultNotPartnerlistView.View = View.Details;

            // Select the item and subitems when selection is made.
            resultListView.FullRowSelect = true;
            // Display grid lines.
            resultListView.GridLines = true;

            resultListView.Columns.Add("Azonosító", 100, HorizontalAlignment.Left);
            resultListView.Columns.Add("Intézmény Név", 500, HorizontalAlignment.Left);


            // Select the item and subitems when selection is made.
            resultNotPartnerlistView.FullRowSelect = true;
            // Display grid lines.
            resultNotPartnerlistView.GridLines = true;

            resultNotPartnerlistView.Columns.Add("Azonosító", 100, HorizontalAlignment.Left);
            resultNotPartnerlistView.Columns.Add("Intézmény Név", 500, HorizontalAlignment.Left);


            for (int i = 0; i < numberOfResults; i++)
            {
                if(results[3 * i + 2].Equals("true")){ 
                ListViewItem item1 = new ListViewItem(new[] { results[3 * i], results[3 * i + 1] });
                resultListView.Items.Add(item1);
                }
                else
                {
                    ListViewItem item2 = new ListViewItem(new[] { results[3 * i], results[3 * i + 1] });
                    resultNotPartnerlistView.Items.Add(item2);

                }
            }
        }

        private void resultListView_DoubleClick(object sender, EventArgs e)
        {
            
            Urlap u = new Urlap();
            u.initUrlap(resultListView.SelectedItems[0].SubItems[0].Text);

            u.ShowDialog();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Urlap u = new Urlap();
            u.ShowDialog();

        }

        

        private void resultNotPartnerlistView_DoubleClick(object sender, EventArgs e)
        {
            Urlap u = new Urlap();
            u.initUrlap(resultNotPartnerlistView.SelectedItems[0].SubItems[0].Text);

            u.ShowDialog();
        }
    }
}
