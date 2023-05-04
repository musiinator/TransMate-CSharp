using System;

namespace TransportModel.domain
{
    [Serializable]
    public class CursaDTO
    {
        private long id;
        private string destinatie;
        private DateTime dataOraPlecare;
        private int nrLocuriDisponibile;

        public CursaDTO(long id, string destinatie, DateTime dataOraPlecare, int nrLocuriDisponibile)
        {
            this.id = id;
            this.destinatie = destinatie;
            this.dataOraPlecare = dataOraPlecare;
            this.nrLocuriDisponibile = nrLocuriDisponibile;
        }
        
        public long Id
        {
            get { return id; }
            set { id = value; }
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
            CursaDTO cursa = (CursaDTO)obj;
            return id == cursa.id && destinatie == cursa.destinatie && dataOraPlecare == cursa.dataOraPlecare && nrLocuriDisponibile == cursa.nrLocuriDisponibile;
        }
        
        public override string ToString()
        {
            return "Cursa{" +
                   "id=" + id +
                   ", destinatie='" + destinatie + '\'' +
                   ", dataOraPlecare=" + dataOraPlecare +
                   ", nrLocuriDisponibile=" + nrLocuriDisponibile +
                   '}';
        }
    }   
    
}