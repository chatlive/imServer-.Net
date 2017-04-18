namespace ChatDB.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    using System.Data.Entity.ModelConfiguration;
    using IM;

    public partial class ModelAC : DbContext
    {
        public ModelAC()
           : base("name=ChatDBModel")
        {
            // New code:
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        #region ApiBase_

        //public DbSet<BaseFunction> BaseFunction { get; set; }
        //public DbSet<BaseRole> BaseRole { get; set; }
        //public DbSet<BaseUser> BaseUser { get; set; }
        //public DbSet<BaseUserDetail> BaseUserDetail { get; set; }
        //public DbSet<BaseApp> BaseApp { get; set; }
        //public DbSet<BaseApiRecord> BaseApiRecord { get; set; }

        #endregion

        #region IM_

        public DbSet<IM_User> IM_User { get; set; }
        public DbSet<IM_Group> IM_Group { get; set; }
        public DbSet<Im_UserGroup> Im_UserGroup { get; set; }

        public DbSet<IM_Chatter> IM_Chatter { get; set; }
        public DbSet<IM_ChatterActor> IM_ChatterActor { get; set; }
        public DbSet<IM_MsgSingle> IM_MsgSingle { get; set; }
        public DbSet<IM_MsgGroup> IM_MsgGroup { get; set; }
        public DbSet<IM_MsgGroup_ReadState> IM_MsgGroup_ReadState { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new BaseFunctionMap());
            //modelBuilder.Configurations.Add(new BaseRoleMap());
            //modelBuilder.Configurations.Add(new BaseUserMap());
            //modelBuilder.Configurations.Add(new BaseUserDetailMap());
            //modelBuilder.Configurations.Add(new BaseAppMap());
            //modelBuilder.Configurations.Add(new BaseLogMap());
            //modelBuilder.Configurations.Add(new BaseApiRecordMap());

            /**************************************************************************************************************/

            modelBuilder.Configurations.Add(new IM_ChatterMap());
            modelBuilder.Configurations.Add(new IM_ChatterActorMap());
            modelBuilder.Configurations.Add(new IM_MsgSingleMap());
            modelBuilder.Configurations.Add(new IM_MsgGroupMap());
            modelBuilder.Configurations.Add(new IM_MsgGroup_ReadStateMap());
            modelBuilder.Configurations.Add(new IM_GroupMap());
            modelBuilder.Configurations.Add(new IM_UserMap());
            modelBuilder.Configurations.Add(new Im_UserGroupMap());

            base.OnModelCreating(modelBuilder);
        }




    }
}
