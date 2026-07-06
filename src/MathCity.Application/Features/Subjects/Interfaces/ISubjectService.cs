using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathCity.Application.Features.Subjects.DTOs;

namespace MathCity.Application.Features.Subjects.Interfaces;

public interface ISubjectService
{
    Task<SubjectResponse> CreateAsync(CreateSubjectRequest request);

    Task<SubjectResponse> UpdateAsync(
        Guid id,
        UpdateSubjectRequest request);

    Task DeleteAsync(Guid id);

    Task MoveAsync(
      Guid id,
      MoveSubjectRequest request);

    Task<SubjectResponse> GetByIdAsync(Guid id);

    Task<IReadOnlyList<SubjectListResponse>> GetAllAsync(
    string? search = null);
}