using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDB.Entity.IM
{
    /// <summary>
    /// IM用户（关联第三方）
    /// </summary>
    public class IM_User : BaseModel
    {
        public IM_User()
            : base()
        {
            //IM_Groups = new HashSet<IM_Group>();
            Single_A_IM_Chatter = new HashSet<IM_Chatter>();
            Single_B_IM_Chatter = new HashSet<IM_Chatter>();
            IM_ChatterActor = new HashSet<IM_ChatterActor>();
            From_IM_MsgGroup = new HashSet<IM_MsgGroup>();
            IM_MsgGroup_ReadState = new HashSet<IM_MsgGroup_ReadState>();
            From_IM_MsgSingle = new HashSet<IM_MsgSingle>();
            To_IM_MsgSingle = new HashSet<IM_MsgSingle>();
            Im_UserGroups = new HashSet<Im_UserGroup>();
        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }

        /// <summary>
        /// 用户 Id，最大长度 XX 字节.是用户在 App 中的唯一标识码，必须保证在同一个 App 内不重复，重复的用户 Id 将被当作是同一用户。（必传）
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户名称，最大长度 XXX 字节.用来在 Push 推送时显示用户的名称.用户名称，最大长度 XXX 字节.用来在 Push 推送时显示用户的名称。（必传）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户头像 URI，最大长度 XXXX 字节.用来在 Push 推送时显示用户的头像。（必传）
        /// </summary>
        public string PortraitUri { get; set; }


        //public virtual ICollection<IM_Group> IM_Groups { get; set; }
        public virtual ICollection<IM_Chatter> Single_A_IM_Chatter { get; set; }
        public virtual ICollection<IM_Chatter> Single_B_IM_Chatter { get; set; }
        public virtual ICollection<IM_ChatterActor> IM_ChatterActor { get; set; }
        public virtual ICollection<IM_MsgGroup> From_IM_MsgGroup { get; set; }
        public virtual ICollection<IM_MsgGroup_ReadState> IM_MsgGroup_ReadState { get; set; }
        public virtual ICollection<IM_MsgSingle> From_IM_MsgSingle { get; set; }
        public virtual ICollection<IM_MsgSingle> To_IM_MsgSingle { get; set; }
        public virtual ICollection<Im_UserGroup> Im_UserGroups { get; set; }

    }

    /// <summary>
    /// IM群组（关联第三方）
    /// </summary>
    public class IM_Group : BaseModel
    {
        public IM_Group()
            : base()
        {
            //IM_Users = new HashSet<IM_User>();
            IM_Chatter = new HashSet<IM_Chatter>();
            To_IM_MsgGroup = new HashSet<IM_MsgGroup>();
            Im_UserGroups = new HashSet<Im_UserGroup>();
        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// 创建群组 Id。（必传）
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 群组 Id 对应的名称。（必传）
        /// </summary>
        public string GroupName { get; set; }

        //public virtual ICollection<IM_User> IM_Users { get; set; }
        public virtual ICollection<IM_Chatter> IM_Chatter { get; set; }
        public virtual ICollection<IM_MsgGroup> To_IM_MsgGroup { get; set; }
        public virtual ICollection<Im_UserGroup> Im_UserGroups { get; set; }
    }


    /// <summary>
    /// IM用户群组关系（关联第三方）
    /// </summary>
    public class Im_UserGroup : BaseModel
    {
        public Im_UserGroup()
            : base()
        {
        }

        /// <summary>
        /// 群组编号
        /// </summary>
                     
        public Guid IM_Group_Id { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid IM_User_Id { get; set; }

        /// <summary>
        /// 群组-职位
        /// </summary>
        public IM_GroupPosition GroupPosition { get; set; }
        
        public virtual IM_Group IM_Group { get; set; }
        
        public virtual IM_User IM_User { get; set; }
    }

    /// <summary>
    /// IM群组-职位-类型
    /// </summary>
    public enum IM_GroupPosition
    {
        /// <summary>
        /// 群主
        /// </summary>
        Founder = 1,
        /// <summary>
        /// 管理员
        /// </summary>
        Manager = 2,
        /// <summary>
        /// 组员
        /// </summary>
        Memeber = 3,
    }

    /// <summary>
    /// IM会话
    /// </summary>
    public class IM_Chatter : BaseModel
    {
        public IM_Chatter()
            : base()
        {
            IM_ChatterActors = new HashSet<IM.IM_ChatterActor>();
        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// 会话类型
        /// </summary>
        public IM_ChatType ChatType { get; set; }

        /// <summary>
        /// (单聊会话)会话者编号-A
        /// </summary>
        public Guid? Single_A_UserId { get; set; }
        /// <summary>
        /// (单聊会话)会话者编号-B
        /// </summary>
        public Guid? Single_B_UserId { get; set; }
        /// <summary>
        /// （群聊会话）群组编号
        /// </summary>
        public Guid? Group_GroupId { get; set; }

        /// <summary>
        /// IM会话-参与者集合
        /// </summary>
        public virtual ICollection<IM.IM_ChatterActor> IM_ChatterActors { get; set; }
        /// <summary>
        /// 会话者A
        /// </summary>
        public virtual IM.IM_User Single_A_IM_User { get; set; }
        /// <summary>
        /// 会话者B
        /// </summary>
        public virtual IM.IM_User Single_B_IM_User { get; set; }
        /// <summary>
        /// 会话者-群组
        /// </summary>
        public virtual IM.IM_Group Group_IM_Group { get; set; }

    }

    /// <summary>
    /// IM会话-参与者
    /// </summary>
    public class IM_ChatterActor : BaseModel
    {
        public IM_ChatterActor()
            : base()
        {
        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// 会话编号
        /// </summary>
        public Guid ChatterId { get; set; }
        /// <summary>
        /// 用户编号（参与者）
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 最新-消息编号
        /// </summary>
        public Guid Last_MsgId { get; set; }
        /// <summary>
        /// 未读消息-数量（接收者）
        /// </summary>
        public int UnreadMsgCount { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ChatterTime { get; set; }
        /// <summary>
        /// 是否清除的会话（用户清除的会话）
        /// 有新消息时会话状态需要恢复
        /// </summary>
        public bool IsCleared { get; set; }

        /// <summary>
        /// (参与者所属)IM会话
        /// </summary>
        public virtual IM.IM_Chatter IM_Chatter { get; set; }

        /// <summary>
        /// 参与者
        /// </summary>
        public virtual IM.IM_User IM_User { get; set; }
    }

    /// <summary>
    /// IM会话-类型
    /// </summary>
    public enum IM_ChatType
    {
        /// <summary>
        /// 单聊
        /// </summary>
        Single = 1,
        /// <summary>
        /// 群聊
        /// </summary>
        Group = 2,
    }

    /**************************************************************************************************************/

    /// <summary>
    /// IM消息-单聊
    /// </summary>
    public class IM_MsgSingle : BaseModel
    {
        public IM_MsgSingle()
            : base()
        {

        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// 消息-客户端编号
        /// </summary>
        public string MsgClientId { get; set; }
        /// <summary>
        /// 发送者（用户编号）
        /// </summary>
        public Guid From_UserId { get; set; }
        /// <summary>
        /// 接收者（用户编号）
        /// </summary>
        public Guid To_UserId { get; set; }

        /// <summary>
        /// 排序自增字段
        /// </summary>
        public long SortId { get; set; }
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTime { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public IM_MsgType MsgType { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgBody { get; set; }


        /// <summary>
        /// 发送者
        /// </summary>
        public virtual IM.IM_User From_IM_User { get; set; }
        /// <summary>
        /// 接收者
        /// </summary>
        public virtual IM.IM_User To_IM_User { get; set; }
    }

    /// <summary>
    /// IM消息-群组
    /// </summary>
    public class IM_MsgGroup : BaseModel
    {
        public IM_MsgGroup()
            : base()
        {
            IM_MsgGroup_ReadStates = new HashSet<IM.IM_MsgGroup_ReadState>();
        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// 消息-客户端编号
        /// </summary>
        public string MsgClientId { get; set; }
        /// <summary>
        /// 发送者（用户编号）
        /// </summary>
        public Guid From_UserId { get; set; }
        /// <summary>
        /// 接收群组（群组编号）
        /// </summary>
        public Guid To_GroupId { get; set; }

        /// <summary>
        /// 排序自增字段
        /// </summary>
        public long SortId { get; set; }
        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTime { get; set; }
        /// <summary>
        /// 是否全部已读
        /// </summary>
        public bool IsFullRead { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public IM_MsgType MsgType { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgBody { get; set; }

        /// <summary>
        /// IM消息-群组-已读状态集合
        /// </summary>
        public virtual ICollection<IM.IM_MsgGroup_ReadState> IM_MsgGroup_ReadStates { get; set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public virtual IM.IM_User From_IM_User { get; set; }
        /// <summary>
        /// 接收群组
        /// </summary>
        public virtual IM.IM_Group To_IM_Group { get; set; }

    }

    /// <summary>
    /// IM消息-群组-已读状态
    /// </summary>
    public class IM_MsgGroup_ReadState : BaseModel
    {
        public IM_MsgGroup_ReadState()
            : base()
        {

        }

        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid IM_MsgGroup_Id { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid User_id { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// IM消息-群组
        /// </summary>
        public virtual IM.IM_MsgGroup IM_MsgGroup { get; set; }
        /// <summary>
        /// 群组消息读取者
        /// </summary>
        public virtual IM.IM_User IM_User { get; set; }
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum IM_MsgType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text = 1,
        /// <summary>
        /// 表情
        /// </summary>
        Expression = 2,
        /// <summary>
        /// 图片
        /// </summary>
        Img = 3,
        /// <summary>
        /// 文件
        /// </summary>
        File = 4,
        /// <summary>
        /// 语音
        /// </summary>
        Voice = 5,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 6,
        /// <summary>
        /// 位置
        /// </summary>
        LBS = 7
    }

    /**************************************************************************************************************/

    #region 消息扩展

    /// <summary>
    /// IM消息-内容1-文本
    /// </summary>
    public class IM_MsgText : BaseModel
    {
        public IM_MsgText()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    /// <summary>
    /// IM消息-内容2-表情
    /// </summary>
    public class IM_MsgExpression : BaseModel
    {
        public IM_MsgExpression()
            : base()
        {

        }



        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }
    }

    /// <summary>
    /// IM消息-内容3-图片
    /// </summary>
    public class IM_MsgImg : BaseModel
    {
        public IM_MsgImg()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    /// <summary>
    /// IM消息-内容4-文件
    /// </summary>
    public class IM_MsgFile : BaseModel
    {
        public IM_MsgFile()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    /// <summary>
    /// IM消息-内容5-语音
    /// </summary>
    public class IM_MsgVoice : BaseModel
    {
        public IM_MsgVoice()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    /// <summary>
    /// IM消息-内容6-视频
    /// </summary>
    public class IM_MsgVideo : BaseModel
    {
        public IM_MsgVideo()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    /// <summary>
    /// IM消息-内容7-位置
    /// </summary>
    public class IM_MsgLBS : BaseModel
    {
        public IM_MsgLBS()
            : base()
        {

        }


        /// <summary>
        /// App编号
        /// </summary>
        public Guid App_Id { get; set; }
        /// <summary>
        /// Msg编号
        /// </summary>
        public Guid Msg_Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgContent { get; set; }

    }

    #endregion




}
