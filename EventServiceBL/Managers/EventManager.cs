using EventServiceBL.Model;

namespace EventServiceBL.Managers
{
    public class EventManager
    {
        private Dictionary<string,Event> _events = new Dictionary<string, Event>();

        public void VoegEventToe(Event ev)
        {
            if (ev == null) throw new EventException("Eventmanager - VoegEventToe1");
            if (_events.ContainsKey(ev.Naam)) throw new EventException("EventManager - VoegEventToe2");
            _events.Add(ev.Naam, ev);
        }
        public void VerwijderEvent(Event ev)
        {
            if (ev == null) throw new EventException("Eventmanager - VerwijderEvent1");
            if (!_events.ContainsKey(ev.Naam)) throw new EventException("EventManager - VerwijderEvent2");
            _events.Remove(ev.Naam);
        }
        public void UpdateEvent(Event ev)
        {
            if (ev == null) throw new EventException("Eventmanager - UpdateEvent1");
            if (!_events.ContainsKey(ev.Naam)) throw new EventException("EventManager - UpdateEvent2");
            // TODO checken ofdat nieuwe event niet identitiek is als bestaande
            _events[ev.Naam] = ev;
        }
        public IReadOnlyList<Event> GetEvents()
        {
            return _events.Values.ToList().AsReadOnly();
        }
        public IReadOnlyList<Event> GetEventOpLocatie(string locatie)
        {
            return _events.Values.Where(e=> e.Locatie.Equals(locatie)).ToList();
        }
        public IReadOnlyList<Event> GetEventOpDatum(DateTime datum)
        {
            return _events.Values.Where(e => e.Datum.Date == datum.Date).ToList();
        }
        public void RegistreerBezoeker(Bezoeker bezoeker, Event ev)
        {
            if (bezoeker == null || ev == null) throw new EventException("EventManager - RegistreerBezoeker1");
            if (!_events.ContainsKey(ev.Naam)) throw new EventException("EventManager - RegistreerBezoeker2");
            try
            {
                _events[ev.Naam].VoegBezoekerToe(bezoeker);
            } catch (Exception ex)
            {
                throw new EventException("EventManager - RegistreerBezoekerTryCatch");
            }
        }
        public void VerwijderBezoeker(Bezoeker bezoeker, Event ev)
        {
            if (bezoeker == null || ev == null) throw new EventException("EventManager - VerwijderBezoeker1");
            if (_events.ContainsKey(ev.Naam)) throw new EventException("EventManager - VerwijderBezoeker2");
            try
            {
                _events[ev.Naam].VerwijderBezoeker(bezoeker);
            }
            catch (Exception ex)
            {
                throw new EventException("EventManager - VerwijderBezoekerTryCatch");
            }
        }
    }
}