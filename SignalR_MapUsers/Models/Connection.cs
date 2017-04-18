namespace SignalR_MapUsers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Connection
    {
        public string ConnectionID { get; set; }

        public string UserAgent { get; set; }

        public bool Connected { get; set; }

        [StringLength(128)]
        public string User_UserName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual User User { get; set; }
    }
}
