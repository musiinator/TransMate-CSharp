using System;


namespace TransportModel.domain
{
    [Serializable]
    public class Cursa : Entity<long>
    {
        private string destinatie;
        private DateTime dataOraPlecare;
        private int nrLocuriDisponibile;

        public Cursa(string destinatie, DateTime dataOraPlecare, int nrLocuriDisponibile)
        {
            this.destinatie = destinatie;
            this.dataOraPlecare = dataOraPlecare;
            this.nrLocuriDisponibile = nrLocuriDisponibile;
        }

        public string Destinatie
        {
            get { return destinatie; }
            set { destinatie = value; }
        }

        public DateTime DataOraPlecare
        {
            get { return dataOraPlecare; }
            set { dataOraPlecare = value; }
        }

        public int NrLocuriDisponibile
        {
            get { return nrLocuriDisponibile; }
            set { nrLocuriDisponibile = value; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Cursa cursa = (Cursa)obj;
            return destinatie == cursa.destinatie && dataOraPlecare == cursa.dataOraPlecare && nrLocuriDisponibile == cursa.nrLocuriDisponibile;
        }

        public override string ToString()
        {
            return "Cursa{" +
                   "destinatie='" + destinatie + '\'' +
                   ", dataOraPlecare=" + dataOraPlecare +
                   ", nrLocuriDisponibile=" + nrLocuriDisponibile +
                   '}';
        }
    }
}
