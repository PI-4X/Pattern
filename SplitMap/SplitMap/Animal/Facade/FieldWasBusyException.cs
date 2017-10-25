using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Facade
{
    [Serializable()]
    public class FieldWasBusyException : ApplicationException
    {
        public FieldWasBusyException() { }

        public FieldWasBusyException(string message) : base(message) { }

        public FieldWasBusyException(string message, Exception inner) : base(message, inner) { }

        protected FieldWasBusyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
