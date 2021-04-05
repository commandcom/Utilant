using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtilantInterviewTest.Models
{
    public record Photo
    (
        int AlbumId,
        int Id,
        string Title,
        string Url,
        string ThumbnailUrl
    );
}
