using System.Drawing;
namespace _134KO
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPazarKontrolDegerLbl = new System.Windows.Forms.Label();
            this.lblPazarKontrolDeger = new System.Windows.Forms.Label();
            this.btnPazarBaşlat = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtPazarKontrolSure = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPazarFiyat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartStop = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.cbTopMost = new System.Windows.Forms.CheckBox();
            this.tmrBringToFront = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tmrPazarKontrol = new System.Windows.Forms.Timer(this.components);
            this.tmrPazarKur = new System.Windows.Forms.Timer(this.components);
            this.tmrPazarKurBekleTmr = new System.Windows.Forms.Timer(this.components);
            this.tmrPazarItemSurukle = new System.Windows.Forms.Timer(this.components);
            this.tmrMauseClick = new System.Windows.Forms.Timer(this.components);
            this.tmrPazarBoz = new System.Windows.Forms.Timer(this.components);
            this.tmrBaslat = new System.Windows.Forms.Timer(this.components);
            this.pnlContent.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.label6);
            this.pnlContent.Controls.Add(this.label5);
            this.pnlContent.Controls.Add(this.label4);
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.button1);
            this.pnlContent.Controls.Add(this.lblPazarKontrolDegerLbl);
            this.pnlContent.Controls.Add(this.lblPazarKontrolDeger);
            this.pnlContent.Controls.Add(this.btnPazarBaşlat);
            this.pnlContent.Controls.Add(this.pnlButtons);
            this.pnlContent.Controls.Add(this.txtPazarKontrolSure);
            this.pnlContent.Controls.Add(this.pictureBox3);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.txtPazarFiyat);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 24);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(272, 566);
            this.pnlContent.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPazarKontrolDegerLbl
            // 
            this.lblPazarKontrolDegerLbl.AutoSize = true;
            this.lblPazarKontrolDegerLbl.Location = new System.Drawing.Point(200, 33);
            this.lblPazarKontrolDegerLbl.Name = "lblPazarKontrolDegerLbl";
            this.lblPazarKontrolDegerLbl.Size = new System.Drawing.Size(13, 13);
            this.lblPazarKontrolDegerLbl.TabIndex = 30;
            this.lblPazarKontrolDegerLbl.Text = "0";
            // 
            // lblPazarKontrolDeger
            // 
            this.lblPazarKontrolDeger.AutoSize = true;
            this.lblPazarKontrolDeger.Location = new System.Drawing.Point(123, 9);
            this.lblPazarKontrolDeger.Name = "lblPazarKontrolDeger";
            this.lblPazarKontrolDeger.Size = new System.Drawing.Size(65, 13);
            this.lblPazarKontrolDeger.TabIndex = 29;
            this.lblPazarKontrolDeger.Text = "Renk Deger";
            // 
            // btnPazarBaşlat
            // 
            this.btnPazarBaşlat.Location = new System.Drawing.Point(12, 59);
            this.btnPazarBaşlat.Name = "btnPazarBaşlat";
            this.btnPazarBaşlat.Size = new System.Drawing.Size(75, 23);
            this.btnPazarBaşlat.TabIndex = 28;
            this.btnPazarBaşlat.Text = "Pazar Başlat";
            this.btnPazarBaşlat.UseVisualStyleBackColor = true;
            this.btnPazarBaşlat.Click += new System.EventHandler(this.btnPazarBaşlat_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSaveSettings);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 531);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(272, 35);
            this.pnlButtons.TabIndex = 20;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSettings.Location = new System.Drawing.Point(0, 0);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(272, 35);
            this.btnSaveSettings.TabIndex = 19;
            this.btnSaveSettings.Tag = "1";
            this.btnSaveSettings.Text = "Ayarları Kaydet";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtPazarKontrolSure
            // 
            this.txtPazarKontrolSure.Location = new System.Drawing.Point(12, 33);
            this.txtPazarKontrolSure.Name = "txtPazarKontrolSure";
            this.txtPazarKontrolSure.Size = new System.Drawing.Size(68, 20);
            this.txtPazarKontrolSure.TabIndex = 27;
            this.txtPazarKontrolSure.Text = "10";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(109, 62);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 20);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Kontrol Süre Dakika";
            // 
            // txtPazarFiyat
            // 
            this.txtPazarFiyat.Location = new System.Drawing.Point(12, 6);
            this.txtPazarFiyat.Name = "txtPazarFiyat";
            this.txtPazarFiyat.Size = new System.Drawing.Size(68, 20);
            this.txtPazarFiyat.TabIndex = 24;
            this.txtPazarFiyat.Text = "1249999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fiyat";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem1.Text = "Üstte Tut";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(12, 20);
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartStop});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(272, 24);
            this.msMenu.TabIndex = 8;
            this.msMenu.Text = "menuStrip1";
            // 
            // cbTopMost
            // 
            this.cbTopMost.AutoSize = true;
            this.cbTopMost.BackColor = System.Drawing.Color.GhostWhite;
            this.cbTopMost.Checked = true;
            this.cbTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTopMost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbTopMost.Location = new System.Drawing.Point(174, 4);
            this.cbTopMost.Name = "cbTopMost";
            this.cbTopMost.Size = new System.Drawing.Size(109, 19);
            this.cbTopMost.TabIndex = 9;
            this.cbTopMost.Text = "Üstte Tut (Shift)";
            this.cbTopMost.UseVisualStyleBackColor = false;
            this.cbTopMost.CheckedChanged += new System.EventHandler(this.cbTopMost_CheckedChanged);
            // 
            // tmrBringToFront
            // 
            this.tmrBringToFront.Tick += new System.EventHandler(this.tmrBringToFront_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tmrPazarKontrol
            // 
            this.tmrPazarKontrol.Interval = 1000;
            this.tmrPazarKontrol.Tick += new System.EventHandler(this.tmrPazarKontrol_Tick);
            // 
            // tmrPazarKur
            // 
            this.tmrPazarKur.Interval = 1000;
            this.tmrPazarKur.Tick += new System.EventHandler(this.tmrPazarKur_Tick);
            // 
            // tmrPazarKurBekleTmr
            // 
            this.tmrPazarKurBekleTmr.Interval = 1000;
            this.tmrPazarKurBekleTmr.Tick += new System.EventHandler(this.tmrPazarKurBekleTmr_Tick);
            // 
            // tmrPazarItemSurukle
            // 
            this.tmrPazarItemSurukle.Interval = 500;
            this.tmrPazarItemSurukle.Tick += new System.EventHandler(this.tmrPazarItemSurukle_Tick);
            // 
            // tmrMauseClick
            // 
            this.tmrMauseClick.Interval = 500;
            this.tmrMauseClick.Tick += new System.EventHandler(this.tmrMauseClick_Tick);
            // 
            // tmrPazarBoz
            // 
            this.tmrPazarBoz.Interval = 1000;
            this.tmrPazarBoz.Tick += new System.EventHandler(this.tmrPazarBoz_Tick);
            // 
            // tmrBaslat
            // 
            this.tmrBaslat.Interval = 1000;
            this.tmrBaslat.Tick += new System.EventHandler(this.tmrBaslat_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 590);
            this.Controls.Add(this.cbTopMost);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "66666666666666";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnStartStop;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.CheckBox cbTopMost;
        private System.Windows.Forms.Timer tmrBringToFront;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox txtPazarFiyat;
        private System.Windows.Forms.TextBox txtPazarKontrolSure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrPazarKontrol;
        private System.Windows.Forms.Button btnPazarBaşlat;
        private System.Windows.Forms.Label lblPazarKontrolDeger;
        private System.Windows.Forms.Label lblPazarKontrolDegerLbl;
        private System.Windows.Forms.Timer tmrPazarKur;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrPazarKurBekleTmr;
        private System.Windows.Forms.Timer tmrPazarItemSurukle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrMauseClick;
        private System.Windows.Forms.Timer tmrPazarBoz;
        private System.Windows.Forms.Timer tmrBaslat;
    }
}

