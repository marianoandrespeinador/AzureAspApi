using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureAspApi.Models
{
    public class ContactInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int AssociateId { get; set; }

        public virtual Associate Associate { get; set; }
    }
}