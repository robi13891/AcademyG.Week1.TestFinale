using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Handler
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        Spesa Handle(Spesa spesa); 

        
    }
}
