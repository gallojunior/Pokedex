using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Classes
{
    public class Pokemon
    {
        // Atributos
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Especie { get; set; }
        public List<string> Tipo { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Imagem { get; set; }
        // Método Construtor
        public Pokemon()
        {
            Tipo = new List<string>();
        }
    }

}
