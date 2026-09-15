using Api.Models;

namespace Api.Data;

/// <summary>In-memory Site store, seeded with sample data.</summary>
public class SiteStore
{
    private readonly List<Site> _sites =
    [
        new() { Id = 1, Name = "Amsterdam" },
        new() { Id = 2, Name = "Malmo" },
        new() { Id = 3, Name = "Vilnius" },
    ];

    public IReadOnlyList<Site> GetAll() => _sites;

    public bool Exists(int id) => _sites.Any(s => s.Id == id);
}
