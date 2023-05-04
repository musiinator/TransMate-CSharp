using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportModel.domain;
using TransportPersistance.repository;
using TransportPersistance.repository.Interfaces;
using TransportService;

namespace TransportClientFX
{
    public partial class MenuForm : Form
    {
        private readonly TransportClientController controller;
        private User loggedUser;
        private Cursa cursaGasita;
        private IList<Cursa> cursaData;
        private BindingList<Cursa> curseBindingList;
        public MenuForm(TransportClientController controller, User loggedUser)
        {
            InitializeComponent();
            this.controller = controller;
            this.loggedUser = loggedUser;
            usernameText.Text = loggedUser.Username;
            initializeCurseGridView();
            controller.updateEvent += userUpdate;
        }
        
        public void userUpdate(object sender, UserEventArgs e)
        {
            curseGridView.Invoke((Action)delegate
            {
                if (e.UserEventType == UserEvent.RezervareReceived)
                {
                    curseGridView.BeginInvoke((Action) delegate
                    {
                        cursaData.Clear();
                        List<Cursa> curse = controller.getAllCurse().ToList();
                        foreach (Cursa cursa in curse)
                        {
                            cursaData.Add(cursa);
                        }
                        curseBindingList.ResetBindings();
                        curseGridView.DataSource = curseBindingList;
                    });
                }
            });
        }

        private void initializeCurseGridView(){
            try
            {
                List<Cursa> curse = controller.getAllCurse().ToList();
                cursaData = curse;
                curseBindingList = new BindingList<Cursa>(cursaData);
                curseGridView.DataSource = curseBindingList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            oraComboBox.DataSource = new List<string>() { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"};
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.logout(loggedUser);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Logout Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
        
        private void curseGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(curseGridView.SelectedRows.Count > 0)
            {
                destinatieText.Text = curseGridView.SelectedRows[0].Cells[0].Value.ToString();
                string datetime = curseGridView.SelectedRows[0].Cells[1].Value.ToString();
                locuriDisponibileText.Text = curseGridView.SelectedRows[0].Cells[2].Value.ToString();
                string[] date = datetime.Split(' ');
                DateTime selectedDate = DateTime.ParseExact(date[0], "dd.MM.yyyy", null);
                dateTimePicker1.Value = selectedDate;
                string[] time = date[1].Split(':');
                oraComboBox.SelectedIndex = int.Parse(time[0]);
                DateTime dateFromPicker = dateTimePicker1.Value.Date;
                TimeSpan timeFromComboBox = TimeSpan.Parse(oraComboBox.SelectedItem.ToString());
                DateTime dateTimeFromPickerAndComboBox = dateFromPicker + timeFromComboBox;
                cursaGasita = null;
                foreach (Cursa cursa in controller.getAllCurse())
                {
                    if (cursa.DataOraPlecare.Equals(dateTimeFromPickerAndComboBox) && cursa.Destinatie.Equals(destinatieText.Text) && cursa.NrLocuriDisponibile == int.Parse(locuriDisponibileText.Text))
                    {
                        cursaGasita = cursa;
                        break;
                    }
                }
            }
        }

        private List<RezervareDTO> populareRezervari()
        {
            List<RezervareDTO> rezervari = new List<RezervareDTO>();
            int i = 0;
            int ultimulLoc = 0;
            if (cursaGasita != null)
            {
                foreach (Rezervare rezervare in controller.getRezervariByIdCursa(cursaGasita.GetId()))
                {
                    if (rezervare.IdCursa == cursaGasita.GetId())
                    {
                        for (i = ultimulLoc+1; i <= ultimulLoc + rezervare.NrLocuri; i++)
                        {
                            RezervareDTO rezervareDTO = new RezervareDTO(rezervare.NumeClient, i);
                            rezervari.Add(rezervareDTO);
                        }
                        ultimulLoc = i-1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Cursa nu a fost gasita!", "Cursa negasita", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return rezervari;
        }

        private void cautareButton_Click(object sender, EventArgs e)
        {
            DateTime dateFromPicker = dateTimePicker1.Value.Date;
            TimeSpan timeFromComboBox = TimeSpan.Parse(oraComboBox.SelectedItem.ToString());
            DateTime dateTimeFromPickerAndComboBox = dateFromPicker + timeFromComboBox;
            cursaGasita = null;
            foreach (Cursa cursa in controller.getAllCurse())
            {
                if (cursa.DataOraPlecare.Equals(dateTimeFromPickerAndComboBox) && cursa.Destinatie.Equals(destinatieText.Text) && cursa.NrLocuriDisponibile == int.Parse(locuriDisponibileText.Text))
                {
                    cursaGasita = cursa;
                    break;
                }
            }
            List<RezervareDTO> rezervari = populareRezervari();
            rezervariGridView.DataSource = rezervari;
        }

        private void rezervariGridView_SelectionChanged(Object sender, EventArgs e)
        {
            if(rezervariGridView.SelectedRows.Count > 0)
            {
                numeClientText.Text = rezervariGridView.SelectedRows[0].Cells[0].Value.ToString();
                numarLocuriText.Text = rezervariGridView.SelectedRows[0].Cells[1].Value.ToString();

            }
        }

        private void adaugareButton_Click(object sender, EventArgs e)
        {
            List<RezervareDTO> rezervari = populareRezervari();
            int ultimulLoc = 0;
            if (rezervari.Count > 0)
            {
                ultimulLoc = rezervari[rezervari.Count - 1].NrLoc;
            }
            int locuriDisponibile = int.Parse(locuriDisponibileText.Text);
            int numarLocuri = int.Parse(numarLocuriText.Text);
            if (locuriDisponibile - numarLocuri < 0)
            {
                MessageBox.Show("Nu sunt suficiente locuri disponibile!");
            }
            else
            {
                Rezervare rezervare = new Rezervare(numeClientText.Text, int.Parse(numarLocuriText.Text), cursaGasita.GetId());
                cursaGasita.NrLocuriDisponibile -= rezervare.NrLocuri;
                controller.updateCursa(cursaGasita);
                controller.saveRezervare(rezervare);
                locuriDisponibileText.Text = cursaGasita.NrLocuriDisponibile.ToString();
                for (int i = ultimulLoc + 1; i <= ultimulLoc + rezervare.NrLocuri; i++)
                {
                    RezervareDTO rezervareDTO = new RezervareDTO(rezervare.NumeClient, i);
                    rezervari.Add(rezervareDTO);
                }

                rezervariGridView.DataSource = rezervari;
            }
        }
    }
}
