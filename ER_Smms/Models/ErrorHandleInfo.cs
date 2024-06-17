using System.Text.Json;

namespace ER_Smms.Models
{
    public class ErrorHandleInfo
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
