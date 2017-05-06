using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Security.Entities
{
    public class Functionality
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual ICollection<ProfileFunctionality> ProfileFunctionalities { get; set; }
    }
}
