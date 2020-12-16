using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IRF_Projekt_EH515M.Entities
{
    public class Ellipszis:Label
    {
        public Ellipszis()
        {
            AutoSize = false;
            Width = 30;
            Height = Width;
            Paint += Ellipszis_Paint1;
        }

        
        private void Ellipszis_Paint1(object sender, PaintEventArgs e)
        {
            DrawKerek(e.Graphics);
        }

       
        public void DrawVonal(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), 0, 0, 60, 20);
        }
        public void DrawKerek(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), 0, 0, Width, Height);
        }
    }
}
