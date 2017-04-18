using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatDB.Entity.IM
{
    /********************************术业有专攻 闻道有先后********************************/
    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_UserMap : EntityTypeConfiguration<IM_User>
    {
        public IM_UserMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.UserId).IsRequired().HasMaxLength(200).IsUnicode();
            Property(e => e.Name).IsRequired().HasMaxLength(200).IsUnicode();
            Property(e => e.PortraitUri).IsRequired().HasMaxLength(500).IsUnicode()
                .HasColumnAnnotation("MS_Description", "头像");

            #region 会话关系

            HasMany(e => e.Single_A_IM_Chatter)
                .WithOptional(e => e.Single_A_IM_User)
                .HasForeignKey(e => e.Single_A_UserId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Single_B_IM_Chatter)
                .WithOptional(e => e.Single_B_IM_User)
                .HasForeignKey(e => e.Single_B_UserId)
                .WillCascadeOnDelete(false);

            #endregion

            HasMany(e => e.IM_ChatterActor)
            .WithRequired(e => e.IM_User)
            .HasForeignKey(e => e.UserId)
            .WillCascadeOnDelete(false);

            HasMany(e => e.From_IM_MsgGroup)
            .WithRequired(e => e.From_IM_User)
            .HasForeignKey(e => e.From_UserId)
            .WillCascadeOnDelete(false);

            HasMany(e => e.IM_MsgGroup_ReadState)
            .WithRequired(e => e.IM_User)
            .HasForeignKey(e => e.User_id)
            .WillCascadeOnDelete(false);

            HasMany(e => e.Im_UserGroups)
                .WithRequired(e => e.IM_User)
                .HasForeignKey(e => e.IM_User_Id);

            #region 单聊关系

            HasMany(e => e.From_IM_MsgSingle)
            .WithRequired(e => e.From_IM_User)
            .HasForeignKey(e => e.From_UserId)
            .WillCascadeOnDelete(false);

            HasMany(e => e.To_IM_MsgSingle)
            .WithRequired(e => e.To_IM_User)
            .HasForeignKey(e => e.To_UserId)
            .WillCascadeOnDelete(false);

            #endregion

            ToTable("ImUser");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_GroupMap : EntityTypeConfiguration<IM_Group>
    {
        public IM_GroupMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.GroupId).IsRequired().HasMaxLength(200).IsUnicode();
            Property(e => e.GroupName).IsRequired().HasMaxLength(200).IsUnicode();

            HasMany(e => e.IM_Chatter)
            .WithOptional(e => e.Group_IM_Group)
            .HasForeignKey(e => e.Group_GroupId)
            .WillCascadeOnDelete(false);

            HasMany(e => e.To_IM_MsgGroup)
            .WithRequired(e => e.To_IM_Group)
            .HasForeignKey(e => e.To_GroupId)
            .WillCascadeOnDelete(false);
                        
            HasMany(e => e.Im_UserGroups)
                .WithRequired(e => e.IM_Group)
                .HasForeignKey(e => e.IM_Group_Id);

            //HasMany(e => e.IM_Users)
            //.WithMany(e => e.IM_Groups)
            //.Map(m => m.ToTable("ImUserGroup").MapLeftKey("IM_Group_Id").MapRightKey("IM_User_Id"));

            ToTable("ImGroup");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class Im_UserGroupMap : EntityTypeConfiguration<Im_UserGroup>
    {
        public Im_UserGroupMap()
        {
            HasKey(e => new { e.IM_Group_Id, e.IM_User_Id });

            Property(e => e.GroupPosition).IsRequired();

            ToTable("Im_UserGroup");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_ChatterMap : EntityTypeConfiguration<IM_Chatter>
    {
        public IM_ChatterMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.ChatType).IsRequired();

            HasMany(e => e.IM_ChatterActors)
                .WithRequired(e => e.IM_Chatter)
                .HasForeignKey(e => e.ChatterId)
                .WillCascadeOnDelete(false);

            ToTable("IM_Chatter");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_ChatterActorMap : EntityTypeConfiguration<IM_ChatterActor>
    {
        public IM_ChatterActorMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.UserId).IsRequired();
            Property(e => e.Last_MsgId).IsRequired();
            Property(e => e.UnreadMsgCount).IsRequired();
            Property(e => e.ChatterTime).IsRequired();
            Property(e => e.IsCleared).IsRequired();

            ToTable("IM_ChatterActor");
        }
    }

    /**************************************************************************************************************/

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgSingleMap : EntityTypeConfiguration<IM_MsgSingle>
    {
        public IM_MsgSingleMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.MsgClientId).IsRequired().HasMaxLength(200).IsUnicode();
            Property(e => e.From_UserId).IsRequired();
            Property(e => e.To_UserId).IsRequired();
            Property(e => e.SortId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.MsgTime).IsRequired();
            Property(e => e.IsRead).IsRequired();
            Property(e => e.MsgType).IsRequired();
            Property(e => e.MsgBody).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgSingle");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgGroupMap : EntityTypeConfiguration<IM_MsgGroup>
    {
        public IM_MsgGroupMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.MsgClientId).IsRequired().HasMaxLength(200).IsUnicode();
            Property(e => e.From_UserId).IsRequired();
            Property(e => e.To_GroupId).IsRequired();
            Property(e => e.SortId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.MsgTime).IsRequired();
            Property(e => e.IsFullRead).IsRequired();
            Property(e => e.MsgType).IsRequired();
            Property(e => e.MsgBody).IsRequired().HasMaxLength(1000).IsUnicode();

            HasMany(e => e.IM_MsgGroup_ReadStates)
            .WithRequired(e => e.IM_MsgGroup)
            .HasForeignKey(e => e.IM_MsgGroup_Id)
            .WillCascadeOnDelete(false);

            ToTable("IM_MsgGroup");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgGroup_ReadStateMap : EntityTypeConfiguration<IM_MsgGroup_ReadState>
    {
        public IM_MsgGroup_ReadStateMap()
        {
            HasKey(e => new { e.Id });

            Property(e => e.IsRead).IsRequired();

            ToTable("IM_MsgGroup_ReadState");
        }
    }

    /**************************************************************************************************************/

    #region 消息扩展

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgTextMap : EntityTypeConfiguration<IM_MsgText>
    {
        public IM_MsgTextMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgText");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgExpressionMap : EntityTypeConfiguration<IM_MsgExpression>
    {
        public IM_MsgExpressionMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgExpression");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgImgMap : EntityTypeConfiguration<IM_MsgImg>
    {
        public IM_MsgImgMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgImg");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgFileMap : EntityTypeConfiguration<IM_MsgFile>
    {
        public IM_MsgFileMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgFile");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgVoiceMap : EntityTypeConfiguration<IM_MsgVoice>
    {
        public IM_MsgVoiceMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgVoice");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgVideoMap : EntityTypeConfiguration<IM_MsgVideo>
    {
        public IM_MsgVideoMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgVideo");
        }
    }

    /// <summary>
    /// 映射信息（Fluent API 配置）
    /// </summary>
    public class IM_MsgLBSMap : EntityTypeConfiguration<IM_MsgLBS>
    {
        public IM_MsgLBSMap()
        {
            HasKey(e => new { e.Msg_Id });

            Property(e => e.MsgContent).IsRequired().HasMaxLength(1000).IsUnicode();

            ToTable("IM_MsgLBS");
        }
    }

    #endregion
}
