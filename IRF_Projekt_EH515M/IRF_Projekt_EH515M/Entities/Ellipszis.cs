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
            DrawKor(e.Graphics);
        }


        public void DrawKor(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), 0, 0, Width, Height);
        }
    }
}
