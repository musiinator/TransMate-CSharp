using System.Collections.Generic;
using TransportModel.domain;
namespace TransportService
{
    public interface TransportServiceInterface
    {
        //USER Service
        User findOneUser(long id);
        IEnumerable<User> findAllUsers();
        User saveUser(User user);
        void updateUser(User user);
        User deleteUser(long id);
        User findUserByUsername(string username);
        void login(User user, TransportObserverInterface client);
        void logout(User user, TransportObserverInterface client);

        //CURSA Service
        Cursa findOneCursa(long id);
        IEnumerable<Cursa> findAllCurse();
        Cursa saveCursa(Cursa cursa);
        Cursa deleteCursa(long id);
        Cursa updateCursa(Cursa cursa);
        List<Cursa> findCursaByDestinatie(string destinatie);
        List<Cursa> findCursaByDataOraPlecare(string dataOraPlecare);

        //REZERVARE Service
        Rezervare findOneRezervare(long id);
        IEnumerable<Rezervare> findAllRezervari();
        Rezervare saveRezervare(Rezervare rezervare);
        Rezervare updateRezervare(Rezervare newRezervare);
        Rezervare deleteRezervare(long id);
        List<Rezervare> findRezervareByIdCursa(long idCursa);
    }
}