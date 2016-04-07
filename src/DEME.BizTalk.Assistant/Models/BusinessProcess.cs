using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEME.BizTalk.Assistant.Models
{
    public class BusinessProcess
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Process { get; set; }
        public string Destination { get; set; }

        public override string ToString()
        {
            return $"{Source} - {Process} - {Destination}";
        }
    }
}
