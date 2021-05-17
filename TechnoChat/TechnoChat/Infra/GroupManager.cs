using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnoChat.Infra.Interfaces;
using TechnoChat.Models;

namespace TechnoChat.Infra
{
    public class GroupManager : IGroupManager
    {
        private readonly List<GroupModel> _groups;

        public GroupManager()
        {
            _groups = new List<GroupModel>();
        }


        public bool AddUserToGroup(string user, string connectionId, string groupName)
        {
            try
            {
                UserModel um = new UserModel() { ConnectionId = connectionId, Name = user };
                if (_groups.Count(c => c.Name == groupName) < 1)
                {
                    _groups.Add(new GroupModel() { Name = groupName });
                }
                _groups.First(c => c.Name == groupName).Users.Add(um);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GroupModel> ListOfGroup()
        {
            return _groups;
        }

        public List<UserModel> ListUserOfGroup(string groupName)
        {
            return _groups.FirstOrDefault(c => c.Name == groupName)?.Users;
        }

        public bool RemoveUserFromGroup(string user, string groupName)
        {
            try
            {
                GroupModel gm = _groups.FirstOrDefault(c => c.Name == groupName);
                if (gm != null)
                {
                    UserModel um = gm.Users.FirstOrDefault(u => u.Name == user);
                    if (um != null)
                    {
                        gm.Users.Remove(um);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
