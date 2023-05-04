using TransportModel.domain;

namespace TransportService
{
    public interface TransportObserverInterface
    {
        void rezervareReceived(Rezervare rezervare);
    }
}