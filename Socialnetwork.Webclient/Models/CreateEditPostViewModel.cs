using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Models
{
    public class CreateEditPostViewModel
    {
        public string PostContent { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
