using System.Net;
using System.Runtime.InteropServices;

namespace E_Com.Models.DTOs
{
    public class ResponseMassage  
    {
      public   HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public object Data { get; set; } = null;

       
    }
}
