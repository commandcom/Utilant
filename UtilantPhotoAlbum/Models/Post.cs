using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtilantInterviewTest.Models
{
    public record Post
    (
        int UserId,
        int Id,
        string Title,
        string Body
    );
}
