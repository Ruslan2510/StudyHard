using System;

namespace StudyHard.Dto.Auth
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}