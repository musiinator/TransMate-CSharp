using System;
using System.Collections.Generic;
using TransportModel.domain;
using System.Data.SQLite;
using System.Windows.Forms;
using log4net;
using TransportPersistance.repository.Interfaces;

namespace TransportPersistance.repository.database
{
    public class RezervareDataBase : RezervareRepoInterface
    {
        
        public static readonly ILog log = LogManager.GetLogger("RezervareDataBase");
        private string ConnectionString;
        
        public RezervareDataBase(string connectionString)
        {
            log.Info("Creating RezervareDataBase");
            ConnectionString = connectionString;
        }
        
        public Rezervare findOne(long id)
        {
            log.Info("Entering findOne");
            Rezervare rezervare = null;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand =
                        new SQLiteCommand("select * from rezervare where id_rezervare=@id", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idRezervare = sQLiteDataReader.GetInt32(0);
                        string numeClient = sQLiteDataReader.GetString(1);
                        int nrLocuri = sQLiteDataReader.GetInt32(2);
                        int idCursa = sQLiteDataReader.GetInt32(3);
                        rezervare = new Rezervare(numeClient, nrLocuri, idCursa);
                        rezervare.SetId(idRezervare);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.Info("Exiting findOne");
            return rezervare;
        }
        
        public IEnumerable<Rezervare> findAll()
        {
            log.Info("Entering findAll");
            List<Rezervare> rezervari = new List<Rezervare>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from rezervare", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idRezervare = sQLiteDataReader.GetInt32(0);
                        string numeClient = sQLiteDataReader.GetString(1);
                        int nrLocuri = sQLiteDataReader.GetInt32(2);
                        int idCursa = sQLiteDataReader.GetInt32(3);
                        Rezervare rezervare = new Rezervare(numeClient, nrLocuri, idCursa);
                        rezervare.SetId(idRezervare);
                        rezervari.Add(rezervare);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.Info("Exiting findAll");
            return rezervari;
        }
        
        public Rezervare save(Rezervare entity)
        {
            log.InfoFormat("Entering save with value {0}", entity); 
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("insert into rezervare(nume_client, nr_locuri, id_cursa) values (@nume, @nr, @id)", connection);
                    sQLiteCommand.Parameters.AddWithValue("@nume", entity.NumeClient);
                    sQLiteCommand.Parameters.AddWithValue("@nr", entity.NrLocuri);
                    sQLiteCommand.Parameters.AddWithValue("@id", entity.IdCursa);
                    sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting save with value {0}", entity);
            return entity;
        }
        public Rezervare delete(long id)
        {
            log.InfoFormat("Entering delete with value {0}", id);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("delete from rezervare where id_rezervare=@id", connection);
                    sQLiteCommand.Parameters.AddWithValue("@id", id);
                    sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting delete with value {0}", id);
            return null;
        }
        public Rezervare update(Rezervare entity)
        {
            log.InfoFormat("Entering update with value {0}", entity);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("update rezervare set nume_client=@nume, nr_locuri=@nr, id_cursa=@id where id_rezervare=@idRezervare", connection);
                    sQLiteCommand.Parameters.AddWithValue("@nume", entity.NumeClient);
                    sQLiteCommand.Parameters.AddWithValue("@nr", entity.NrLocuri);
                    sQLiteCommand.Parameters.AddWithValue("@id", entity.IdCursa);
                    sQLiteCommand.Parameters.AddWithValue("@idRezervare", entity.GetId());
                    sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting update with value {0}", entity);
            return entity;
        }
        public List<Rezervare> findByIdCursa(long idCursa)
        {
            log.InfoFormat("Entering findByIdCursa with value {0}", idCursa);
            List<Rezervare> rezervari = new List<Rezervare>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from rezervare where id_cursa=@id", connection);
                    sQLiteCommand.Parameters.AddWithValue("@id", idCursa);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idRezervare = sQLiteDataReader.GetInt32(0);
                        string numeClient = sQLiteDataReader.GetString(1);
                        int nrLocuri = sQLiteDataReader.GetInt32(2);
                        int idCursa1 = sQLiteDataReader.GetInt32(3);
                        Rezervare rezervare = new Rezervare(numeClient, nrLocuri, idCursa1);
                        rezervare.SetId(idRezervare);
                        rezervari.Add(rezervare);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findByIdCursa with value {0}", rezervari);
            return rezervari;
        }
    }
}
