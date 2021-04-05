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
        public List<Photo> Photos{ get; set; }
    }
}
