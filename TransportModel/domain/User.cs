using System;

namespace TransportModel.domain
{
    [Serializable]
    public class User : Entity<long>
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            User client = (User)obj;
            return username == client.username && password == client.password;
        }

        public override string ToString()
        {
            return "Client{" +
                   "username='" + username + '\'' +
                   ", password=" + password +
                   '}';
        }
    }
}

