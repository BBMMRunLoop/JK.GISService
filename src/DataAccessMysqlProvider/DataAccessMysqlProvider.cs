using DomainModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessMysqlProvider
{
    public class DataAccessMysqlProvider : IDataAccessProvider
    {
        private readonly DomainModelMysqlContext _context;
        private readonly ILogger _logger;
        public DataAccessMysqlProvider(DomainModelMysqlContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMysqlProvider");

        }

        public tabBaseInfo getTabBaseInfo(Guid projectId)
        {
            return _context.tabBaseInfo.First(it => it.pjid == projectId);
        }

        public void saveTabBaseInfo(tabBaseInfo tabInfo)
        {
            throw new NotImplementedException();
        }
    }
}
