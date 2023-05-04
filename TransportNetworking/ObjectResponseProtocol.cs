using System;
using System.Collections.Generic;
using TransportModel.domain;

namespace TransportNetworking
{
    public interface Response
    {

    }

    [Serializable]
    public class OkResponse : Response
    {

    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get { return message; }
        }
    }

    [Serializable]
    public class GetUserByUsernameResponse : Response
    {
        private User user;

        public GetUserByUsernameResponse(User user)
        {
            this.user = user;
        }

        public virtual User User
        {
            get { return user; }
        }
    }

    [Serializable]
    public class GetCurseResponse : Response
    {
        private IEnumerable<Cursa> curse;

        public GetCurseResponse(IEnumerable<Cursa> curse)
        {
            this.curse = curse;
        }

        public virtual IEnumerable<Cursa> Curse
        {
            get { return curse; }
        }
    }

    [Serializable]
    public class GetRezervariResponse : Response
    {
        private IEnumerable<Rezervare> rezervari;

        public GetRezervariResponse(IEnumerable<Rezervare> rezervari)
        {
            this.rezervari = rezervari;
        }

        public virtual IEnumerable<Rezervare> Rezervari
        {
            get { return rezervari; }
        }
    }

    [Serializable]
    public class GetRezervariByIdCursaResponse : Response
    {
        private List<Rezervare> rezervari;

        public GetRezervariByIdCursaResponse(List<Rezervare> rezervari)
        {
            this.rezervari = rezervari;
        }

        public virtual List<Rezervare> Rezervari
        {
            get { return rezervari; }
        }
    }
    
    [Serializable]
    public class UpdateCursaResponse : Response
    {
        private Cursa cursa;

        public UpdateCursaResponse(Cursa cursa)
        {
            this.cursa = cursa;
        }

        public virtual Cursa Cursa
        {
            get { return cursa; }
        }
    }

    [Serializable]
    public class SaveRezervareResponse : Response
    {
        private Rezervare rezervare;

        public SaveRezervareResponse(Rezervare rezervare)
        {
            this.rezervare = rezervare;
        }

        public virtual Rezervare Rezervare
        {
            get { return rezervare; }
        }
    }
    
    [Serializable]
    public class NewRezervareResponse : UpdateResponse
    {
        private Rezervare rezervare;

        public NewRezervareResponse(Rezervare rezervare)
        {
            this.rezervare = rezervare;
        }

        public virtual Rezervare Rezervare
        {
            get { return rezervare; }
        }
    }

    public interface UpdateResponse : Response
    {

    }
    
}