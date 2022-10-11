namespace EventServiceBL.Model
{
    public class Bezoeker
    {
        public Bezoeker() { }
        public Bezoeker(string naam, DateTime geboortedatum)
        {
            SetNaam(naam);
            GeboorteDatum = geboortedatum;
        }
        public Bezoeker(int id, string naam, DateTime geboortedatum) : this(naam,geboortedatum)
        {
            SetId(id);
        }
       

        public int Id { get; private set; }
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Bezoeker bezoeker &&
                   Id == bezoeker.Id;
        }

        public bool IsDifferent(Bezoeker bezoeker)
        {
            if (!Naam.Equals(bezoeker.Naam)) return true;
            if (!GeboorteDatum.Equals(bezoeker.GeboorteDatum)) return true;
            if (!Id.Equals(bezoeker.Id)) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void SetId(int id)
        {
            if(id<=0) throw new BezoekerException("Bezoeker - SetId");
            Id = id;
        }

        public void SetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new BezoekerException("Bezoeker - SetNaam");
            Naam = naam;
        }
    }
}
