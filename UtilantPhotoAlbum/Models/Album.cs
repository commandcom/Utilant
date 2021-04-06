using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtilantInterviewTest.Models
{
    public record Album
    (
        int Id,
        int UserId,
        string Title
    )
    {
        public User User { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
