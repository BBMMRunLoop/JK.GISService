using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JK.GISService.ViewModels
{
    public class VMResult
    {
        public string message { get; set; }
        public bool success { get; set; }
        public object data { get; set; }
    }

    public class VMResultOK : VMResult {

        public VMResultOK(string ms,object _data) {
            this.success = true;
            this.message = ms;
            this.data = _data;
        }

    }

    public class VMResultError : VMResult {

        public VMResultError(string ms)
        {
            this.success = false;
            this.message = ms;
            this.data = null;
        }
    }

}
