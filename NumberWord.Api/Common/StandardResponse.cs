using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberWord.Api.Common
{
    public class StandardResponse<T>
    {
        public List<string> Messages { get; set; } = new List<string>();

        public List<string> Errors { get; set; } = new List<string>();

        public List<string> Warnings { get; set; } = new List<string>();

        public T Data { get; set; }
        
    }
}
