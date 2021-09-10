using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Handler
{
    public class ManagerHandler : AbstractHandler
    {
        public override Spesa Handle(Spesa spesa)
        {
            if(spesa.Importo > 0 && spesa.Importo <= 400)
            {
                spesa.LivelloApprovazione = "Manager";
                spesa.IsApproved = true;
                return spesa;
            }
            return base.Handle(spesa);
        }
    }
}
