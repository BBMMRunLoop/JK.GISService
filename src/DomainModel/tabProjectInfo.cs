using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class tabProjectInfo
    {
        [Key]
        public Guid id { get; set; }
        /// <summary>
        /// 工程名
        /// </summary>
        public string pname { get; set; }

        /// <summary>
        /// 工程描述
        /// </summary>
        public string pdesc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime cdTime { get; set; }

        /// <summary>
        /// 项目说明
        /// </summary>
        public string projectMark { get; set; }
    }
}
