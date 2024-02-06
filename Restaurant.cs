using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS_LJ2_Projekt
{
    internal class Restaurant
    {
        private string name;
        private string adresse;
        private string speisekarte;
        private string stimmen;

        public Restaurant(string Name, string Adresse, string Speisekarte) 
        { 
            name = Name;
            adresse = Adresse;
            speisekarte = Speisekarte;
            stimmen = "0";
        }
    }
}
