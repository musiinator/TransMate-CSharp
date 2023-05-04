using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using TransportModel.domain;
using TransportService;

namespace TransportNetworking
{
    [Serializable]
    public class TransportServerObjectProxy : TransportServiceInterface
    {
        private string host;
        private int port;
        private TransportObserverInterface client;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<Response> responses;
        
        private volatile bool finished;
        private EventWaitHandle waitHandle;
        
        public TransportServerObjectProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }
        
        public virtual void login(User user, TransportObserverInterface client)
        {
            initializeConnection();
            sendRequest(new LoginRequest(user));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                closeConnection();
                throw new Exception(err.Message);
            }
        }
        
        public virtual void logout(User user, TransportObserverInterface client)
        {
            sendRequest(new LogoutRequest(user));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
        }
        
        public User findUserByUsername(string username)
        {
            sendRequest(new GetUserByUsernameRequest(username));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            GetUserByUsernameResponse resp = (GetUserByUsernameResponse) response;
            return resp.User;
        }

        public IEnumerable<Cursa> findAllCurse()
        {
            sendRequest(new GetCurseRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            GetCurseResponse resp = (GetCurseResponse) response;
            return resp.Curse;
        }

        public List<Rezervare> findRezervareByIdCursa(long id)
        {
            sendRequest(new GetRezervariByIdCursaRequest(id));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            GetRezervariByIdCursaResponse resp = (GetRezervariByIdCursaResponse) response;
            return resp.Rezervari;
        }
        
        public Rezervare saveRezervare(Rezervare rezervare) {
            sendRequest(new SaveRezervareRequest(rezervare));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            SaveRezervareResponse resp = (SaveRezervareResponse) response;
            return resp.Rezervare;
        }
        
        public Cursa updateCursa(Cursa cursa) {
            sendRequest(new UpdateCursaRequest(cursa));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse) response;
                throw new Exception(err.Message);
            }
            UpdateCursaResponse resp = (UpdateCursaResponse) response;
            return resp.Cursa;
        }

        private Response readResponse()
        {
            Response response =null;
            try
            {
                waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        
        private void sendRequest(Request request)
        {
            try
            {
                if (connection == null || !connection.Connected)
                {
                    throw new Exception("Error sending object. Connection is null or not connected.");
                }
        
                if (stream == null)
                {
                    stream = connection.GetStream();
                    if (stream == null)
                    {
                        throw new Exception("Error sending object. Stream is null.");
                    }
                }
        
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new Exception("Error sending object. " + e.Message, e);
            }
        }



        private void initializeConnection()
        {
            try
            {
                Console.WriteLine(host + port);
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        private void closeConnection()
        {
            finished=true;
            try
            {
                stream.Close();
			
                connection.Close();
                waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
        
        public void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }
        
        private void handleUpdate(UpdateResponse update)
        {
            if (update is NewRezervareResponse)
            {
                NewRezervareResponse saveRezervare = (NewRezervareResponse) update;
                try
                {
                    client.rezervareReceived(saveRezervare.Rezervare);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        
        public virtual void run()
        {
            while(!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received "+response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {
							
                        lock (responses)
                        {
                                					
								 
                            responses.Enqueue((Response)response);
                               
                        }
                        waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
					
            }
        }
        
        public User findOneUser(long id)
        {
            return null;
        }
        public IEnumerable<User> findAllUsers()
        {
            return null;
        }

        public User saveUser(User user)
        {
            return null;
        }
        
        public void updateUser(User user)
        {
        }
        
        public User deleteUser(long id)
        {
            return null;
        }
        
        public Cursa findOneCursa(long id) {
            return null;
        }
        
        public Cursa saveCursa(Cursa cursa) {
            return null;
        }

        public Cursa deleteCursa(long id) {
            return null;
        }
        public List<Cursa> findCursaByDestinatie(String destinatie) {
            return null;
        }
        public List<Cursa> findCursaByDataOraPlecare(String dateTime) {
            return null;
        }

        public Rezervare findOneRezervare(long id)
        {
            return null;
        }
        
        public IEnumerable<Rezervare> findAllRezervari()
        {
            return null;
        }
        
        public Rezervare updateRezervare(Rezervare rezervare) {
            return null;
        }
        public Rezervare deleteRezervare(long id) {
            return null;
        }
    }
}