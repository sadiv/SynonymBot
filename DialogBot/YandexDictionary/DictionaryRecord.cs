using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sadiv.Syn
{

    public class AttributesRecord
    {
        public string text { get; set; }
        public string num { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
        public List<AttributesRecord> tr { get; set; }
        public List<AttributesRecord> syn { get; set; }
    }

    public class DictionaryRecord
    {
        public List<AttributesRecord> def { get; set; }
        public List<AttributesRecord> tr { get; set; }
        public List<AttributesRecord> syn { get; set; }
        public List<AttributesRecord> mean { get; set; }
        public List<AttributesRecord> ex { get; set; }
        
    }
}