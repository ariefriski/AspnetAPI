using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public int roleId { get; set; }

        [ForeignKey("Employee")]
        
        public int employeeId { get; set; }
        [JsonIgnore]
        public virtual Role? role { get; set; }
        public virtual Employee? employee { get; set; }
    }
}
