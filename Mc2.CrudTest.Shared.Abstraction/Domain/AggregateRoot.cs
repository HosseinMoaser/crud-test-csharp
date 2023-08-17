using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Abstraction.Domain
{
    public abstract class AggregateRoot <T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        private bool _isVersionIncremented;
        protected void IncreamentVersion()
        {
            if(_isVersionIncremented)
            {
                return;
            }

            Version++;
            _isVersionIncremented = true;
        }
    }
}
