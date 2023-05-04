using System;
using System.Collections.Generic;
using TransportModel.domain;
using System.Data.SQLite;
using System.Windows.Forms;
using log4net;

namespace TransportPersistance.repository.database
{
    public class UserDataBase : UserRepoInterface
    {
        public static readonly ILog log = LogManager.GetLogger("UserDataBase");
        private string ConnectionString;
        
        public UserDataBase(string connectionString)
        {
            log.Info("Creating UserDataBase");
            ConnectionString = connectionString;
        }
        
        public User findOne(long id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            User user = null;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from user where id_user=@id", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idUser = sQLiteDataReader.GetInt32(0);
                        string username = sQLiteDataReader.GetString(1);
                        string password = sQLiteDataReader.GetString(2);
                        user = new User(username, password);
                        user.SetId(idUser);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", user);
            return user;
        }
        public IEnumerable<User> findAll()
        {
            log.InfoFormat("Entering findAll");
            List<User> users = new List<User>();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from user", connection);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idUser = sQLiteDataReader.GetInt32(0);
                        string username = sQLiteDataReader.GetString(1);
                        string password = sQLiteDataReader.GetString(2);
                        User user = new User(username, password);
                        user.SetId(idUser);
                        users.Add(user);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting findAll");
            return users;
        }
        public User save(User entity)
        {
            log.InfoFormat("Entering save with value {0}", entity);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("insert into user (username, password) values (@username, @password)", connection);
                    sQLiteCommand.Parameters.AddWithValue("@username", entity.Username);
                    sQLiteCommand.Parameters.AddWithValue("@password", entity.Password);
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
        public User delete(long id)
        {
            log.InfoFormat("Entering delete with value {0}", id);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("delete from user where id_user=@id", connection);
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
        
        public User update(User entity)
        {
            log.InfoFormat("Entering update with value {0}", entity);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("update user set username=@username, password=@password where id_user=@id", connection);
                    sQLiteCommand.Parameters.AddWithValue("@id", entity.GetId());
                    sQLiteCommand.Parameters.AddWithValue("@username", entity.Username);
                    sQLiteCommand.Parameters.AddWithValue("@password", entity.Password);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            log.InfoFormat("Exiting update with value {0}", entity);
            return null;
        }
        
        public User findByUsername(string username)
        {
            Console.WriteLine("Entering findByUsername with value {0}", username);
            User user = null;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand sQLiteCommand = new SQLiteCommand("select * from user where username=@username", connection);
                    sQLiteCommand.Parameters.AddWithValue("@username", username);
                    SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                    while (sQLiteDataReader.Read())
                    {
                        int idUser = sQLiteDataReader.GetInt32(0);
                        string username1 = sQLiteDataReader.GetString(1);
                        string password = sQLiteDataReader.GetString(2);
                        user = new User(username1, password);
                        user.SetId(idUser);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            Console.WriteLine("Exiting findByUsername with value {0}", user);
            return user;
        }
    }
}
