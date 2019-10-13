using System;
using System.Collections.Generic;
using System.Text;

namespace Tti.Estate.Data.Entities
{
    public class Color : BaseEntity
    {
        public string codigoColor { set; get; }
        public string nombreColor { set; get; }

        public JsonColor jsonColor { set; get; }
         
    }
}
