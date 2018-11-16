using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAspApi.Models
{
    public class ContactWithAssociateModel : ContactModel
    {
        public string AssociateName { get; set; }
    }
}