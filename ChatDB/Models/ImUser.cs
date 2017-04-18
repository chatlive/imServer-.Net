//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("ImUser")]
//    public partial class ImUser
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public ImUser()
//        {
//            IM_Chatter = new HashSet<IM_Chatter>();
//            IM_Chatter1 = new HashSet<IM_Chatter>();
//            IM_ChatterActor = new HashSet<IM_ChatterActor>();
//            IM_MsgGroup = new HashSet<IM_MsgGroup>();
//            IM_MsgGroup_ReadState = new HashSet<IM_MsgGroup_ReadState>();
//            IM_MsgSingle = new HashSet<IM_MsgSingle>();
//            IM_MsgSingle1 = new HashSet<IM_MsgSingle>();
//            ImGroups = new HashSet<ImGroup>();
//        }

//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string UserId { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string Name { get; set; }

//        [Required]
//        [StringLength(500)]
//        public string PortraitUri { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_Chatter> IM_Chatter { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_Chatter> IM_Chatter1 { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_ChatterActor> IM_ChatterActor { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_MsgGroup> IM_MsgGroup { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_MsgGroup_ReadState> IM_MsgGroup_ReadState { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_MsgSingle> IM_MsgSingle { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_MsgSingle> IM_MsgSingle1 { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<ImGroup> ImGroups { get; set; }
//    }
//}
