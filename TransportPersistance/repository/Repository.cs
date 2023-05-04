using TransportModel.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportPersistance.repository
{
    public interface Repository<ID, E> where E : Entity<ID>
    {
        E findOne(ID id);
        IEnumerable<E> findAll();
        E save(E Entity);
        E delete(ID id);
        E update(E entity);
    }
}
