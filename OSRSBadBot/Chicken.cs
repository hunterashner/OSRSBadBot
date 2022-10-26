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
        public Color MainColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Chicken(Color mainColor, string name)
        {
            MainColor = mainColor;
            Name = name;
        }
    }
}
