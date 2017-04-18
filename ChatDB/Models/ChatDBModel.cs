//namespace ChatDB.Models
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class ChatDBModel : DbContext
//    {
//        public ChatDBModel()
//            : base("name=ChatDBModel")
//        {
//        }

//        public virtual DbSet<IM_Chatter> IM_Chatter { get; set; }
//        public virtual DbSet<IM_ChatterActor> IM_ChatterActor { get; set; }
//        public virtual DbSet<IM_MsgGroup> IM_MsgGroup { get; set; }
//        public virtual DbSet<IM_MsgGroup_ReadState> IM_MsgGroup_ReadState { get; set; }
//        public virtual DbSet<IM_MsgSingle> IM_MsgSingle { get; set; }
//        public virtual DbSet<ImGroup> ImGroups { get; set; }
//        public virtual DbSet<ImUser> ImUsers { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<IM_Chatter>()
//                .HasMany(e => e.IM_ChatterActor)
//                .WithRequired(e => e.IM_Chatter)
//                .HasForeignKey(e => e.ChatterId)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<IM_MsgGroup>()
//                .HasMany(e => e.IM_MsgGroup_ReadState)
//                .WithRequired(e => e.IM_MsgGroup)
//                .HasForeignKey(e => e.IM_MsgGroup_Id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImGroup>()
//                .HasMany(e => e.IM_Chatter)
//                .WithOptional(e => e.ImGroup)
//                .HasForeignKey(e => e.Group_GroupId);

//            modelBuilder.Entity<ImGroup>()
//                .HasMany(e => e.IM_MsgGroup)
//                .WithRequired(e => e.ImGroup)
//                .HasForeignKey(e => e.To_GroupId)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImGroup>()
//                .HasMany(e => e.ImUsers)
//                .WithMany(e => e.ImGroups)
//                .Map(m => m.ToTable("ImUserGroup").MapLeftKey("IM_Group_Id").MapRightKey("IM_User_Id"));

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_Chatter)
//                .WithOptional(e => e.ImUser)
//                .HasForeignKey(e => e.Single_A_UserId);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_Chatter1)
//                .WithOptional(e => e.ImUser1)
//                .HasForeignKey(e => e.Single_B_UserId);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_ChatterActor)
//                .WithRequired(e => e.ImUser)
//                .HasForeignKey(e => e.UserId)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_MsgGroup)
//                .WithRequired(e => e.ImUser)
//                .HasForeignKey(e => e.From_UserId)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_MsgGroup_ReadState)
//                .WithRequired(e => e.ImUser)
//                .HasForeignKey(e => e.User_id)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_MsgSingle)
//                .WithRequired(e => e.ImUser)
//                .HasForeignKey(e => e.From_UserId)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ImUser>()
//                .HasMany(e => e.IM_MsgSingle1)
//                .WithRequired(e => e.ImUser1)
//                .HasForeignKey(e => e.To_UserId)
//                .WillCascadeOnDelete(false);
//        }
//    }
//}
