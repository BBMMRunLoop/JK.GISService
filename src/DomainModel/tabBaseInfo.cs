using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class tabBaseInfo
    {
       
        [Key]
        public Guid id { get; set; }
        /// <summary>
        /// 初始化地图url
        /// </summary>
        public string initMapURL { get; set; }
        /// <summary>
        /// 地图坐标系
        /// </summary>
        public string mapProject { get; set; }

        /// <summary>
        /// 初始化位置x
        /// </summary>
        public double initX { get; set; }

        /// <summary>
        /// 初始化位置y
        /// </summary>
        public double initY { get; set; }

       /// <summary>
       /// 初始化缩放比例
       /// </summary>
        public double initScale { get; set; }

        /// <summary>
        /// 初始化图层ID集合 已弃用
        /// </summary>
        public string initLayers { get; set; }

        /// <summary>
        /// 是否开始加载图层列表
        /// </summary>
        public int addLayerList { get; set; }

        /// <summary>
        /// 是否开始加载鹰眼
        /// </summary>
        public int addOverviewMap { get; set; }

        /// <summary>
        /// 是否开始加载缩放比例
        /// </summary>
        public int addScaleLine { get; set; }

        /// <summary>
        /// 是否初始化加载比例尺
        /// </summary>
        public int addZoomBar { get; set; }
        /// <summary>
        /// 项目编号 关联项目表的主键
        /// </summary>
        public Guid pjid { get; set; }
    }
}
