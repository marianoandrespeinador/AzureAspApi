using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AzureAspApi.DAL;
using AzureAspApi.Models;

namespace AzureAspApi.Controllers
{
    public class AssociateController : ApiController
    {
        private AssociateModel CastAssociate(Associate associate)
        => new AssociateModel
            {
                Id = associate.Id,
                FirstMidName = associate.FirstMidName,
                LastName = associate.LastName,
                DefaultContactInfo = new ContactModel { Id = associate.ContactInfos.FirstOrDefault().Id, Value = associate.ContactInfos.FirstOrDefault().Value}
            };

        // GET api/values
        public IEnumerable<AssociateModel> Get()
        {
            List<AssociateModel> associateList;

            using (var context = new MyFirstDBContext())
            {
                associateList = context.Set<Associate>().ToList()
                    .ConvertAll(CastAssociate);
            }

            return associateList;
        }

        // GET api/values/5
        public AssociateModel Get(int id)
        {
            AssociateModel associateToReturn;

            using (var context = new MyFirstDBContext())
            {
                var associate = context.Set<Associate>().FirstOrDefault(a => a.Id == id);
                associateToReturn = CastAssociate(associate);
            }

            return associateToReturn;
        }

        // POST api/values
        public void Post([FromBody]Associate value)
        {
            using (var context = new MyFirstDBContext())
            {
                context.Set<Associate>().Add(value);
                context.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (var context = new MyFirstDBContext())
            {
                var associate = context.Set<Associate>().FirstOrDefault(a => a.Id == id);
                context.Set<Associate>().Remove(associate);
            }
        }
    }
}
