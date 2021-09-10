using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFinale.Handler
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }

        public virtual Spesa Handle(Spesa spesa)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(spesa);
            }
            return null;
        }
    }
}
