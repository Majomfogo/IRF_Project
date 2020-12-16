﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRF_Projekt_EH515M.Entities;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace IRF_Projekt_EH515M
{

    public partial class Form1 : Form
    {
        List<Rendelés> Rendelések;
        public Epito Epit;
        private Random random = new Random();
        FutarszolgalatEntities context = new FutarszolgalatEntities();
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            
            context.Rendelés.Load();
            context.Futár.Load();
            context.Étterem.Load();

            Startup();
            KeresesBetoltes();
        }

        private void Startup()
        {

            foreach (Futár f in context.Futár)
            {
                f.Foglalt = false;
            }
            context.SaveChanges();
            comboEtterem.DataSource = context.Étterem.ToList();
            comboEtterem.DisplayMember = "Név";
            timer1.Enabled = true;
            timer1.Interval = 1000;

        }

        private void KeresesBetoltes()
        {
            var kijelzo = from x in context.Rendelés
                          select new
                          {
                              Rendelészám = x.RendelésID,
                              Futárazonosító = x.FutárFK,
                              Aktív = x.Aktív
                          };
            dataGridView1.DataSource = kijelzo.ToList();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            AddOrder();

        }

        private void AddOrder()
        {
            var étteremszám = (from s in context.Étterem select s).Count();

            Rendelés ujrendeles = new Rendelés();
            ujrendeles.Rögzítés = DateTime.Now;
            ujrendeles.Elfogadva = ujrendeles.Rögzítés;
            ujrendeles.Felvéve = ujrendeles.Rögzítés.AddSeconds(random.Next(10, 16));
            ujrendeles.Leadva = ujrendeles.Felvéve.AddSeconds(random.Next(10, 16));
            ujrendeles.Késés = random.Next(0, 16);
            ujrendeles.Ár = random.Next(2000, 20000);
            ujrendeles.Aktív = true;

            try
            {
                var szabad = from x in context.Futár
                             where x.Foglalt == false
                             select x;
                ujrendeles.FutárFK = szabad.First().FutárSK;
            }
            catch (Exception)
            {

                MessageBox.Show("Nincs szabad futár a területen!");
            }
            ujrendeles.ÉtteremFK = random.Next(1, étteremszám + 1);

            context.Rendelés.Add(ujrendeles);
            
            var query = from futar in context.Futár
                        where futar.FutárSK == ujrendeles.FutárFK
                        select futar;
           
            foreach (Futár fut in query)
            {
                fut.Foglalt = true;
            }
            
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            KeresesBetoltes();
            
        }

        private void txtFutar_TextChanged(object sender, EventArgs e)
        {

            Regex regex1 = new Regex("^[0-9]{0,6}$");
            

            if (!regex1.IsMatch(txtFutar.Text))
            {
                MessageBox.Show("Betű vagy túl sok számjegyhasználata!");
                txtFutar.Text = "";
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtFutar.Text))
                {
                    try
                    {
                        int futarid = Convert.ToInt32(txtFutar.Text);
                        dataGridView1.DataSource = (from x in context.Rendelés
                                                    where x.FutárFK == futarid
                                                    select new
                                                    {
                                                       x.RendelésID,
                                                       x.Ár,
                                                       x.FutárFK,
                                                       x.Futár.Név,
                                                       x.Felvéve,
                                                       x.ÉtteremFK,
                                                       Hely = x.Étterem.Név
                                                    }).ToList();
                    }
                    catch (Exception)
                    {

                        return;
                    }
                }
               
            }
            
            
             
        }

        private void txtRendeles_TextChanged(object sender, EventArgs e)
        {
            Regex regex2 = new Regex("^[0-9]{0,6}$");


            if (!regex2.IsMatch(txtFutar.Text))
            {
                MessageBox.Show("Betű vagy túl sok számjegyhasználata!");
                txtRendeles.Text = "";
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(txtRendeles.Text))
                {
                    try
                    {
                        int rendelesid = Convert.ToInt32(txtRendeles.Text);
                        dataGridView1.DataSource = (from x in context.Rendelés
                                                    where x.RendelésID == rendelesid
                                                    select new
                                                    {
                                                        x.RendelésID,
                                                        x.Ár,
                                                        x.FutárFK,
                                                        x.Futár.Név,
                                                        x.Felvéve,
                                                        x.ÉtteremFK,
                                                        Hely = x.Étterem.Név
                                                    }).ToList();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("hiba");
                    }
                }

            }

        }

        private void comboEtterem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Étterem etterem = (Étterem)comboEtterem.SelectedItem;
            dataGridView1.DataSource = (from x in context.Rendelés
                                        where x.ÉtteremFK == etterem.ÉtteremSK
                                        select new
                                        {
                                            Hely = x.Étterem.Név,
                                            x.RendelésID,
                                            x.Aktív,
                                            x.Ár,
                                            x.FutárFK,
                                            x.Futár.Név,
                                            x.Felvéve,
                                            x.ÉtteremFK
                                            
                                        }).ToList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Rendelés rend in context.Rendelés)
            {
                if ((rend.Aktív==true) && (rend.Leadva.AddSeconds(rend.Késés) < DateTime.Now))
                { rend.Aktív = false;
                    foreach (Futár fut in context.Futár)
                    {
                        if (fut.FutárSK == rend.FutárFK)
                            fut.Foglalt = false;
                    }
                }
            }
            AddOrder();
        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnTimerStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            panelStatus.Controls.Clear();

            int sorindex = dataGridView1.CurrentCell.RowIndex;
            //int oszlopindex = dataGridView1.CurrentCell.ColumnIndex;

            string kivalasztott=dataGridView1.Rows[sorindex].Cells[0].Value.ToString();
            int id = Convert.ToInt32(kivalasztott);

            var rendel = (from x in context.Rendelés
                         where x.RendelésID == id
                         select new
                         {
                             x.Elfogadva,
                             x.Felvéve,
                             x.Leadva,
                             x.Késés
                         }).ToList();
                         


            if (rendel.First().Elfogadva < DateTime.Now)
            {
                Epit = new Epito();
                var elfogadva = Epit.CreateNewKor();
                panelStatus.Controls.Add(elfogadva);
                elfogadva.Top = 50;

                var elfogadvavonal = Epit.CreateNewVonal();
                panelStatus.Controls.Add(elfogadvavonal);
                elfogadvavonal.Top = 62;
                elfogadvavonal.Left = elfogadva.Left + 20;
            }

            if (rendel.First().Felvéve < DateTime.Now)
            {
                var felveve = Epit.CreateNewKor();
                panelStatus.Controls.Add(felveve);
                felveve.Top = 50;
                felveve.Left = 130;

                var felvevevonal = Epit.CreateNewVonal();
                panelStatus.Controls.Add(felvevevonal);
                felvevevonal.Top = 62;
                felvevevonal.Left = felveve.Left + 20;
            }

            if (rendel.First().Leadva.AddSeconds(rendel.First().Késés) < DateTime.Now)
            {
                var leadva = Epit.CreateNewKor();
                panelStatus.Controls.Add(leadva);
                leadva.Top = 50;
                leadva.Left = 260;
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Munkalap megnyitása
            try
            {
                Rendelések = context.Rendelés.ToList(); 
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {

                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");                
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }

            //Fejléc
            string[] headers = new string[] {
                "Rendelésazonosító",
                "Ár",
                "Rögzítés ideje",
                "Elfogadva",
                "Felvétel ideje",
                "Leadás várható ideje",
                "Késés (perc)",
                "Szállító futár azonosítója",
                "Étterem azonosítója"};
            xlSheet.Cells[1, 1] = headers[0];

            //Adatok betöltése
            object[,] values = new object[Rendelések.Count, headers.Length];
            int counter = 0;
            foreach (Rendelés r in Rendelések)
            {
                values[counter, 0] = r.RendelésID;
                values[counter, 1] = r.Ár;
                values[counter, 2] = r.Rögzítés;
                values[counter, 3] = r.Elfogadva;
                values[counter, 4] = r.Felvéve;
                values[counter, 5] = r.Leadva;
                values[counter, 6] = r.Késés;
                values[counter, 7] = r.FutárFK;
                values[counter, 8] = r.ÉtteremFK;                
                counter++;
                xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
                Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));

                //Formázás
                headerRange.Font.Bold = true;
                headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.EntireColumn.AutoFit();
                headerRange.RowHeight = 40;
                headerRange.Interior.Color = Color.LightBlue;
                headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
            }
        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
