using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Pokedex.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Pokedex.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Pokemon> Pokemons { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string Tipo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Pokemons")))
            {
                PopularLista();
            }
            var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(HttpContext.Session.GetString("Pokemons"));
            var tipos = pokemons.SelectMany(p => p.Tipo).Distinct().ToList();
            tipos.Sort();
            ViewData["Tipos"] = tipos;
            if (string.IsNullOrEmpty(Tipo))
            {
                Pokemons = pokemons;
            }
            else
            {
                Pokemons = pokemons.Where(p => p.Tipo.Contains(Tipo)).ToList();
            }
        }

        public void PopularLista()
        {
            using (StreamReader r = new StreamReader(@"Dados\dados.json"))
            {
                string json = r.ReadToEnd();
                HttpContext.Session.SetString("Pokemons", json);
            }
        }

    }
}
