using App13_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App13_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }
        public static short RodadaAtual { get; set; }
        public static string[][] Palavras =
        {
            //FACIL - Pontuação 1
            new string[]{"Olho","Língua","Chinelo","Milho","Penalti","Bola"},
            
            //MEDIO - Pontuação 3
            new string[]{"Carteiro","Amarelo","Gato","Limão"},

            //DIFICLIL - Pontuação 5
            new string[]{"Lanterna","Porão","Batman vs Superman","Marionete","Notebook"},
        };
    }
}
