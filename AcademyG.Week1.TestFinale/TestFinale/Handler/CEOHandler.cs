using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Handler
{
    public class CEOHandler : AbstractHandler
    {
        public override Spesa Handle(Spesa spesa)
        {
            if (spesa.Importo > 1000 && spesa.Importo <= 2500)
            {
                spesa.LivelloApprovazione = "CEO";
                spesa.IsApproved = true;
                return spesa;
            }
            return base.Handle(spesa);
        }
    }
}
