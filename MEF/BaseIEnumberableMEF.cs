using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYQ.MEF
{
   public  class BaseIEnumberableMEF<T> : BaseComposeMEF where T : DAL.IBase
    {
        [ImportMany]
        public IEnumerable<T> cards { get; set; } 
    }
}
