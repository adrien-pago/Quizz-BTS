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

        public override string ToString()
        {
            string chaine = Pseudo + "- Score: " + Score;
            return chaine;
        }

    }

    
}
