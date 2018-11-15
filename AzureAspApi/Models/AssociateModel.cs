using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAspApi.Models
{
    public class AssociateModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public ContactModel DefaultContactInfo { get; set; }
    }
}