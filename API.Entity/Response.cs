using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entity
{
    public record Response<T>
    {
        public int state { get; set; }
        public string exeption { get; set; }
        public T data { get; set; } 

        public static Response<T> Completed(T data)
        {
            var response = new Response<T>
            {
                state = 200,
                data = data,
                exeption = string.Empty
            };
            return response;
        }

        public static Response<T> error(string exeption)
        {
            var response = new Response<T>
            {
                state = 100,
                exeption = exeption
            };
            return response;
        }
    }
}
