using System;
using System.IO;

namespace StudyHard.Common.Dto.AzureBlob
{
    public class BlobFileDto
    {
        public Stream File { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}