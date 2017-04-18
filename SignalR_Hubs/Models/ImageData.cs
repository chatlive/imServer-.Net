using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models
{
    /// <summary>
    /// Image实体
    /// </summary>
   public class ImageData
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// 图像数据
        /// </summary>
        public string Image { get; set; }
    }
}
