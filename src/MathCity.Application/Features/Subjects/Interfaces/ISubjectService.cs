using MathCity.Application.Features.Subjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathCity.Application.Common.Models;
using System.Threading.Tasks;

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

    Task<PagedResult<SubjectListResponse>> GetAllAsync(SubjectQuery query);
}