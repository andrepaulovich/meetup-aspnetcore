using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Security.Entities
{
    public class Token
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
