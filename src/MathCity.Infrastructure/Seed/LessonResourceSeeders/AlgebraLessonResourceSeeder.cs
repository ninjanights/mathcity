using MathCity.Application.Features.Storage.Interfaces;
using MathCity.Domain.Entities;
using MathCity.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MathCity.Domain.Enums;
namespace MathCity.Infrastructure.Seed.LessonResourceSeeders;

public class AlgebraLessonResourceSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IFileStorageService _storage;

    public AlgebraLessonResourceSeeder(
        ApplicationDbContext context,
        IFileStorageService storage)
    {
        _context = context;
        _storage = storage;
    }

    public async Task SeedAsync()
    {
        var folderPath = Path.Combine(
    AppContext.BaseDirectory,
    "Seed",
    "LessonResourceSeeders",
    "Algebra"
);
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Missing folder: {folderPath}");
            return;
        }
        var txtFiles = Directory.GetFiles(folderPath, "*.txt");
        Console.WriteLine($"Found {txtFiles.Length} Algebra files");
        // 1. Find related Lesson
        // 2. Upload TXT using _storage
        // 3. Create LessonResource entity
        // 4. Save to database
        foreach (var file in txtFiles)
        {
            var slug = Path.GetFileNameWithoutExtension(file);

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(x => x.Slug == slug);

            if (lesson == null)
            {
                Console.WriteLine($"Lesson not found: {slug}");
                continue;
            }
            var exists = await _context.LessonResources
       .AnyAsync(x => x.LessonId == lesson.Id && x.FileName == $"{slug}.txt");

            if (exists)
            {
                Console.WriteLine($"Resource already exists: {slug}");
                continue;
            }

            var fileBytes = await File.ReadAllBytesAsync(file);

            using var stream = new MemoryStream(fileBytes);

            var uploadResult = await _storage.UploadDocumentAsync(
    lesson.Slug,
    ResourceType.Text,
    stream,
    
    "text/plain",
    CancellationToken.None
); 
            var nextDisplayOrder = await _context.LessonResources
    .Where(x => x.LessonId == lesson.Id)
    .Select(x => (int?)x.DisplayOrder)
    .MaxAsync() ?? 0;
            
            var resource = new LessonResource
{
    LessonId = lesson.Id,
    Title = $"{lesson.Title} Notes",
    FileName = uploadResult.FileName,
    FileUrl = uploadResult.PublicUrl,
    FileSize = uploadResult.Size,
    ContentType = uploadResult.ContentType,
    Type = ResourceType.Text,
    DisplayOrder = 1
};

            _context.LessonResources.Add(resource);

            Console.WriteLine($"Seeded resource: {slug}");
        }


        await _context.SaveChangesAsync();
    }
}