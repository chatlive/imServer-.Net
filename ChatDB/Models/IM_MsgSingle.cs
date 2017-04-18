//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class IM_MsgSingle
//    {
//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string MsgClientId { get; set; }

//        public Guid From_UserId { get; set; }

//        public Guid To_UserId { get; set; }

//        public DateTime MsgTime { get; set; }

//        public bool IsRead { get; set; }

//        public int MsgType { get; set; }

//        [Required]
//        [StringLength(1000)]
//        public string MsgBody { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        public virtual ImUser ImUser { get; set; }

//        public virtual ImUser ImUser1 { get; set; }
//    }
//}
