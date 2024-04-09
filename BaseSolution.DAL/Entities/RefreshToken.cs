using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed {  get; set; }
        public bool IsRevoked {  get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }
    }
}
