using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RequisitionSystemApi.Data
{
    public class Requisition
    {

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public string? Buyer { get; set; }

        [Required]
        public string? Number { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        public ICollection<RequisitionItem> RequisitionItems { get; set; } = new List<RequisitionItem>();


    }

}
