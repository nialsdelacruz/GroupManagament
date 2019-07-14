using PlayBall.GroupManagement.Business.Models;
using PlayBall.GroupManagement.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayBall.GroupMangament.Business.Imp.Services
{
    public class InMemoryGroupsService : IGroupsService
    {
        private readonly List<Group> _groups = new List<Group>();
        private long _currentId = 0;


        public Group Add(Group group)
        {
            group.Id = ++_currentId;
            _groups.Add(group);
            return group;
        }

        public IReadOnlyCollection<Group> GetAll()
        {
            return _groups.AsReadOnly();
        }

        public Group GetById(long id)
        {
            return _groups.SingleOrDefault(g => g.Id == id);
        }

        public Group Update(Group group)
        {
            var groupToUpdate = _groups.SingleOrDefault(g => g.Id == group.Id);

            if (groupToUpdate == null)
            {
                return null;
            }

            groupToUpdate.Name = group.Name;
            return groupToUpdate;
        }
    }
}
