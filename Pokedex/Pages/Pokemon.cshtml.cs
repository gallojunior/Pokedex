using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokedex.Classes;

namespace Pokedex.Pages
{
    public class PokemonModel : PageModel
    {
        public Pokemon Pokemon { get; set; }
        public Pokemon Anterior { get; set; }
        public Pokemon Proximo { get; set; }

        public void OnGet(int id)
        {
            var Pokemons = new List<Pokemon>();
            Pokemons = JsonSerializer.Deserialize<List<Pokemon>>(HttpContext.Session.GetString("Pokemons"));
            Pokemon = Pokemons.Where(p => p.Numero == id).SingleOrDefault();
            Anterior = Pokemon == Pokemons.First() ? null : Pokemons[Pokemons.IndexOf(Pokemon) - 1];
            Proximo = Pokemon == Pokemons.Last() ? null : Pokemons[Pokemons.IndexOf(Pokemon) + 1];
        }
    }                    
}
                    
