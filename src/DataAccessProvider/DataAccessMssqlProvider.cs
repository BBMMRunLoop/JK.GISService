using DataAccessManager;
using DomainModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessProvider
{
    public class DataAccessMssqlProvider : IDataAccessProvider
    {
        private readonly DomainModelContext _context;
        private readonly ILogger _logger;

        public DataAccessMssqlProvider(DomainModelContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMssqlProvider");
           


        }
        public tabBaseInfo getTabBaseInfo(Guid projectId)
        {
           

            return _context.tabBaseInfo.Where(it => it.pjid == projectId).FirstOrDefault();
        }

        public void saveTabBaseInfo(tabBaseInfo tabInfo)
        {
            throw new NotImplementedException();
        }
    }
}
