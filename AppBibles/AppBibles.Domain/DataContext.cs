namespace AppBibles.Domain
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<AppBibles.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<AppBibles.Domain.UserType> UserTypes { get; set; }
    }
}
