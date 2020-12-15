using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IRF_Projekt_EH515M
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        FutarszolgalatEntities context = new FutarszolgalatEntities();
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
        }

        private void KeresesBetoltes()
        {
            var kijelzo = from x in context.Rendelés
                          select new
                          {
                              Rendelészám = x.RendelésID,
                              Futárazonosító = x.FutárFK
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
            ujrendeles.Felvéve = ujrendeles.Rögzítés.AddSeconds(random.Next(1, 16));
            ujrendeles.Leadva = ujrendeles.Felvéve.AddSeconds(random.Next(1, 16));
            ujrendeles.Késés = random.Next(1, 16);
            ujrendeles.Ár = random.Next(2000, 20000);
            ujrendeles.Aktív = true;

            try
            {
                var szabad = from x in context.Futár
                             where x.Foglalt == false
                             select x.FutárSK;
                ujrendeles.FutárFK = szabad.First();
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


            }
            catch (Exception)
            {

                throw;
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
    }
}
