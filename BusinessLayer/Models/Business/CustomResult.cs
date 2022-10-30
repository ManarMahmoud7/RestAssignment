using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models.Business
{
    public class CustomResult<T> where T : class
    {
        public Boolean IsSuccessfull { get; set; }

        public T  Data { get; set; }

        public List<string> ValidationErrors { get; set; }
    }
}
