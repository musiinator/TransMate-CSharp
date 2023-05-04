using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportModel.domain;
using TransportPersistance.repository.database;
using TransportPersistance.repository.Interfaces;
using log4net;
using TransportNetworking;
using TransportPersistance.repository;
using TransportServer;
using TransportService;

namespace TransportClientFX
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [STAThread]
        

        public static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TransportServiceInterface server = new TransportServerObjectProxy("127.0.0.1", 55555);
            TransportClientController controller = new TransportClientController(server);
            LoginForm loginForm = new LoginForm(controller);
            Application.Run(loginForm);
        }

    }
}