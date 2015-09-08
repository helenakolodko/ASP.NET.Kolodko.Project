using System.Data.Entity;

namespace ORM
{
    public class Initialization : DropCreateDatabaseIfModelChanges<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
            base.Seed(context);

            // add entities
            
            context.SaveChanges();
        }
    }
}
