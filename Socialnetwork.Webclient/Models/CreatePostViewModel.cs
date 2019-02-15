using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class CreatePostViewModel
    {
        public string PostContent { get; set; }
        List<IFormFile> Images { get; set; }
    }
}
