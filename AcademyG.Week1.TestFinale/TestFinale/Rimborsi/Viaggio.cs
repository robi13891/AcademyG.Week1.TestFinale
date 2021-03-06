using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Rimborsi
{
    public class Viaggio : IRimborso
    {
        public Spesa SpesaApprovata { get; set; }
        public double Importo
        {
            get { return CalcoloImporto(); }
        }

        public double CalcoloImporto()
        {
            return SpesaApprovata.Importo + 50;
        }
    }
}
