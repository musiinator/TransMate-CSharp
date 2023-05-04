using TransportModel.domain;

namespace TransportPersistance.repository
{
    public interface UserRepoInterface : Repository<long, User>
    {
        User findByUsername(string username);
    }   
}