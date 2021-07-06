using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace WYQ.MEF
{
    public class BaseMEF<T> : BaseComposeMEF where T: DAL.IBase
    {
        [Import]
        public T test { get; set; } 
    }
}
