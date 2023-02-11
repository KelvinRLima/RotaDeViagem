using System;

namespace RotaViagem.Domain.Models
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public bool IsException { get; set; }

        public Result()
        {
            this.Status = true;
            this.Message = String.Empty;
        }
    }
}
