using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz
{
    public class Question
    {
        public Question()
        {

        }
        public string Categories { set; get; }
        public string NomQuestion { set; get; }
        public string ReponseA { set; get; }
        public string ReponseB { set; get; }
        public string ReponseC { set; get; }
        public int BonneReponse { set; get; }
    }
}
