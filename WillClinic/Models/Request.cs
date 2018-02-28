using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class Request
    {
        public int Id { get; set; }

        public string VeteranApplicationUserId{ get; set; }

        public Request()
        {
            // when a request is made, check to make sure the veteran has coordinates. If not, this is a good time to populate them.
        }
    }
}
