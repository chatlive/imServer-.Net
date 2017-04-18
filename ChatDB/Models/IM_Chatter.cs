//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class IM_Chatter
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public IM_Chatter()
//        {
//            IM_ChatterActor = new HashSet<IM_ChatterActor>();
//        }

//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        public int ChatType { get; set; }

//        public Guid? Single_A_UserId { get; set; }

//        public Guid? Single_B_UserId { get; set; }

//        public Guid? Group_GroupId { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        public virtual ImGroup ImGroup { get; set; }

//        public virtual ImUser ImUser { get; set; }

//        public virtual ImUser ImUser1 { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_ChatterActor> IM_ChatterActor { get; set; }
//    }
//}
