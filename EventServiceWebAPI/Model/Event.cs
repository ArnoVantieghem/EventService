namespace EventServiceWebAPI.Model
{
    public class Event
    {
        public Event(string naam, string locatie, DateTime datum, int maximumBezoekers)
        {
            Naam = naam;
            Locatie = locatie;
            Datum = datum;
            MaximumBezoekers = maximumBezoekers;
            IngeschrevenBezoekers = null;
        }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public int MaximumBezoekers { get; set; }
        public List<Bezoeker> IngeschrevenBezoekers = new List<Bezoeker>(); // aangezien het aantal bezoekers niet zo groot is kan je dit in een lijst opslaan in event, als je met grote aantallen zit ga je gebruik maken van managers
    }
}