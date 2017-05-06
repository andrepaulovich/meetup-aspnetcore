using System;
using System.Collections.Generic;

namespace Meetup.Security.Shared.Dtos
{
    public class TokenDto
    {
        public long Id { get; set; }

        public Guid JwtId { get; set; }

        public long UserId { get; set; }

        public DateTime GeneratedDate { get; set; }

        public DateTime ValidTo { get; set; }

        public bool BlackList { get; set; }

        public bool IsRefresh { get; set; }
    }
}
