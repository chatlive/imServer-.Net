//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class IM_ChatterActor
//    {
//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        public Guid ChatterId { get; set; }

//        public Guid UserId { get; set; }

//        public Guid Last_MsgId { get; set; }

//        public int UnreadMsgCount { get; set; }

//        public DateTime ChatterTime { get; set; }

//        public bool IsCleared { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        public virtual IM_Chatter IM_Chatter { get; set; }

//        public virtual ImUser ImUser { get; set; }
//    }
//}
