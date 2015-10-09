using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MVC5.Models
{
    public class ClientModel
    {
        [Required]
        [MaxLength(64)]
        public string ClientId { get; set; }

        [Required]
        [MaxLength(128)]
        public string LoginUrl { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}