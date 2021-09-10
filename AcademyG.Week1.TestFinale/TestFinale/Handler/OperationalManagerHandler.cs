using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Handler
{
    public class OperationalManagerHandler : AbstractHandler
    {
        public override Spesa Handle(Spesa spesa)
        {
            if (spesa.Importo > 400 && spesa.Importo <= 1000)
            {
                spesa.LivelloApprovazione = "Operational Manager";
                spesa.IsApproved = true;
                return spesa;
            }
            return base.Handle(spesa);
        }
    }
}
