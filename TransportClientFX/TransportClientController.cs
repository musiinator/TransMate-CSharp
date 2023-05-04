using System;
using System.Collections.Generic;
using System.Data.SQLite;
using TransportModel.domain;
using TransportService;

namespace TransportClientFX
{
    public class TransportClientController : TransportObserverInterface
    {
        private readonly TransportServiceInterface server;
        public event EventHandler<UserEventArgs> updateEvent;

        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if(updateEvent == null)
                return;
            updateEvent(this, e);
        }
        public void rezervareReceived(Rezervare rezervare)
        {
            UserEventArgs userEventArgs = new UserEventArgs(UserEvent.RezervareReceived, rezervare);
            OnUserEvent(userEventArgs);
        }
        
        public TransportClientController(TransportServiceInterface server)
        {
            this.server = server;
        }
        
        public void login(string username, string password)
        {
            User user = new User(username, password);
            server.login(user, this);
        }
        
        public void logout(User user)
        {
            server.logout(user, this);
        }
        
        public User findUserByUsername(string username)
        {
            return server.findUserByUsername(username);
        }
        
        public IEnumerable<Cursa> getAllCurse()
        {
            try
            {
                return server.findAllCurse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
        
        public IEnumerable<Rezervare> getRezervariByIdCursa(long idCursa)
        {
            try
            {
                return server.findRezervareByIdCursa(idCursa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
        
        public Rezervare saveRezervare(Rezervare rezervare)
        {
            try
            {
                return server.saveRezervare(rezervare);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
        
        public Cursa updateCursa(Cursa cursa)
        {
            try
            {
                return server.updateCursa(cursa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }
    }
}