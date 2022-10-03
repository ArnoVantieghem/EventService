namespace EventServiceWebAPI.Model
{
    public class Bezoeker
    {
        public Bezoeker(int id, string naam, DateOnly geboortedatum)
        {
            Id = id;
            Naam = naam;
            GeboorteDatum = geboortedatum;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public DateOnly GeboorteDatum { get; set; }
    }
}
