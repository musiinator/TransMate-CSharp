using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using TransportModel.domain;
using TransportService;

namespace TransportNetworking
{
    public class TransportClientObjectWorker : TransportObserverInterface
    {
        private TransportServiceInterface server;
        private TcpClient connection;
        
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        
        public TransportClientObjectWorker(TransportServiceInterface server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest)request;
                User user = logReq.User;
                try
                {
                    lock (server)
                    {
                        server.login(user, this);
                    }
                    return new OkResponse();
                }
                catch (Exception e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest)request;
                User user = logReq.User;
                try
                {
                    lock (server)
                    {
                        server.logout(user, this);
                    }
                    
                    connected = false;
                    return new OkResponse();
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetUserByUsernameRequest)
            {
                Console.WriteLine("GetUserByUsernameRequest ...");
                GetUserByUsernameRequest getUserByUsernameRequest = (GetUserByUsernameRequest)request;
                String username = getUserByUsernameRequest.Username;
                try
                {
                    lock (server)
                    {
                        User user = server.findUserByUsername(username);
                        return new GetUserByUsernameResponse(user);
                    }
                }
                catch (Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetCurseRequest)
            {
                Console.WriteLine("GetCurseRequest ...");
                try
                {
                    IEnumerable<Cursa> curse;
                    lock (server)
                    {
                        curse = server.findAllCurse();
                    }
                    return new GetCurseResponse(curse);
                }catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetRezervariByIdCursaRequest)
            {
                Console.WriteLine("GetRezervariByIdCursaRequest ...");
                GetRezervariByIdCursaRequest getRezervariByIdCursaRequest = (GetRezervariByIdCursaRequest)request;
                long idCursa = getRezervariByIdCursaRequest.IdCursa;
                try
                {
                    List<Rezervare> rezervari;
                    lock (server)
                    {
                        rezervari = server.findRezervareByIdCursa(idCursa);
                    }
                    return new GetRezervariByIdCursaResponse(rezervari);
                }catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is SaveRezervareRequest)
            {
                Console.WriteLine("SaveRezervareRequest ...");
                SaveRezervareRequest saveRezervareRequest = (SaveRezervareRequest)request;
                Rezervare rezervare = saveRezervareRequest.Rezervare;
                try
                {
                    lock (server)
                    {
                        server.saveRezervare(rezervare);
                    }

                    return new SaveRezervareResponse(rezervare);
                }catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is UpdateCursaRequest)
            {
                Console.WriteLine("UpdateCursaRequest ...");
                UpdateCursaRequest updateCursaRequest = (UpdateCursaRequest)request;
                Cursa cursa = updateCursaRequest.Cursa;
                try
                {
                    lock (server)
                    {
                        server.updateCursa(cursa);
                    }

                    return new UpdateCursaResponse(cursa);
                }catch(Exception e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            return response;
        }

        public void rezervareReceived(Rezervare rezervare)
        {
            Console.WriteLine("Rezervare received " + rezervare);
            try
            {
                sendResponse(new NewRezervareResponse(rezervare));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response "+response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }

        }
    }
}