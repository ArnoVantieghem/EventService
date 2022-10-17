namespace EventServiceBL.Model
{
    public class Event
    {
        public Event(string naam, string locatie, DateTime datum, int maximumBezoekers)
        {
            SetNaam(naam);
            SetLocatie(locatie);
            Datum = datum;
            SetMaximumBezoekers(maximumBezoekers);
        }
        public string Naam { get; private set; }
        public string Locatie { get; private set; }
        public DateTime Datum { get; set; }
        public int MaximumBezoekers { get; private set; }

        private List<Bezoeker> _IngeschrevenBezoekers = new(); // aangezien het aantal bezoekers niet zo groot is kan je dit in een lijst opslaan in event, als je met grote aantallen zit ga je gebruik maken van managers
        public IReadOnlyList<Bezoeker> _ReadOnlyBezoekers => _IngeschrevenBezoekers.AsReadOnly();
        public void SetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new EventException("Event - SetNaam");
            Naam = naam;
        }
        public void SetLocatie(string locatie)
        {
            if (string.IsNullOrWhiteSpace(locatie)) throw new EventException("Event - SetLocatie");
            Locatie = locatie;
        }
        public void SetMaximumBezoekers(int maximumBezoekers)
        {
            if (maximumBezoekers <= 0) throw new EventException("Event - SetMaximumBezoekers");
            MaximumBezoekers = maximumBezoekers;
        }

        public void VoegBezoekerToe(Bezoeker bezoeker)
        {
            if (bezoeker == null) throw new EventException("Event - VoegBezoekerToe1");
            if (_IngeschrevenBezoekers.Count == MaximumBezoekers) throw new EventException("Event - VoegBezoekerToe2");
            if (_IngeschrevenBezoekers.Contains(bezoeker)) throw new EventException("Event - VoegBezoekerToe3");
            _IngeschrevenBezoekers.Add(bezoeker);
        }

        public void VerwijderBezoeker(Bezoeker bezoeker)
        {
            if (bezoeker == null) throw new EventException("Event - VerwijderBezoeker1");
            if (!_IngeschrevenBezoekers.Contains(bezoeker)) throw new EventException("Event - VerwijderBezoeker2");
            _IngeschrevenBezoekers.Remove(bezoeker);
        }
    }
}