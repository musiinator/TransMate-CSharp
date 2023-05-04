using System;

namespace TransportModel.domain
{
    [Serializable]
    public class Rezervare : Entity<long>
    {
        private string numeClient;
        private int nrLocuri;
        private long idCursa;

        public Rezervare(string numeClient, int nrLocuri, long idCursa)
        {
            this.numeClient = numeClient;
            this.nrLocuri = nrLocuri;
            this.idCursa = idCursa;
        }

        public string NumeClient
        {
            get { return numeClient; }
            set { numeClient = value; }
        }

        public int NrLocuri
        {
            get { return nrLocuri; }
            set { nrLocuri = value; }
        }

        public long IdCursa
        {
            get { return idCursa; }
            set { idCursa = value; }
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Rezervare rezervare = (Rezervare)o;
            return numeClient == rezervare.numeClient &&
                   nrLocuri == rezervare.nrLocuri && idCursa == rezervare.idCursa;
        }

        public override string ToString()
        {
            return "Rezervare{" +
                "numeClient='" + numeClient + '\'' +
                ", nrLocuri=" + nrLocuri +
                ", idCursa=" + idCursa;
        }
    }
}
