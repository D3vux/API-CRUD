using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entity
{
    public class SettingsDataAccess
    {
        public int name { get; set; }
        public List<SettingsConnection> connections { get; set; }
    }
    public class SettingsConnection
    {
        public string name { get; set; }
        public string server { get; set; }
        public string database { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }
}
