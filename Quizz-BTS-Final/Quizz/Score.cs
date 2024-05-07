using System;
using Quizz;

namespace Quizz
{
    public class Score
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
        public int Categorie { get; set; }
    }
}