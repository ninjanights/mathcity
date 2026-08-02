using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Infrastructure.Persistence.Context;

namespace MathCity.Infrastructure.Seed.LessonResourceSeeders;

public class CalculusLessonResourceSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IFileStorageService _storage;

    public CalculusLessonResourceSeeder(
        ApplicationDbContext context,
        IFileStorageService storage)
    {
        _context = context;
        _storage = storage;
    }

    public async Task SeedAsync()
    {
        var folderPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Seed",
            "LessonResourceSeeders",
            "Calculus"
        );

        if (!Directory.Exists(folderPath))
        {
            return;
        }

        var txtFiles = Directory.GetFiles(folderPath, "*.txt");

        foreach (var file in txtFiles)
        {
            var slug = Path.GetFileNameWithoutExtension(file);

            Console.WriteLine($"Seeding Calculus resource: {slug}");

            // same logic as Algebra:
            // find lesson
            // upload txt
            // create LessonResource
        }

        await _context.SaveChangesAsync();
    }
}