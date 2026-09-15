using Api.Models;

namespace Api.Data;

/// <summary>In-memory Role store, seeded with sample data.</summary>
public class RoleStore
{
    private readonly List<Role> _roles =
    [
        new() { Id = 1, Name = "Warehouse Associate" },
        new() { Id = 2, Name = "Forklift Operator" },
        new() { Id = 3, Name = "Site Manager" },
    ];

    public IReadOnlyList<Role> GetAll() => _roles;

    public bool Exists(int id) => _roles.Any(r => r.Id == id);
}
