using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz
{
    public class Joueur
    {
        public Joueur()
        {

        }

        public string Pseudo { get; set; }
        public int Score { get; set; }
        public string Password { get; set; } // Ajout du mot de passe

        public override string ToString()
        {
            string chaine = Pseudo + "- Score: " + Score;
            return chaine;
        }

    }

    
}
