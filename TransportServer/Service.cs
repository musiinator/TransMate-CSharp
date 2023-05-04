using TransportModel.domain;
using TransportPersistance.repository.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportPersistance.repository;
using TransportService;

namespace TransportServer
{
    public class Service : TransportServiceInterface
    {
        private UserRepoInterface repoUser;
        private CursaRepoInterface repoCursa;
        private RezervareRepoInterface repoRezervare;
        
        private readonly IDictionary<long, TransportObserverInterface> loggedClients;

        public Service(UserRepoInterface repoUser, CursaRepoInterface repoCursa, RezervareRepoInterface repoRezervare)
        {
            this.repoUser = repoUser;
            this.repoCursa = repoCursa;
            this.repoRezervare = repoRezervare;
            loggedClients = new Dictionary<long, TransportObserverInterface>();
        }

        //USER Service
        public User findOneUser(long id)
        {
            return repoUser.findOne(id);
        }

        public IEnumerable<User> findAllUsers()
        {
            return repoUser.findAll();
        }

        public User saveUser(User user)
        {
            return repoUser.save(user);
        }

        public void updateUser(User user)
        {
            repoUser.update(user);
        }

        public User deleteUser(long id)
        {
            return repoUser.delete(id);
        }

        public User findUserByUsername(string username)
        {
            return repoUser.findByUsername(username);
        }

        public void login(User user, TransportObserverInterface client)
        {
            User userFound = repoUser.findByUsername(user.Username);
            if(user.Password.Equals(userFound.Password))
            {
                if(loggedClients.ContainsKey(userFound.GetId()))
                    throw new Exception("User already logged in!");
                loggedClients[userFound.GetId()] = client;
            }
            else
                throw new Exception("Wrong username or password!");
        }
        
        public void logout(User user, TransportObserverInterface client)
        {
            TransportObserverInterface localClient = loggedClients[user.GetId()];
            if(localClient == null)
                throw new Exception("User " + user.Username + " is not logged in!");
            loggedClients.Remove(user.GetId());
        }

        //CURSA Service
        public Cursa findOneCursa(long id)
        {
            return repoCursa.findOne(id);
        }

        public IEnumerable<Cursa> findAllCurse()
        {
            return repoCursa.findAll();
        }

        public Cursa saveCursa(Cursa cursa)
        {
            return repoCursa.save(cursa);
        }

        public Cursa deleteCursa(long id)
        {
            return repoCursa.delete(id);
        }

        public Cursa updateCursa(Cursa cursa)
        {
            return repoCursa.update(cursa);
        }

        public List<Cursa> findCursaByDestinatie(String destinatie)
        {
            return repoCursa.findByDestinatie(destinatie);
        }

        public List<Cursa> findCursaByDataOraPlecare(String dataOraPlecare)
        {
            return repoCursa.findByDataOraPlecare(dataOraPlecare);
        }


        //REZERVARE Service
        public Rezervare findOneRezervare(long id)
        {
            return repoRezervare.findOne(id);
        }

        public IEnumerable<Rezervare> findAllRezervari()
        {
            return repoRezervare.findAll();
        }

        public Rezervare saveRezervare(Rezervare rezervare)
        {
            repoRezervare.save(rezervare);
            notifyUsers(rezervare);
            return rezervare;
        }

        public Rezervare updateRezervare(Rezervare newRezervare)
        {
            return repoRezervare.update(newRezervare);
        }

        public Rezervare deleteRezervare(long id)
        {
            return repoRezervare.delete(id);
        }

        public List<Rezervare> findRezervareByIdCursa(long idCursa)
        {
            return repoRezervare.findByIdCursa(idCursa);
        }

        private async void notifyUsers(Rezervare rezervare)
        {
            foreach (var loggedClient in loggedClients)
            {
                TransportObserverInterface client = loggedClients[loggedClient.Key];
                await Task.Run(() => client.rezervareReceived(rezervare));
            }
        }
    }
}
