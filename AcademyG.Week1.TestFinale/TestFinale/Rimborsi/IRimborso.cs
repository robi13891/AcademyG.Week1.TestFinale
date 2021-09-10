using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Rimborsi
{
    public interface IRimborso
    {
        public Spesa SpesaApprovata { get; set; }
        public double Importo { get;  }

        double CalcoloImporto();
    }
}
