using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class User : Person
    {
        public string Country { get; set; }

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

    }
}
