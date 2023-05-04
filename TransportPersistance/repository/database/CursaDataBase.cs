using System;
using System.Collections.Generic;
using TransportModel.domain;
using System.Data.SQLite;
using System.Windows.Forms;
using TransportPersistance.repository.Interfaces;
using log4net;

namespace TransportPersistance.repository.database
{

    public class CursaDataBase : CursaRepoInterface
    {

        public static readonly ILog log = LogManager.GetLogger("CursaDataBase");
        private string ConnectionString;
        
        public CursaDataBase(string connectionString)
        {
            log.Info("Creating CursaDataBase");
            ConnectionString = connectionString;
        }
        
        public Cursa findOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            Cursa cursa = null;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from cursa where id_cursa=@id", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idCursa = sQLiteDataReader.GetInt32(0);
                        string destinatie = sQLiteDataReader.GetString(1);
                        string dataOraPlecare = sQLiteDataReader.GetString(2);
                        int nrLocuri = sQLiteDataReader.GetInt32(3);
                        cursa = new Cursa(destinatie, DateTime.Parse(dataOraPlecare), nrLocuri);
                        cursa.SetId(idCursa);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", cursa);
            return cursa;
        }
        public IEnumerable<Cursa> findAll()
        {
            log.Info("Entering FindAll");
            List<Cursa> curse = new List<Cursa>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from cursa", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idCursa = sQLiteDataReader.GetInt32(0);
                        string destinatie = sQLiteDataReader.GetString(1);
                        string dataOraPlecare = sQLiteDataReader.GetString(2);
                        int nrLocuri = sQLiteDataReader.GetInt32(3);
                        Cursa cursa = new Cursa(destinatie, DateTime.Parse(dataOraPlecare), nrLocuri);
                        cursa.SetId(idCursa);
                        curse.Add(cursa);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.Info("Exiting FindAll");
            return curse;
        }
        public Cursa save(Cursa entity)
        {
            log.InfoFormat("Entering save with value {0}", entity);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("insert into cursa (destinatie, data_ora_plecare, nr_locuri_disponibile) values (@destinatie, @dataOraPlecare, @nrLocuri)", connection);
                    sQLiteCommand.Parameters.AddWithValue("@destinatie", entity.Destinatie);
                    sQLiteCommand.Parameters.AddWithValue("@dataOraPlecare", entity.DataOraPlecare);
                    sQLiteCommand.Parameters.AddWithValue("@nrLocuri", entity.NrLocuriDisponibile);
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
        public Cursa delete(long id)
        {
            log.InfoFormat("Entering delete with value {0}", id);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("delete from cursa where id_cursa=@id", connection);
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
        public Cursa update(Cursa entity)
        {
            log.InfoFormat("Entering update with value {0}", entity);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("update cursa set destinatie=@destinatie, data_ora_plecare=@dataOraPlecare, nr_locuri_disponibile=@nrLocuri where id_cursa=@id", connection);
                    sQLiteCommand.Parameters.AddWithValue("@destinatie", entity.Destinatie);
                    sQLiteCommand.Parameters.AddWithValue("@dataOraPlecare", entity.DataOraPlecare);
                    sQLiteCommand.Parameters.AddWithValue("@nrLocuri", entity.NrLocuriDisponibile);
                    sQLiteCommand.Parameters.AddWithValue("@id", entity.GetId());
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
        
        public List<Cursa> findByDestinatie(string destinatie)
        {
            List<Cursa> curse = new List<Cursa>();
            log.InfoFormat("Entering findByDestinatie with value {0}", destinatie);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from cursa where destinatie=@destinatie", connection);
                    sQLiteCommand.Parameters.AddWithValue("@destinatie", destinatie);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idCursa = sQLiteDataReader.GetInt32(0);
                        string destinatieCursa = sQLiteDataReader.GetString(1);
                        string dataOraPlecare = sQLiteDataReader.GetString(2);
                        int nrLocuri = sQLiteDataReader.GetInt32(3);
                        Cursa cursa = new Cursa(destinatieCursa, DateTime.Parse(dataOraPlecare), nrLocuri);
                        cursa.SetId(idCursa);
                        curse.Add(cursa);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findByDestinatie with value {0}", curse);
            return curse;
        }
        
        public List<Cursa> findByDataOraPlecare(string dataOraPlecare)
        {
            List<Cursa> curse = new List<Cursa>();
            log.InfoFormat("Entering findByDataOraPlecare with value {0}", dataOraPlecare);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from cursa where data_ora_plecare=@dataOraPlecare", connection);
                    sQLiteCommand.Parameters.AddWithValue("@dataOraPlecare", dataOraPlecare);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idCursa = sQLiteDataReader.GetInt32(0);
                        string destinatieCursa = sQLiteDataReader.GetString(1);
                        string dataOraPlecareCursa = sQLiteDataReader.GetString(2);
                        int nrLocuri = sQLiteDataReader.GetInt32(3);
                        Cursa cursa = new Cursa(destinatieCursa, DateTime.Parse(dataOraPlecareCursa), nrLocuri);
                        cursa.SetId(idCursa);
                        curse.Add(cursa);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findByDataOraPlecare with value {0}", curse);
            return curse;
        }
    }
}
