using OwnSignDemo.Data;
using OwnSignDemo.Interfaces;
using OwnSignDemo.Models;

namespace OwnSignDemo.Services
{
    public class UserRepository : RepositoryBase<int, User>, IRepository<int, User>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public override void Update(User entity)
        {
            base.Update(entity);
        }
    }
}
