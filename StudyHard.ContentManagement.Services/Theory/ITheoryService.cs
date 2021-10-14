using StudyHard.ContentManagement.Dto.Theory;
using System;
using System.Threading;
using System.Threading.Tasks;
using StudyHard.Common.Dto;
using StudyHard.Common.Dto.AzureBlob;
using StudyHard.Common.Dto.File;
using System.IO;

namespace StudyHard.ContentManagement.Services.Theory
{
    public interface ITheoryService
    {
        Task<PaginatedDto<TheoryDto>> GetPaginatedTheoriesByCategoryIdAsync(TheoryPaginationDto theoryPaginationDto, CancellationToken cancellationToken);
        Task<TheoryDto> GetTheoryByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken);
        Task UpdateTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken);
        Task DeleteTheoryAsync(TheoryDto theoryDto, CancellationToken cancellationToken);
        Task<Guid> AddBlobAsync(Stream stream, string name, string ext, CancellationToken cancellationToken);
        Task<BlobFileDto> GetBlobAsync(Guid fileId, CancellationToken cancellationToken);
        Task DeleteBlobAsync(FileDto file, CancellationToken cancellationToken);
    }
}
