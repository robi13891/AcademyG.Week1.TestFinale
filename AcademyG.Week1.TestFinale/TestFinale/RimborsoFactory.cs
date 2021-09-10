using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFinale.Rimborsi;

namespace TestFinale
{
    public class RimborsoFactory
    {
        public IRimborso NuovoRimborso(Spesa spesaApprovata)
        {
            IRimborso rimborso = null;
            if (spesaApprovata.Categoria.Equals("Viaggio"))
            {
                rimborso = new Viaggio { SpesaApprovata = spesaApprovata };
                spesaApprovata.ImportoRimborsato = rimborso.Importo;
            }
            else if (spesaApprovata.Categoria.Equals("Alloggio"))
            {
                rimborso = new Alloggio { SpesaApprovata = spesaApprovata };
                spesaApprovata.ImportoRimborsato = rimborso.Importo;
            }
            else if (spesaApprovata.Categoria.Equals("Vitto"))
            {
                rimborso = new Vitto { SpesaApprovata = spesaApprovata };
                spesaApprovata.ImportoRimborsato = rimborso.Importo;
            }
            else if (spesaApprovata.Categoria.Equals("Altro"))
            {
                rimborso = new Altro { SpesaApprovata = spesaApprovata };
                spesaApprovata.ImportoRimborsato = rimborso.Importo;
            }

            return rimborso;

        }
    }
}
