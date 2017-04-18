namespace SignalR_MapUsers.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SignalR_MapUsersModel : DbContext
    {
        public SignalR_MapUsersModel()
            : base("name=SignalR_MapUsersModel")
        {
        }

        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Connections)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_UserName);
        }
    }
}
