using MathCity.Domain.Enums;
using MathCity.Application.Features.Storage.DTOs;


namespace MathCity.Application.Features.Storage.Interfaces;
public interface IFileStorageService
{
    Task<FileUploadResponse> UploadDocumentAsync(
        Guid lessonId,
        string resourceTitle,
        ResourceType resourceType,
        Stream stream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken = default);
    Task DeleteAsync(string filePath, CancellationToken cancellationToken = default);
}