using System;
using TransportPersistance.repository;
using TransportPersistance.repository.database;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using TransportNetworking;
using TransportPersistance.repository.Interfaces;
using TransportService;

namespace TransportServer
{
    public class StartServer
    {
        static void Main(string[] args)
        {
            UserRepoInterface userRepo = new UserDataBase(GetConnectionStringByName("transport"));
            CursaRepoInterface cursaRepo = new CursaDataBase(GetConnectionStringByName("transport"));
            RezervareRepoInterface rezervareRepo = new RezervareDataBase(GetConnectionStringByName("transport"));
            
            TransportServiceInterface service = new Service(userRepo, cursaRepo, rezervareRepo);

            SerialTransportServer server = new SerialTransportServer("127.0.0.1", 55555, service);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
        
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }
    }

    public class SerialTransportServer : ConcurrentServer
    {
        private TransportServiceInterface server;
        private TransportClientObjectWorker worker;
        
        public SerialTransportServer(string host, int port, TransportServiceInterface server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialTransportServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new TransportClientObjectWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}