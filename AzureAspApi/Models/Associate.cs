using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureAspApi.Models
{
    public class Associate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}