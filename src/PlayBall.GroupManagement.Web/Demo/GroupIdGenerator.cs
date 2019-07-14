using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayBall.GroupManagement.Web.Demo
{
    

    public class GroupIdGenerator : IGroupIdGenerator
    {
        private long _currentId = 1;

        public long Next()
        {
            return ++_currentId;
        }
        
    }
}
