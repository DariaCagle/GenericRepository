using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data
{
    public class Param
    {
        public Param(string key, object value)
        {
            MyKey = key;
            MyValue = value;
        }

        public string MyKey { get; set; }
        public object MyValue { get; set; }
    }
}
