using System;

namespace TechnoChat.Models
{
    public class UserModel
    {
        private string _name, _connectionId, _token;
        
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

        public string ConnectionId
        {
            get
            {
                return _connectionId;
            }

            set
            {
                _connectionId = value;
            }
        }

        public string Token
        {
            get
            {
                return _token;
            }

            set
            {
                _token = value;
            }
        }
    }
}
