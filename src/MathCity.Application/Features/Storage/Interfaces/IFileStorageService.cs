namespace MathCity.Application.Features.Storage.Interfaces;

using MathCity.Application.Features.Storage.DTOs;

public interface IFileStorageService
{

    Task<FileUploadResponse> UploadAsync(
    Stream stream,
    string fileName,
    string contentType,
    string folder,
    bool generateUniqueName = true,
    CancellationToken cancellationToken = default);

    Task<string> UploadLessonThumbnailAsync(
     Guid lessonId,
     Stream stream,
     string fileName,
     string contentType,
     CancellationToken cancellationToken = default);

    Task DeleteAsync(string filePath, CancellationToken cancellationToken = default);
}