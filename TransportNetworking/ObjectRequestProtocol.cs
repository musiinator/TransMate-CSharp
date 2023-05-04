using System;
using TransportModel.domain;

namespace TransportNetworking
{
    public interface Request
    {
    }

    [Serializable]
    public class LoginRequest : Request
    {
        private User user;
        public LoginRequest(User user)
        {
            this.user = user;
        }
        
        public virtual User User
        {
            get
            {
                return user;
            }
        }
    }
    
    [Serializable]
    public class LogoutRequest : Request
    {
        private User user;

        public LogoutRequest(User user)
        {
            this.user = user;
        }

        public virtual User User
        {
            get
            {
                return user;
            }
        }
    }
    

    [Serializable]
    public class GetUserByUsernameRequest : Request
    {
        private string username;

        public GetUserByUsernameRequest(string username)
        {
            this.username = username;
        }

        public string Username
        {
            get
            {
                return username;
            }
        }
    }

    [Serializable]
    public class GetCurseRequest : Request
    {
        public GetCurseRequest()
        {
            
        }
    }
    
    [Serializable]
    public class GetRezervariRequest : Request
    {
        public GetRezervariRequest()
        {
            
        }
    }
    
    [Serializable]
    public class GetRezervariByIdCursaRequest : Request
    {
        private long idCursa;
        public GetRezervariByIdCursaRequest(long idCursa)
        {
            this.idCursa = idCursa;
        }
        public virtual long IdCursa
        {
            get
            {
                return idCursa;
            }
        }
    }
    
    [Serializable]
    public class SaveRezervareRequest : Request
    {
        private Rezervare rezervare;
        public SaveRezervareRequest(Rezervare rezervare)
        {
            this.rezervare = rezervare;
        }
        public virtual Rezervare Rezervare
        {
            get
            {
                return rezervare;
            }
        }
    }

    [Serializable]
    public class UpdateCursaRequest : Request
    {
        private Cursa cursa;
        public UpdateCursaRequest(Cursa cursa)
        {
            this.cursa = cursa;
        }
        public virtual Cursa Cursa
        {
            get
            {
                return cursa;
            }
        }
    }
    

}