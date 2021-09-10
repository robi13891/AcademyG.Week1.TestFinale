using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Rimborsi
{
    public class Altro : IRimborso
    {
        public Spesa SpesaApprovata { get; set; }
        public double Importo
        {
            get { return CalcoloImporto(); }
        }

        public double CalcoloImporto()
        {
            return (SpesaApprovata.Importo * 10) / 100;
        }
    }
}
