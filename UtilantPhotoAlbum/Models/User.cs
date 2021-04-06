using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilantInterviewTest.Models;
using X.PagedList;

namespace UtilantInterviewTest.Models
{
    public record User
    (
        int Id,
        string Name,
        string UserName,
        string Email,
        Address Address,
        string Phone,
        string Website,
        Company Company
    )
    {
        public List<Post> Posts { get; set; }
    }
}
