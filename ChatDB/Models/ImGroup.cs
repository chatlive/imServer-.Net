//namespace ChatDB.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("ImGroup")]
//    public partial class ImGroup
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public ImGroup()
//        {
//            IM_Chatter = new HashSet<IM_Chatter>();
//            IM_MsgGroup = new HashSet<IM_MsgGroup>();
//            ImUsers = new HashSet<ImUser>();
//        }

//        public Guid Id { get; set; }

//        public Guid App_Id { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string GroupId { get; set; }

//        [Required]
//        [StringLength(200)]
//        public string GroupName { get; set; }

//        public DateTime CreateTime { get; set; }

//        public string CreateUser { get; set; }

//        public DateTime UpdateTime { get; set; }

//        public string UpdateUser { get; set; }

//        public int State { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_Chatter> IM_Chatter { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<IM_MsgGroup> IM_MsgGroup { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<ImUser> ImUsers { get; set; }
//    }
//}
