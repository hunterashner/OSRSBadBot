using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSBadBot
{
    internal class Chicken : Enemy
    {
        //rgb(147, 39, 22) red on head
        //rgb(152, 137, 110) average color
        public Color MainColor { get; set; }
        public string Name { get; set; }

        public Chicken(Color mainColor, string name)
        {
            MainColor = mainColor;
            Name = name;
        }
    }
}
