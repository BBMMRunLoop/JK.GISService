using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JK.GISService.ViewModels;
using DomainModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JK.GISService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseInfoController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BaseInfoController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

 

        [HttpGet("{pid}")]
        public object loadBaseInfo(Guid pid)
        {
            if (pid == null || pid == Guid.Empty)
            {

                return new VMResultError("未收到有效的项目ID");
            }

            tabBaseInfo tbBaseInfo = _dataAccessProvider.getTabBaseInfo(pid);
            if (tbBaseInfo == null)
            {

                return new VMResultError("未找到项目对应的地图初始化信息");
            }


            return new VMResultOK("", tbBaseInfo);


        }

        [HttpGet ("{pstr}")]
        public object dockerTest(string pstr) {

            return pstr;
        }
    }
}
