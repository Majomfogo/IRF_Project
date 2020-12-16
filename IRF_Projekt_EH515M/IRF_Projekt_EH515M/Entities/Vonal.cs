using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IRF_Projekt_EH515M.Entities
{
    public class Vonal:Label
    {
        public Vonal()
        {
            AutoSize = false;
            Width = 120;
            Height = 6;
            Paint += Ellipszis_Paint1;
        }


        private void Ellipszis_Paint1(object sender, PaintEventArgs e)
        {
            DrawVonal(e.Graphics);
        }


        public void DrawVonal(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), 0, 0, Width, Height);
        }
    }
}
