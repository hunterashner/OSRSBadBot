using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OSRSBadBot
{
    internal interface Enemy
    {
        public Color MainColor { get; set; }
        public string Name { get; set; }
    }
}
