using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AzureAspApi.DAL;
using AzureAspApi.Models;

namespace AzureAspApi.Controllers
{
    public class ContactInfoController : ApiController
    {
        private ContactModel CastContactInfo(ContactInfo contact)
            => new ContactModel
            {
                Id = contact.Id,
                Value = contact.Value
            };
        private ContactWithAssociateModel CastContactInfoWithAssociate(ContactInfo contact)
            => new ContactWithAssociateModel
            {
                Id = contact.Id,
                Value = contact.Value,
                AssociateName = $"{contact.Associate.FirstMidName} {contact.Associate.LastName}"
            };

        // GET api/values
        public IEnumerable<ContactWithAssociateModel> Get()
        {
            List<ContactWithAssociateModel> contactList;

            using (var context = new MyFirstDBContext())
            {
                contactList = context.Set<ContactInfo>()
                    .Include(ci => ci.Associate).ToList()
                    .ConvertAll(CastContactInfoWithAssociate);
            }

            return contactList;
        }

        // GET api/values/5
        public ContactModel Get(int id)
        {
            ContactModel contactToReturn;

            using (var context = new MyFirstDBContext())
            {
                var contact = context.Set<ContactInfo>().FirstOrDefault(c => c.Id == id);
                contactToReturn = CastContactInfo(contact);
            }

            return contactToReturn;
        }

        // POST api/values
        public void Post([FromBody]ContactInfo value)
        {
            using (var context = new MyFirstDBContext())
            {
                context.Set<ContactInfo>().Add(value);
                context.SaveChanges();
            }
        }

    }
}
