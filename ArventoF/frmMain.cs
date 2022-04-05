using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing.Imaging;
using System.Collections;
using _ArventoF;
using System.IO;

namespace _134KO
{
    public partial class frmMain : Form
    {
        Character character = null;
        bool STARTED = false;
        GlobalKeyboardHook gHook;
        List<Timer> timers = new List<Timer>();
        List<Timer> onlyClosableTimers = new List<Timer>();

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        string fiyatDegeri = "";
        public frmMain()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width - 20, Screen.PrimaryScreen.Bounds.Top + 20);
            //this.TopMost = cbTopMost.Checked;
            ayarOku();
            //gHook = new GlobalKeyboardHook();
            //gHook.HookedKeys.Add(Keys.LShiftKey);
            //gHook.HookedKeys.Add(Keys.RShiftKey);
            //gHook.HookedKeys.Add(Keys.LControlKey);
            //gHook.HookedKeys.Add(Keys.RControlKey);
            //gHook.KeyUp += gHook_KeyUp;
            //gHook.KeyDown += gHook_KeyDown;
            timers.Add(tmrBringToFront);
            TxtVeriCek();
            TxtVeriCek2();
            dosyaKontrolSil();
            //iniArryDoldurOto();
            //bagArryDoldurOto();
            //tmrGenel.Start();

            if (Convert.ToInt16(hastaneArry[0]) == 1)
            {
                TxtVeriCekAlacak();
                txtPazarFiyat.Text = alacakArry[0].ToString();
                fiyatDegeri = alacakArry[0].ToString();
                pazarkurArryDoldurOto();
                tmrBaslat.Start();
            }
            if (Convert.ToInt16(hastaneArry[0]) == 2)
            {
                TxtVeriCekYer();
                TxtVeriCekInterval();
                tmrR.Interval = Convert.ToInt16(intervalArry[0]);
                tmr2.Interval = Convert.ToInt16(intervalArry[1]);
                iniArryDoldurOto();
                bagArryDoldurOto();
                tmrHastane.Start();
                tmr2.Start();
                //tmrR.Start();
                tmrGenel.Start();
            }
        }
        private void ayarOku()
        {
            //txtPazarFiyat.Text = Settings.Default.fiyat.ToString();
            //txtPazarKontrolSure.Text = Settings.Default.beklemeSuresi.ToString();
            //txtDosyaYolu.Text = Settings.Default.dosyaYolu;
        }

        private void StartTimers()
        {
            //foreach (Timer timer in timers)
            //{
            //    timer.Start();
            //}
            //if (cbAttack.Checked)
            //{
            //    if (ACTIVE == Variables.Clasess.RANGE_ARCHER || ACTIVE == Variables.Clasess.MELEE_ARCHER)
            //    {
            //        if (cbArcherUseWolfSkill.Checked)
            //        {
            //            UseWolfSkill();
            //        }
            //        if (ACTIVE == Variables.Clasess.RANGE_ARCHER)
            //        {
            //            tmrRangeArcherSelectMob.Start();
            //        }
            //        else if (ACTIVE == Variables.Clasess.MELEE_ARCHER)
            //        {
            //            tmrMeleeArcherSelectMob.Start();
            //        }
            //    }
            //    else if (ACTIVE == Variables.Clasess.WARRIOR)
            //    {
            //        //eğer savaşçıysa
            //    }
            //    else if (ACTIVE == Variables.Clasess.MAGE)
            //    {
            //        //eğer mageyse
            //    }
            //    else if (ACTIVE == Variables.Clasess.PRIEST)
            //    {
            //        //eğer priestse
            //    }
            //}
        }

        private void StopTimers()
        {
            foreach (Timer timer in timers)
            {
                timer.Stop();
            }
            foreach (Timer timer in onlyClosableTimers)
            {
                timer.Stop();
            }
        }

        private void ShowWarningMessage(String message, String title)
        {
            this.TopMost = true;
            Win32.ShowWindow(Process.GetCurrentProcess().MainWindowHandle, Win32.ShowWindowEnum.Restore);
            WarningMessage.Show(message, title);
            this.TopMost = false;
        }

        private void ShowInfoMessage(String message, String title)
        {
            this.TopMost = true;
            Win32.ShowWindow(Process.GetCurrentProcess().MainWindowHandle, Win32.ShowWindowEnum.Restore);
            InfoMessage.Show(message, title);
            this.TopMost = false;
        }



        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        //private void gHook_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
        //    {
        //        btnStartStop.PerformClick();
        //    }
        //    else if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
        //    {
        //        Win32.ShowWindow(Process.GetCurrentProcess().MainWindowHandle, Win32.ShowWindowEnum.Restore);
        //        cbTopMost.Checked = !cbTopMost.Checked;
        //    }
        //}



        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.beklemeSuresi = Convert.ToInt16(txtPazarKontrolSure.Text);
            Settings.Default.fiyat = Convert.ToInt32(txtPazarFiyat.Text);
            Settings.Default.dosyaYolu = txtDosyaYolu.Text;
            Settings.Default.Save();
        }

        private void cbTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cbTopMost.Checked;
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\Bekle.exe");
        }


        private void tmrBringToFront_Tick(object sender, EventArgs e)
        {
            if (!STARTED) return;
            if (character == null)
            {
                return;
            }
            character.BringToFront();
        }
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1140 , 287
            // 879 ,  287
            // 1240 -- ib
            // 1539,
            try
            {

                pictureBox3.BackColor = Functions.GetPixelColor(Cursor.Position.X, Cursor.Position.Y);
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color b = Functions.GetClosestColor(Functions.GetPixelColor(Cursor.Position.X, Cursor.Position.Y));
                label9.Text = (b.R + " " + b.B + " " + b.B + " ");
            }
            catch (Exception s)
            {
                tmr2.Stop();
                tmrR.Stop();
                tmrGenel.Stop();
                pazarKontrolDeger = 0;
                baslatDeger = 0;
                pazarBozDeger = 0;
                mouseClickDeger = 0;
                mouseDragTimerInterval = 0;
                pazarKontrolBekleDeger = 0;
                pazarKurDeger = 0;
                tmrPazarItemSurukle.Stop();
                tmrSec.Stop();
                tmrBaslat.Stop();
                tmrPazarBoz.Stop();
                tmrPazarKontrol.Stop();
                tmrPazarKur.Stop();
                tmrHastane.Stop();
                tmrHastaneBas.Stop();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private const UInt32 MouseEventRightDown = 0x0008;
        private const UInt32 MouseEventRightUp = 0x0010;
        private void timer2_Tick(object sender, EventArgs e)
        {
            mouse_event(MouseEventRightDown, 0, 0, 0, new UIntPtr(0));
            mouse_event(MouseEventRightUp, 0, 0, 0, new UIntPtr(0));
        }
        int pazarKontrolDeger = 0;
        int bosSlotSayisi = 0;
        private void tmrPazarKontrol_Tick(object sender, EventArgs e)
        {
            pazarKontrolDeger++;
            lblPazarKontrolDegerLbl.Text = pazarKontrolDeger.ToString() + " / " + (Convert.ToInt16(txtPazarKontrolSure.Text) * 60).ToString();
            if (pazarKontrolDeger >= Convert.ToInt16(txtPazarKontrolSure.Text) * 60)
            {
                bosSlotSayisi = 0;
                pictureBox3.BackColor = Functions.GetPixelColor(461, 324);
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color c = Functions.GetPixelColor(461, 324);
                if (c.R != 0 && c.G != 0 && c.B != 0)
                {
                    bosSlotSayisi++;
                    label3.Text = "Slot 1 Boş";
                }
                pictureBox3.BackColor = Functions.GetPixelColor(502, 324);
                c = Functions.GetPixelColor(502, 324);
                if (c.R != 0 && c.G != 0 && c.B != 0)
                {
                    bosSlotSayisi++;
                    label4.Text = "Slot 2 Boş";
                }
                pictureBox3.BackColor = Functions.GetPixelColor(542, 324);
                c = Functions.GetPixelColor(542, 324);
                if (c.R != 0 && c.G != 0 && c.B != 0)
                {
                    bosSlotSayisi++;
                    label5.Text = "Slot 3 Boş";
                }
                pictureBox3.BackColor = Functions.GetPixelColor(580, 324);
                c = Functions.GetPixelColor(580, 324);
                if (c.R != 0 && c.G != 0 && c.B != 0)
                {
                    bosSlotSayisi++;
                    label6.Text = "Slot 4 Boş";
                }
                if (bosSlotSayisi > 3)
                {
                    pazarKontrolDeger = 0;
                    bosSlotSayisi = 0;
                    iniKontrol = 0;
                    tmrPazarBoz.Start();
                    tmrPazarKontrol.Stop();
                }
                else
                {
                    pazarKontrolDeger = 0;
                }
            }
        }

        private void btnPazarBaşlat_Click(object sender, EventArgs e)
        {
            tmrBaslat.Start();
            pazarkurArryDoldurOto();
            Cursor.Position = new Point(51, 67);
            tmrSec.Start();
        }
        ArrayList pazarKurArryX = new ArrayList();
        ArrayList pazarKurArryY = new ArrayList();
        ArrayList iniBosDoluKontrolArry = new ArrayList();
        private void pazarkurArryDoldurOto()
        {
            //ini 1 sıra
            int baslangicX = 370;
            int baslangicY = 360; //345
            pazarKurArryX.Add(baslangicX.ToString());
            pazarKurArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                pazarKurArryX.Add((baslangicX).ToString());
                pazarKurArryY.Add((baslangicY).ToString());
            }
            //ini 2. sıra
            baslangicX = 370;
            baslangicY = 410;
            pazarKurArryX.Add(baslangicX.ToString());
            pazarKurArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                pazarKurArryX.Add((baslangicX).ToString());
                pazarKurArryY.Add((baslangicY).ToString());
            }
            //ini 3. sıra
            baslangicX = 370;
            baslangicY = 455;
            pazarKurArryX.Add(baslangicX.ToString());
            pazarKurArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                pazarKurArryX.Add((baslangicX).ToString());
                pazarKurArryY.Add((baslangicY).ToString());
            }
            //ini 4. sıra
            baslangicX = 370;
            baslangicY = 505;
            pazarKurArryX.Add(baslangicX.ToString());
            pazarKurArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                pazarKurArryX.Add((baslangicX).ToString());
                pazarKurArryY.Add((baslangicY).ToString());
            }

        }
        private void iniArryDoldurOto()
        {
            //ini 1 sıra
            int baslangicX = 660;
            int baslangicY = 460;
            iniArryX.Add(baslangicX.ToString());
            iniArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                iniArryX.Add((baslangicX).ToString());
                iniArryY.Add((baslangicY).ToString());
            }
            //ini 2. sıra
            baslangicX = 660;
            baslangicY = 510;
            iniArryX.Add(baslangicX.ToString());
            iniArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 7; i++)
            {
                baslangicX = baslangicX + 50;
                iniArryX.Add((baslangicX).ToString());
                iniArryY.Add((baslangicY).ToString());
            }
            //ini 3. sıra 4 adet
            baslangicX = 660;
            baslangicY = 560;
            iniArryX.Add(baslangicX.ToString());
            iniArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 4; i++)
            {
                baslangicX = baslangicX + 50;
                iniArryX.Add((baslangicX).ToString());
                iniArryY.Add((baslangicY).ToString());
            }
        }
        int pazarKurDeger = 0;
        private void tmrPazarKur_Tick(object sender, EventArgs e)
        {
            pazarKurDeger++;

            lblPazarKontrolDegerLbl.Text = pazarKurDeger.ToString();

            if (pazarKurDeger == 1)
            {
                Cursor.Position = new Point(28, 771);
                tmrSec.Start();
            }

            if (pazarKurDeger == 5)
            {
                Cursor.Position = new Point(66, 632);
                tmrSec.Start();
            }
            if (pazarKurDeger == 9)
            {
                Cursor.Position = new Point(510, 378);
                tmrSec.Start();
            }
            if (pazarKurDeger == 12)
            {

                pazarIniKontrol();
                label7.Text = iniKontrol.ToString();
                if (iniKontrol < 2)
                {
                    tmrPazarKurBekleTmr.Start();
                    tmrPazarKur.Stop();
                }
            }
            if (pazarKurDeger == 14)
            {
                if (Convert.ToInt16(label7.Text) < 3)
                {
                    label3.Text = "Satılacak İtem Kalmadı.";
                    Environment.Exit(0);
                    tmrPazarKur.Stop();
                }
            }
            if (pazarKurDeger == 15)
            {
                tmrPazarItemSurukle.Start();
                tmrPazarKur.Stop();
            }
            if (pazarKurDeger == 20)
            {
                Cursor.Position = new Point(415, 626);
                tmrSec.Start();
            }
            if (pazarKurDeger == 23)
            {
                //System.Diagnostics.Process.Start(@"D:\Bekle.exe");
                new Process() { StartInfo = new ProcessStartInfo(@"D:\Bekle.exe") { Verb = "runas" } }.Start();
                tmrPazarKur.Stop();
                Environment.Exit(0);
                //tmrPazarKontrol.Start();
                //pazarKurDeger = 0;
            }
        }
        int iniKontrol = 0;
        private void pazarIniKontrol()
        {
            iniKontrol = 0;
            iniBosDoluKontrolArry.Clear();
            for (int i = 0; i < 27; i++)
            {
                pictureBox3.BackColor = Functions.GetPixelColor(Convert.ToInt16(pazarKurArryX[i]), Convert.ToInt16(pazarKurArryY[i]));
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color c = Functions.GetPixelColor(Convert.ToInt16(pazarKurArryX[i]), Convert.ToInt16(pazarKurArryY[i]));
                if (c.R == 0 && c.G == 0 && c.B == 0)
                {
                    iniBosDoluKontrolArry.Add("1");
                    iniKontrol++;
                }
                else
                {
                    iniBosDoluKontrolArry.Add("0");
                }
            }
        }
        ArrayList iniArryX = new ArrayList();
        ArrayList iniArryY = new ArrayList();
        ArrayList iniKontrolArry = new ArrayList();
        int iniBosDoluKontrol = 0;
        private int IniKontrol()
        {
            iniBosDoluKontrol = 0;
            iniKontrolArry.Clear();
            for (int i = 0; i < 13; i++)
            {
                pictureBox3.BackColor = Functions.GetPixelColor(Convert.ToInt16(iniArryX[i]), Convert.ToInt16(iniArryY[i]));
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color c = Functions.GetClosestColor(Functions.GetPixelColor(Convert.ToInt16(iniArryX[i]), Convert.ToInt16(iniArryY[i])));
                if (c.R != 0 && c.G != 0 && c.B != 0)
                {
                    iniKontrolArry.Add("1");
                    iniBosDoluKontrol++;
                    label10.Text = iniBosDoluKontrol.ToString();
                }
                else
                {
                    iniKontrolArry.Add("0");
                }
            }
            for (int i = 0; i < iniKontrolArry.Count; i++)
            {
                listBox2.Items.Add(iniKontrolArry[i]);
            }
            return iniBosDoluKontrol;
        }

        int iniGenisKontrolVarYok = -1;
        private int iniGenisKontrol(int x, int y)
        {
            Color c = Functions.GetClosestColor(Functions.GetPixelColor(x, y));
            if (c.R != 0 && c.G != 0 && c.B != 0)
            {
                iniGenisKontrolVarYok = 1;
            }
            else
            {
                iniGenisKontrolVarYok = 0;
            }
            return iniGenisKontrolVarYok;
        }

        int iniGenisKontrolSayi = 0;
        private int iniGenisKontrolGezginFnc(int x, int y)
        {
            int geniskontrolGezginDeger = 0;
            int a = x;
            int b = y;
            for (int i = 0; i < 30; i++)
            {
                int kontrol = iniGenisKontrol(a + i, b);
                if (kontrol == 1)
                {
                    geniskontrolGezginDeger = 1;
                    iniGenisKontrolSayi++;
                    label10.Text = iniGenisKontrolSayi.ToString();
                    i = 30;
                }
            }

            return geniskontrolGezginDeger;
        }
        ArrayList bagArryX = new ArrayList();
        ArrayList bagArryY = new ArrayList();
        ArrayList bagKontrolArry = new ArrayList();
        int bagBolDoluKontrol = 0;
        private void bagKontrol()
        {
            bagBolDoluKontrol = 0;
            bagKontrolArry.Clear();
            for (int i = 0; i < 11; i++)
            {
                pictureBox3.BackColor = Functions.GetPixelColor(Convert.ToInt16(bagArryX[i]), Convert.ToInt16(bagArryY[i]));
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color c = Functions.GetClosestColor(Functions.GetPixelColor(Convert.ToInt16(bagArryX[i]), Convert.ToInt16(bagArryY[i])));
                if (c.R == 0 && c.G == 0 && c.B == 0)
                {
                    bagKontrolArry.Add("1");
                    bagBolDoluKontrol++;
                    label10.Text = bagBolDoluKontrol.ToString();
                }
                else
                {
                    bagKontrolArry.Add("0");
                }
            }
            for (int i = 0; i < bagKontrolArry.Count; i++)
            {
                listBox1.Items.Add(bagKontrolArry[i]);
            }
        }
        private void bagArryDoldurOto()
        {
            //ini 1 sıra
            int baslangicX = 470;
            int baslangicY = 445;
            bagArryX.Add(baslangicX.ToString());
            bagArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 3; i++)
            {
                baslangicX = baslangicX + 50;
                bagArryX.Add((baslangicX).ToString());
                bagArryY.Add((baslangicY).ToString());
            }
            //ini 2. sıra
            baslangicX = 470;
            baslangicY = 496;
            bagArryX.Add(baslangicX.ToString());
            bagArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 3; i++)
            {
                baslangicX = baslangicX + 50;
                bagArryX.Add((baslangicX).ToString());
                bagArryY.Add((baslangicY).ToString());
            }
            //ini 3. sıra
            baslangicX = 470;
            baslangicY = 546;
            bagArryX.Add(baslangicX.ToString());
            bagArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 3; i++)
            {
                baslangicX = baslangicX + 50;
                bagArryX.Add((baslangicX).ToString());
                bagArryY.Add((baslangicY).ToString());
            }
            //ini 4. sıra
            baslangicX = 470;
            baslangicY = 598;
            bagArryX.Add(baslangicX.ToString());
            bagArryY.Add(baslangicY.ToString());
            for (int i = 1; i < 3; i++)
            {
                baslangicX = baslangicX + 50;
                bagArryX.Add((baslangicX).ToString());
                bagArryY.Add((baslangicY).ToString());
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
        int pazarKontrolBekleDeger = 0;
        private void tmrPazarKurBekleTmr_Tick(object sender, EventArgs e)
        {
            pazarKontrolBekleDeger++;
            if (pazarKontrolBekleDeger < 30)
            {

                lblPazarKontrolDegerLbl.Text = pazarKontrolBekleDeger.ToString() + " / " + "30";
                //pictureBox3.BackColor = Functions.GetPixelColor(641, 628);
                //Color c = Functions.GetPixelColor(641, 628);
                //if (c.R == 30 && c.G == 31 && c.B == 23)
                //{
                //    pazarKontrolBekleDeger = 0;
                //    pazarKurDeger = 6;
                //    tmrPazarKur.Start();
                //    tmrPazarKurBekleTmr.Stop();
                //}
            }
            else
            {
                pazarKontrolBekleDeger = 0;
                pazarKurDeger = 6;
                tmrPazarKur.Start();
                tmrPazarKurBekleTmr.Stop();
            }
        }
        int pazarMouseSurukleX = 0;
        int pazarMouseSurukleY = 0;
        int mouseDragTimerInterval = 0;
        int hangiSlot = 0;
        int pazardakiItemSayisi = 0;
        private void tmrPazarItemSurukle_Tick(object sender, EventArgs e)
        {
            try
            {
                mouseDragTimerInterval++;
                if (mouseDragTimerInterval == 1)
                {
                    if (Convert.ToInt16(iniBosDoluKontrolArry[hangiSlot]) == 1)
                    {
                        pazarMouseSurukleX = Convert.ToInt16(pazarKurArryX[hangiSlot]);
                        pazarMouseSurukleY = Convert.ToInt16(pazarKurArryY[hangiSlot]);
                        Cursor.Position = new Point(pazarMouseSurukleX, pazarMouseSurukleY);
                    }
                    else
                    {
                        int a = iniKontrol - 2;

                        if (hangiSlot < 28 && pazardakiItemSayisi < 11)
                        {
                            hangiSlot++;
                            mouseDragTimerInterval = 0;
                        }
                        else
                        {
                            pazarMouseSurukleX = 0;
                            pazarMouseSurukleY = 0;
                            mouseDragTimerInterval = 0;
                            pazarKurDeger = 21;
                            hangiSlot = 0;
                            tmrPazarKur.Start();
                            tmrPazarItemSurukle.Stop();
                        }
                    }

                }
                else if (mouseDragTimerInterval == 2)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
                }
                else if (mouseDragTimerInterval == 3)
                {
                    Cursor.Position = new Point(377, 174);
                }
                else if (mouseDragTimerInterval == 4)
                {
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
                }
                else if (mouseDragTimerInterval == 5)
                {
                    tmrMetin.Start();
                    tmrPazarItemSurukle.Stop();
                }
                else if (mouseDragTimerInterval == 6)
                {
                    ultra(76, 1027);
                }
                else if (mouseDragTimerInterval == 7)
                {
                    ultra(117, 951);
                }
                else if (mouseDragTimerInterval == 10)
                {
                    Cursor.Position = new Point(459, 440);
                    tmrSec.Start();
                }
                else if (mouseDragTimerInterval == 14)
                {
                    Cursor.Position = new Point(459, 440);
                    tmrSec.Start();
                }
                else if (mouseDragTimerInterval == 15)
                {
                    int a = iniKontrol - 2;
                    if (hangiSlot < 28 && pazardakiItemSayisi < 11 && pazardakiItemSayisi < a)
                    {
                        pazarMouseSurukleX = 0;
                        pazarMouseSurukleY = 0;
                        mouseDragTimerInterval = 0;
                        hangiSlot++;
                        pazardakiItemSayisi++;

                    }
                    else
                    {
                        pazarMouseSurukleX = 0;
                        pazarMouseSurukleY = 0;
                        mouseDragTimerInterval = 0;
                        pazarKurDeger = 17;
                        hangiSlot = 0; ;
                        pazardakiItemSayisi = 0;
                        tmrPazarKur.Start();
                        tmrPazarItemSurukle.Stop();
                    }

                }
            }
            catch (Exception)
            {
                tmr2.Stop();
                tmrR.Stop();
                tmrGenel.Stop();
                pazarKontrolDeger = 0;
                baslatDeger = 0;
                pazarBozDeger = 0;
                mouseClickDeger = 0;
                mouseDragTimerInterval = 0;
                pazarKontrolBekleDeger = 0;
                pazarKurDeger = 0;
                tmrPazarItemSurukle.Stop();
                tmrSec.Stop();
                tmrBaslat.Stop();
                tmrPazarBoz.Stop();
                tmrPazarKontrol.Stop();
                tmrPazarKur.Stop();
                tmrHastane.Stop();
                tmrHastaneBas.Stop();
            }

        }

        private void ultra(int a, int b)
        {
            Cursor.Position = new Point(a, b);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
        }
        int mouseClickDeger = 0;
        private void tmrMauseClick_Tick(object sender, EventArgs e)
        {
            mouseClickDeger++;
            if (mouseClickDeger == 1)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            }
            else if (mouseClickDeger == 2)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
                mouseClickDeger = 0;
                tmrSec.Stop();
            }

        }
        int pazarBozDeger = 0;
        private void tmrPazarBoz_Tick(object sender, EventArgs e)
        {
            pazarBozDeger++;
            lblPazarKontrolDegerLbl.Text = pazarBozDeger.ToString();
            if (pazarBozDeger == 1)
            {
                Cursor.Position = new Point(51, 67);
                tmrSec.Start();
            }
            if (pazarBozDeger == 3)
            {
                pictureBox3.BackColor = Functions.GetPixelColor(882, 203); //882,203 benim ki , 
                lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                Color c = Functions.GetPixelColor(882, 203);
                if (c.R == 0 && c.G == 0 && c.B == 0)
                {
                    pazarBozDeger = 6;
                }
            }
            if (pazarBozDeger == 4)
            {
                Cursor.Position = new Point(777, 770); // ini açma yeri
                tmrSec.Start();
            }
            if (pazarBozDeger == 7)
            {
                Cursor.Position = new Point(973, 611); // pazar son slot yeri
            }
            if (pazarBozDeger == 9)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            }
            if (pazarBozDeger == 11)
            {
                Cursor.Position = new Point(927, 615); // pazar son slottan bir önceki yeri
            }
            if (pazarBozDeger == 13)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
            }
            if (pazarBozDeger == 15)
            {
                pazarBozDeger = 0;
                pazarKurDeger = 0;
                tmrPazarKur.Start();
                tmrPazarBoz.Stop();
            }
        }
        int baslatDeger = 0;
        private void tmrBaslat_Tick(object sender, EventArgs e)
        {
            baslatDeger++;
            if (baslatDeger == 2)
            {
                tmrPazarBoz.Start();
                baslatDeger = 0;
                pazarKurDeger = 0;
                tmrBaslat.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tmr2.Stop();
            tmrR.Stop();
            tmrGenel.Stop();
            pazarKontrolDeger = 0;
            baslatDeger = 0;
            pazarBozDeger = 0;
            mouseClickDeger = 0;
            mouseDragTimerInterval = 0;
            pazarKontrolBekleDeger = 0;
            pazarKurDeger = 0;
            tmrPazarItemSurukle.Stop();
            tmrSec.Stop();
            tmrBaslat.Stop();
            tmrPazarBoz.Stop();
            tmrPazarKontrol.Stop();
            tmrPazarKur.Stop();
            tmrHastane.Stop();
            tmrHastaneBas.Stop();
        }
        System.Collections.ArrayList yolArry = new System.Collections.ArrayList(); // listbox1
        System.Collections.ArrayList alacakArry = new System.Collections.ArrayList(); // listbox1
        System.Collections.ArrayList hastaneArry = new System.Collections.ArrayList(); // listbox1
        System.Collections.ArrayList intervalArry = new System.Collections.ArrayList(); // listbox1
        System.Collections.ArrayList yerArry = new System.Collections.ArrayList(); // listbox1
        void TxtVeriCek()
        {
            string yol = "D:\\yol.txt";
            StreamReader oku;
            oku = File.OpenText(yol);
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                yolArry.Add(yazi);
            }
            oku.Close();
        }
        void TxtVeriCek2()
        {
            string yol = "D:\\hastane.txt";
            StreamReader oku;
            oku = File.OpenText(yol);
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                hastaneArry.Add(yazi);
            }
            oku.Close();
        }
        void TxtVeriCekYer()
        {
            string yol = "D:\\yer.txt";
            StreamReader oku;
            oku = File.OpenText(yol);
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                yerArry.Add(yazi);
            }
            oku.Close();
        }
        void TxtVeriYazYer()
        {
            string yol = "D:\\yer.txt";
            StreamWriter s = new StreamWriter(yol);
            for (int i = 0; i < yerArry.Count; i++)
            {
                s.WriteLine(yerArry[i].ToString());
            }
            s.Close();
        }
        void TxtVeriCekInterval()
        {
            string yol = "D:\\ayar.txt";
            StreamReader oku;
            oku = File.OpenText(yol);
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                intervalArry.Add(yazi);
            }
            oku.Close();
        }
        void TxtVeriCekAlacak()
        {
            string yol = "D:\\alacak.txt";
            StreamReader oku;
            oku = File.OpenText(yol);
            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                alacakArry.Add(yazi);
            }
            oku.Close();
        }
        private void dosyaKontrolSil()
        {
            if (Directory.Exists(yolArry[0].ToString()))
            {
                Directory.Delete(yolArry[0].ToString(), true);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tmrItemKontrolBag.Start();

        }
        int hastaneDeger = 0;
        int islem = 0;
        int tur = 0;
        private void tmrHastane_Tick(object sender, EventArgs e)
        {
            try
            {
                hastaneDeger++;
                lblPazarKontrolDegerLbl.Text = hastaneDeger.ToString();
                if (hastaneDeger == 1)
                {
                    //Cursor.Position = new Point(973, 611); // pazar son slot yeri
                    //tmrSec.Start();
                }
                if (hastaneDeger == 1) // Rpr için gerekli kordinatlar ve renk kodları girilecek.
                {
                    lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
                    pictureBox3.BackColor = Functions.GetPixelColor(751, 323);
                    Color c3 = Functions.GetPixelColor(751, 323);
                    Color c = Functions.GetClosestColor(c3);
                    if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        tmrHastaneBas.Start();
                        tmrHastane.Stop();
                    }
                    pictureBox3.BackColor = Functions.GetPixelColor(984, 283);
                    Color c2 = Functions.GetPixelColor(984, 283);
                    if (c2.R == 62 && c2.G == 11 && c2.B == 76)
                    {
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                        Functions.SendKey("0");
                    }
                }
                if (hastaneDeger == 2)
                {
                    pictureBox3.BackColor = Functions.GetPixelColor(149, 67);
                    Color c3 = Functions.GetPixelColor(149, 67);
                    Color c = Functions.GetClosestColor(c3);
                    if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        tmr2.Stop();
                        tmrR.Stop();
                        Functions.SendKey("3");
                        Functions.SendKey("3");
                        Functions.SendKey("3");
                        Functions.SendKey("3");
                        Functions.SendKey("3");
                    }
                    else
                    {
                        //tmrR.Start();
                        //tmr2.Start();
                    }
                }
                if (hastaneDeger > 3)
                {
                    hastaneDeger = 0;
                    //new Process() { StartInfo = new ProcessStartInfo(@"D:\Bekle.exe") { Verb = "runas" } }.Start();
                    //tmrHastane.Stop();
                    //Environment.Exit(1);
                    //hastaneDeger = 0;
                }
            }
            catch (Exception s)
            {
                System.Diagnostics.Process.Start(@"D:\Bekle.exe");
                tmrHastane.Stop();
                Environment.Exit(1);
                tmr2.Stop();
                tmrR.Stop();
                tmrGenel.Stop();
                pazarKontrolDeger = 0;
                baslatDeger = 0;
                pazarBozDeger = 0;
                mouseClickDeger = 0;
                mouseDragTimerInterval = 0;
                pazarKontrolBekleDeger = 0;
                pazarKurDeger = 0;
                tmrPazarItemSurukle.Stop();
                tmrSec.Stop();
                tmrBaslat.Stop();
                tmrPazarBoz.Stop();
                tmrPazarKontrol.Stop();
                tmrPazarKur.Stop();
                tmrHastane.Stop();
                tmrHastaneBas.Stop();
            }
        }
        int hastaneBas = 0;
        int hastaneTur = 0;
        private void tmrHastaneBas_Tick(object sender, EventArgs e)
        {
            try
            {
                hastaneBas++;
                lblPazarKontrolDegerLbl.Text = hastaneBas.ToString();
                if (hastaneBas == 1)
                {
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                    Functions.SendKey("9");
                }
                //if (hastaneBas == 2)
                //{
                //    Cursor.Position = new Point(917, 103); // lwl sec
                //    tmrSec.Start();
                //}
                if (hastaneBas == 2)
                {
                    Cursor.Position = new Point(893, 572); // hangisi ts olacağını seç
                    tmrSec.Start();
                }
                if (hastaneBas == 3)
                {
                    Cursor.Position = new Point(433, 467); // hangisi ts olacağını seç
                    tmrSec.Start();
                }
                if (hastaneBas == 4)
                {
                    Cursor.Position = new Point(778, 769); // ın ac
                    tmrSec.Start();

                }
                if (hastaneBas == 6)
                {
                    hastaneDeger = 0;
                    tmrHastane.Start();
                    tmrHastaneBas.Stop();//Değiştirilecek timer r için
                }
                if (hastaneBas > 10)
                {
                    //System.Diagnostics.Process.Start(@"D:\Bekle.exe");
                    //tmrHastane.Stop();
                    //Environment.Exit(1);
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Process.Start(@"D:\Bekle.exe");
                tmrHastane.Stop();
                Environment.Exit(1);
                tmr2.Stop();
                tmrR.Stop();
                tmrGenel.Stop();
                pazarKontrolDeger = 0;
                baslatDeger = 0;
                pazarBozDeger = 0;
                mouseClickDeger = 0;
                mouseDragTimerInterval = 0;
                pazarKontrolBekleDeger = 0;
                pazarKurDeger = 0;
                tmrPazarItemSurukle.Stop();
                tmrSec.Stop();
                tmrBaslat.Stop();
                tmrPazarBoz.Stop();
                tmrPazarKontrol.Stop();
                tmrPazarKur.Stop();
                tmrHastane.Stop();
                tmrHastaneBas.Stop();
            }
        }
        int degerUltra = 0;
        private void tmrEkranRakam_Tick(object sender, EventArgs e)
        {
            degerUltra++;
            if (degerUltra == 1)
            {
                Cursor.Position = new Point(162, 1021);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            }
            if (degerUltra == 2)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
            }
            if (degerUltra == 3)
            {
                Cursor.Position = new Point(661, 982);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
            }
            if (degerUltra == 4)
            {
            }
            if (degerUltra == 5)
            {
                degerUltra = 0;
                tmrEkranRakam.Stop();
            }
        }
        Random rnd = new Random();
        int metinDeger = 0;
        private void tmrMetin_Tick(object sender, EventArgs e)
        {
            if (metinDeger + 1 > fiyatDegeri.Length)
            {
                tmrMetin.Stop();
                metinDeger = 0;
                tmrPazarItemSurukle.Start();
                return;
            }
            SendKeys.Send(fiyatDegeri[metinDeger].ToString());
            metinDeger++;
            tmrMetin.Stop();
            int newDuration = rnd.Next(150, 500);
            tmrMetin.Interval = newDuration;
            tmrMetin.Start();
        }
        int rDeger = 0;
        private void tmrR2_Tick(object sender, EventArgs e)
        {
            if (rDeger == 0)
            {
                Functions.SendKey("R");
                tmr2.Interval = Convert.ToInt16(intervalArry[1]);
                rDeger = 1;
            }
            if (rDeger == 1)
            {
                Functions.SendKey("2");
                tmr2.Interval = Convert.ToInt16(intervalArry[0]);
                rDeger = 0;
            }

        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            Functions.SendKey("2");
        }
        int genelDEger = 0;
        private void tmrGenel_Tick(object sender, EventArgs e)
        {
            genelDEger++;
            label8.Text = genelDEger.ToString();
            if (genelDEger == 1)
            {
                Color c3 = Functions.GetPixelColor(859, 257);
                if (c3.R != 5 && c3.G != 5 && c3.B != 70)
                {
                    Cursor.Position = new Point(778, 769); // ın ac
                    tmrSec.Start();
                }
            }
            if (genelDEger == 3)
            {
                Cursor.Position = new Point(971, 405); // çöp yeri
                tmrSec.Start();
                if (Convert.ToInt16(yerArry[0]) == 0)
                {
                    tmrIniBagKontrolTmr.Start();
                }
            }
            if (genelDEger > 80)
            {
                //ultra(1872,33);//Kapatma yeri click
                Application.Exit();
                //System.Diagnostics.Process.Start(@"D:\Bekle.exe");
                //tmrHastane.Stop();
                //Environment.Exit(1);
            }
        }
        int i = 0;
        private void tmrDeneme_Tick(object sender, EventArgs e)
        {
            iniBosDoluKontrol = 0;
            bagKontrolArry.Clear();
            pictureBox3.BackColor = Functions.GetPixelColor(Convert.ToInt16(bagArryX[i]), Convert.ToInt16(bagArryY[i]));
            Cursor.Position = new Point(Convert.ToInt16(bagArryX[i]), Convert.ToInt16(bagArryY[i]));
            lblPazarKontrolDeger.Text = pictureBox3.BackColor.R + ";" + pictureBox3.BackColor.G + ";" + pictureBox3.BackColor.B + " " + Cursor.Position.X + ";" + Cursor.Position.Y;
            Color c = Functions.GetClosestColor(Functions.GetPixelColor(Convert.ToInt16(bagArryX[i]), Convert.ToInt16(bagArryY[i])));
            if (c.R == 0 && c.G == 0 && c.B == 0)
            {
                bagKontrolArry.Add("1");
                MessageBox.Show("1");
                bagBolDoluKontrol++;
                label10.Text = bagBolDoluKontrol.ToString();
                i = i + 1;
            }
            else
            {
                MessageBox.Show("0");
                bagKontrolArry.Add("0");
                i = i + 1;
            }
        }
        int bagDeger = 0;
        int hangiYer = 0;
        int hangiBag = 0;
        int surukelenenItemSayisibag = 0;
        int bag1mi2mi = 1;
        private void tmrBag_Tick(object sender, EventArgs e)
        {
            bagDeger++;
            label8.Text = bagDeger.ToString();
            if (bagDeger == 1)
            {
                //bagKontrol();
                label10.Text = iniBosDoluKontrol.ToString();
                int a = surukelenenItemSayisibag + 1;
                if (bagKontrolTmrDegerGenel < a)
                {
                    if (bag1mi2mi == 2)
                    {
                        yerArry.Clear();
                        yerArry.Add("1");
                        TxtVeriYazYer();
                        genelDEger = 5;
                        bagDeger = 0;
                        tmrHastane.Start();
                        tmrGenel.Start();
                        tmrBag.Stop();
                    }
                    if (bag1mi2mi == 1)
                    {
                        bag1mi2mi = 2;
                        bagDeger = 0;
                         hangiYer = 0;
                         hangiBag = 0;
                        genelDEger = 0;
                         surukelenenItemSayisibag = 0;
                         itemKontrolTmrDeger = 0;
                         itemKontrolTmrDegerGenel = 0;
                         iniGenisKontrolSayi = 0;
                         iniGenisKontrolVarYok = -1;
                        iniKontrolArry.Clear();
                        iniBagKontrolDeger = 0;
                         bagKontrolTmrDeger = 0;
                         bagKontrolTmrDegerGenel = 0;
                        bagKontrolArry.Clear();
                        tmrIniBagKontrolTmr.Start();
                        tmrBag.Stop();
                    }
               
                }
            }
            if (bagDeger == 2)
            {
                if (Convert.ToInt16(iniKontrolArry[hangiYer]) == 1)
                {
                    pazarMouseSurukleX = Convert.ToInt16(iniArryX[hangiYer]) + 20;
                    pazarMouseSurukleY = Convert.ToInt16(iniArryY[hangiYer]);
                    Cursor.Position = new Point(pazarMouseSurukleX, pazarMouseSurukleY);
                }
                else
                {
                    int a = iniArryX.Count + 1;
                    if (hangiYer < a)
                    {
                        hangiYer++;
                        bagDeger = 0;
                    }
                    else
                    {
                        genelDEger = 5;
                        bagDeger = 0;
                        tmrHastane.Start();
                        tmrGenel.Start();
                        tmrBag.Stop();
                    }
                }
            }
            if (bagDeger == 3)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new UIntPtr(0));
            }
            if (bagDeger == 5)
            {
                if (Convert.ToInt16(bagKontrolArry[hangiBag]) == 0)
                {
                    pazarMouseSurukleX = Convert.ToInt16(bagArryX[hangiBag]) + 20;
                    pazarMouseSurukleY = Convert.ToInt16(bagArryY[hangiBag]);
                    Cursor.Position = new Point(pazarMouseSurukleX, pazarMouseSurukleY);
                }
                else
                {
                    if (hangiBag < bagArryX.Count)
                    {
                        hangiBag++;
                        bagDeger = 4;
                    }
                }
            }
            if (bagDeger == 6)
            {
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new UIntPtr(0));
                surukelenenItemSayisibag++;
            }
            if (bagDeger == 7)
            {
                if (hangiYer > iniKontrolArry.Count)
                {
                    tmrHastane.Start();
                    tmrGenel.Start();
                    tmrBag.Stop();
                }
                else
                {
                    hangiBag++;
                    hangiYer++;
                    bagDeger = 0;
                }
            }
        }

        int itemKontrolTmrDeger = 0;
        int itemKontrolTmrDegerGenel = 0;
        private void tmrItemKontrol_Tick(object sender, EventArgs e)
        {
            if (itemKontrolTmrDeger < iniArryX.Count)
            {
                int a = Convert.ToInt16(iniArryX[itemKontrolTmrDeger]);
                int b = Convert.ToInt16(iniArryY[itemKontrolTmrDeger]);
                int kontrol = iniGenisKontrolGezginFnc(a, b);
                if (kontrol == 1)
                {
                    iniKontrolArry.Add("1");
                    itemKontrolTmrDeger++;
                    itemKontrolTmrDegerGenel++;
                }
                else
                {
                    iniKontrolArry.Add("0");
                    itemKontrolTmrDeger++;
                }
            }
            else
            {
                for (int i = 0; i < iniKontrolArry.Count; i++)
                {
                    listBox2.Items.Add(iniKontrolArry[i]);
                }
                tmrItemKontrol.Stop();
            }


        }

        int bagKontrolTmrDeger = 0;
        int bagKontrolTmrDegerGenel = 0;
        private void tmrItemKontrolBag_Tick(object sender, EventArgs e)
        {
            if (bagKontrolTmrDeger < bagArryX.Count)
            {
                int a = Convert.ToInt16(bagArryX[bagKontrolTmrDeger]);
                int b = Convert.ToInt16(bagArryY[bagKontrolTmrDeger]);
                int kontrol = iniGenisKontrolGezginFnc(a, b);
                if (kontrol == 1)
                {
                    bagKontrolArry.Add("1");
                    bagKontrolTmrDeger++;
                }
                else
                {
                    bagKontrolArry.Add("0");
                    bagKontrolTmrDeger++;
                    bagKontrolTmrDegerGenel++;
                }
            }
            else
            {
                for (int i = 0; i < bagKontrolArry.Count; i++)
                {
                    listBox1.Items.Add(bagKontrolArry[i]);
                }
                tmrItemKontrolBag.Stop();
            }
        }
        int iniBagKontrolDeger = 0;
        private void tmrIniBagKontrolTmr_Tick(object sender, EventArgs e)
        {
            iniBagKontrolDeger++;
            if (iniBagKontrolDeger == 1)
            {
                tmrItemKontrol.Start();
                Color c = Functions.GetPixelColor(536, 275);
                Color c3 = Functions.GetClosestColor(c);
                if (c3.R != 0 && c3.G != 0 && c3.B != 0)
                {
                    Cursor.Position = new Point(647, 299); // bag ac
                    tmrSec.Start();
                }
            }
            if (iniBagKontrolDeger == 4)
            {
                if (bag1mi2mi == 1)
                {
                    Cursor.Position = new Point(496, 403); // bag 1
                    tmrSec.Start();
                }
                else
                {
                    Cursor.Position = new Point(551, 403); // bag 2
                    tmrSec.Start();
                }
            }
            if (iniBagKontrolDeger == 20)
            {
                iniGenisKontrolSayi = 0;
                tmrItemKontrolBag.Start();
            }
            if (iniBagKontrolDeger == 30)
            {
                if (itemKontrolTmrDegerGenel > 5)
                {
                    tmrHastaneBas.Stop();
                    tmrHastane.Stop();
                    tmrGenel.Stop();
                    tmrIniBagKontrolTmr.Stop();
                    tmrBag.Start();
                }
            }
        }
    }
}

