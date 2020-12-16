using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Projekt_EH515M.Entities
{
    public class Epito
    {
        public Ellipszis CreateNewKor()
        {
            return new Ellipszis();
        }

        public Vonal CreateNewVonal()
        {
            return new Vonal();
        }
    }
}
