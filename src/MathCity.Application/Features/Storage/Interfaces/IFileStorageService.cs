using MathCity.Domain.Enums;
using MathCity.Application.Features.Storage.DTOs;

namespace MathCity.Application.Features.Storage.Interfaces;

public interface IFileStorageService
{
    Task<FileUploadResponse> UploadDocumentAsync(
     string lessonSlug,
     ResourceType resourceType,
     Stream stream,
     string contentType,
     CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        string lessonSlug,
        string fileName,
        CancellationToken cancellationToken = default);


    Task DeleteAsync(
        string filePath,
        CancellationToken cancellationToken = default);
}