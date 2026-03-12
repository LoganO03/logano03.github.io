using System.ComponentModel.DataAnnotations;

namespace RazorPagesAnime.Models;

public class Anime
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public int? Seasons { get; set; }
    public int? Rating { get; set; }
}