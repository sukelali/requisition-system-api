using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RequisitionSystemApi.Data
{
    public class RequisitionItem
    {

        [JsonIgnore]
        public long Id { get; set; }

        [JsonIgnore]
        public long RequisitionId { get; set; }

        [Required]
        public string? OrderNumber { get; set; }

        [Required]
        public string? StyleNumber { get; set; }

        [Required]
        public string? ItemDescription { get; set; }


        [Required]
        public double Quantity {  get; set; }


        [JsonIgnore]
        [ForeignKey(nameof(RequisitionId))]
        public virtual Requisition? Requisition { get; set; }

    }
}
