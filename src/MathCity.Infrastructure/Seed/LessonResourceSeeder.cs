using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Infrastructure.Persistence.Context;
using MathCity.Infrastructure.Seed.LessonResourceSeeders;

namespace MathCity.Infrastructure.Seed;

public class LessonResourceSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IFileStorageService _storage;

    private readonly AlgebraLessonResourceSeeder _algebraSeeder;
    private readonly CalculusLessonResourceSeeder _calculusSeeder;


    public LessonResourceSeeder(
        ApplicationDbContext context,
        IFileStorageService storage,
         AlgebraLessonResourceSeeder algebraSeeder,
        CalculusLessonResourceSeeder calculusSeeder)
    {
        _context = context;
        _storage = storage;
        _algebraSeeder = algebraSeeder;
        _calculusSeeder = calculusSeeder;
    }

    public async Task SeedAsync()
    {
        await _algebraSeeder.SeedAsync();
        await _calculusSeeder.SeedAsync();
    }
}