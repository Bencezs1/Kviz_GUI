using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvizProbaGUI
{
    internal class Kerdes
    {
        public string Kerdeszoveg { get; private set; }
        public string Valasz1 { get; private set; }
        public string Valasz2 { get; private set; }
        public string Valasz3 { get; private set; }
        public string Valasz4 { get; private set; }
        public string Helyesvalasz { get; private set; }
        public Kerdes(string sor)
        {
            string[] resz = sor.Split(';');
            Kerdeszoveg = resz[0];
            Valasz1 = resz[1].Split(' ')[0];
            Valasz2 = resz[1].Split(' ')[1];
            Valasz3 = resz[1].Split(' ')[2];
            Valasz4 = resz[1].Split(' ')[3];
            Helyesvalasz = resz[2];

        }
    }
}
