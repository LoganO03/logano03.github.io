using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Data;
using RazorPagesAnime.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazerPagesAnime.Pages_Animes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public IndexModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
        {
            _context = context;
        }

        public IList<Anime> Anime { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AnimeGenre { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> genreQuery = from m in _context.Anime
                                            orderby m.Genre
                                            select m.Genre;
            // </snippet_search_linqQuery>

            var animes = from m in _context.Anime
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                animes = animes.Where(s => s.Title.ToLower().Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AnimeGenre))
            {
                animes = animes.Where(x => x.Genre == AnimeGenre);
            }

            // <snippet_search_selectList>
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Anime = await animes.ToListAsync();
        }
    }
}
