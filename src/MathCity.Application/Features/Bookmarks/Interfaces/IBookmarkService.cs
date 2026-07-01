using MathCity.Application.Features.Bookmarks.DTOs;

namespace MathCity.Application.Features.Bookmarks.Interfaces;

public interface IBookmarkService
{
    Task<BookmarkResponse> CreateAsync(
        Guid userId,
        CreateBookmarkRequest request);

    Task<IReadOnlyList<BookmarkListResponse>> GetByUserAsync(
        Guid userId);

    Task DeleteAsync(
        Guid userId,
        Guid bookmarkId);
}