using System.Data.Entity;

namespace AzureAspApi.DAL
{
    public class MyFirstDBInitializer : DropCreateDatabaseIfModelChanges<MyFirstDBContext>
    {
        protected override void Seed(MyFirstDBContext context)
        {
        }
    }
}