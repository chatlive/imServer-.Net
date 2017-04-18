//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class IM_MsgGroup_ReadState
//    {
//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        public Guid IM_MsgGroup_Id { get; set; }

//        public Guid User_id { get; set; }

//        public bool IsRead { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        public virtual IM_MsgGroup IM_MsgGroup { get; set; }

//        public virtual ImUser ImUser { get; set; }
//    }
//}
