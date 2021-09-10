using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale
{
    public class Spesa
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
        public string Descrizione { get; set; }
        public double Importo { get; set; }
        public bool IsApproved { get; set; } = false;
        public string LivelloApprovazione { get; set; }
        public double ImportoRimborsato { get; set; }
        public Spesa()
        {
            IsApproved = false;
        }

        
    }
}
