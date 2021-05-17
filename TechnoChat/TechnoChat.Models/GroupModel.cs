using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoChat.Models
{
    public class GroupModel
    {
        private string _name;
        private List<UserModel> _users;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public List<UserModel> Users
        {
            get
            {
                return _users=_users??new List<UserModel>();
            }

            set
            {
                _users = value;
            }
        }
    }
}
