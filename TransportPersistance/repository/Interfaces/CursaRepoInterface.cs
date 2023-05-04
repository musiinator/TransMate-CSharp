using System.Collections.Generic;
using TransportPersistance.repository;
using TransportModel.domain;

namespace TransportPersistance.repository.Interfaces
{
    public interface CursaRepoInterface : Repository<long, Cursa>
    {
        List<Cursa> findByDestinatie(string destinatie);
        List<Cursa> findByDataOraPlecare(string dataOraPlecare);
    }   
}