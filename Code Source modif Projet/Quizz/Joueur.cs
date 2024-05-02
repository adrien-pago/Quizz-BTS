using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public int Categorie { get; set; } // Ajout de la catégorie pour le scoore
        public TimeSpan Time { get; set; } // Modifier le type de la propriété Time en TimeSpan
        
        // Méthode pour afficher le joueur sous forme de chaîne de caractères
        public override string ToString()
        {
            string chaine = Pseudo + "- Score: " + Score + "-Time:" + Time;
            return chaine;
        }

    }

    
}
