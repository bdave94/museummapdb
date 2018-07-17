namespace museumMapDataBase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumResultLabel = new System.Windows.Forms.Label();
            this.tbIntezmenyNevKeres = new System.Windows.Forms.TextBox();
            this.btnKeres = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resultListView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_europeana = new System.Windows.Forms.ComboBox();
            this.cb_onlineData = new System.Windows.Forms.ComboBox();
            this.cb_kozfoglalkoztatasi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_statuszKeres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.resultNotPartnerlistView = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumResultLabel
            // 
            this.NumResultLabel.AutoSize = true;
            this.NumResultLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NumResultLabel.Location = new System.Drawing.Point(1119, 25);
            this.NumResultLabel.Name = "NumResultLabel";
            this.NumResultLabel.Size = new System.Drawing.Size(22, 24);
            this.NumResultLabel.TabIndex = 2;
            this.NumResultLabel.Text = "0";
            // 
            // tbIntezmenyNevKeres
            // 
            this.tbIntezmenyNevKeres.Location = new System.Drawing.Point(232, 25);
            this.tbIntezmenyNevKeres.Name = "tbIntezmenyNevKeres";
            this.tbIntezmenyNevKeres.Size = new System.Drawing.Size(161, 20);
            this.tbIntezmenyNevKeres.TabIndex = 4;
            // 
            // btnKeres
            // 
            this.btnKeres.Location = new System.Drawing.Point(181, 330);
            this.btnKeres.Name = "btnKeres";
            this.btnKeres.Size = new System.Drawing.Size(82, 36);
            this.btnKeres.TabIndex = 5;
            this.btnKeres.Text = "Keresés";
            this.btnKeres.UseVisualStyleBackColor = true;
            this.btnKeres.Click += new System.EventHandler(this.btnKeres_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Intézmény neve";
            // 
            // resultListView
            // 
            this.resultListView.Location = new System.Drawing.Point(441, 74);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(633, 255);
            this.resultListView.TabIndex = 7;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.DoubleClick += new System.EventHandler(this.resultListView_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 81);
            this.button1.TabIndex = 8;
            this.button1.Text = "Új űrlap";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_europeana
            // 
            this.cb_europeana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_europeana.FormattingEnabled = true;
            this.cb_europeana.Location = new System.Drawing.Point(232, 158);
            this.cb_europeana.Name = "cb_europeana";
            this.cb_europeana.Size = new System.Drawing.Size(121, 21);
            this.cb_europeana.TabIndex = 11;
            // 
            // cb_onlineData
            // 
            this.cb_onlineData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_onlineData.FormattingEnabled = true;
            this.cb_onlineData.Location = new System.Drawing.Point(232, 205);
            this.cb_onlineData.Name = "cb_onlineData";
            this.cb_onlineData.Size = new System.Drawing.Size(121, 21);
            this.cb_onlineData.TabIndex = 12;
            // 
            // cb_kozfoglalkoztatasi
            // 
            this.cb_kozfoglalkoztatasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_kozfoglalkoztatasi.FormattingEnabled = true;
            this.cb_kozfoglalkoztatasi.Location = new System.Drawing.Point(232, 267);
            this.cb_kozfoglalkoztatasi.Name = "cb_kozfoglalkoztatasi";
            this.cb_kozfoglalkoztatasi.Size = new System.Drawing.Size(121, 21);
            this.cb_kozfoglalkoztatasi.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Státusz";
            // 
            // tb_statuszKeres
            // 
            this.tb_statuszKeres.Location = new System.Drawing.Point(232, 94);
            this.tb_statuszKeres.Name = "tb_statuszKeres";
            this.tb_statuszKeres.Size = new System.Drawing.Size(161, 20);
            this.tb_statuszKeres.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Europeana csatlakozással";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Online data használattal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Közfoglalkoztatási programban részt vesz";
            // 
            // resultNotPartnerlistView
            // 
            this.resultNotPartnerlistView.Location = new System.Drawing.Point(441, 401);
            this.resultNotPartnerlistView.Name = "resultNotPartnerlistView";
            this.resultNotPartnerlistView.Size = new System.Drawing.Size(633, 257);
            this.resultNotPartnerlistView.TabIndex = 19;
            this.resultNotPartnerlistView.UseCompatibleStateImageBehavior = false;
            this.resultNotPartnerlistView.DoubleClick += new System.EventHandler(this.resultNotPartnerlistView_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(435, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "Partnerek";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(435, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 31);
            this.label7.TabIndex = 21;
            this.label7.Text = "Érdeklődők";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1181, 670);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.resultNotPartnerlistView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_statuszKeres);
            this.Controls.Add(this.cb_kozfoglalkoztatasi);
            this.Controls.Add(this.cb_onlineData);
            this.Controls.Add(this.cb_europeana);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKeres);
            this.Controls.Add(this.tbIntezmenyNevKeres);
            this.Controls.Add(this.NumResultLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NumResultLabel;
        private System.Windows.Forms.TextBox tbIntezmenyNevKeres;
        private System.Windows.Forms.Button btnKeres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_europeana;
        private System.Windows.Forms.ComboBox cb_onlineData;
        private System.Windows.Forms.ComboBox cb_kozfoglalkoztatasi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_statuszKeres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView resultNotPartnerlistView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

