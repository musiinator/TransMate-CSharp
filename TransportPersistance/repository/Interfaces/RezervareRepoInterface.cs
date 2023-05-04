using System.Collections.Generic;
using TransportModel.domain;

namespace TransportPersistance.repository.Interfaces
{
    public interface RezervareRepoInterface : Repository<long, Rezervare>
    {
        List<Rezervare> findByIdCursa(long idCursa);
    }
}