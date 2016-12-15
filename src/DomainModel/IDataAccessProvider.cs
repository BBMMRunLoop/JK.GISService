using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
   public interface IDataAccessProvider
    {
        /// <summary>
        /// 保存地图基本信息
        /// </summary>
        /// <param name="tabInfo"></param>
        void saveTabBaseInfo(tabBaseInfo tabInfo);
   
        /// <summary>
        /// 根据工程ID得到一个地图基本信息
        /// </summary>
        /// <param name="baseInfoId"></param>
        /// <returns></returns>
        tabBaseInfo getTabBaseInfo(Guid projectId);


    }
}
