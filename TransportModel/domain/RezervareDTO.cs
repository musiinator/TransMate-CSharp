using System;

namespace TransportModel.domain
{
    [Serializable]
    public class RezervareDTO
    {
        private string numeClient;
        private int nrLoc;

        public RezervareDTO(string numeClient, int nrLoc)
        {
            this.numeClient = numeClient;
            this.nrLoc = nrLoc;
        }

        public string NumeClient
        {
            get { return numeClient; }
            set { numeClient = value; }
        }

        public int NrLoc
        {
            get { return nrLoc; }
            set { nrLoc = value; }
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            RezervareDTO rezervare = (RezervareDTO)o;
            return numeClient == rezervare.numeClient &&
                   nrLoc == rezervare.nrLoc;
        }

    }
}
