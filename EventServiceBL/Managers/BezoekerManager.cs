using EventServiceBL.Model;

namespace EventServiceBL.Managers
{
    public class BezoekerManager
    {
        private int id = 0;
        private Dictionary<int, Bezoeker> _bezoekers = new Dictionary<int,Bezoeker>();

        public BezoekerManager()
        {
            _bezoekers.Add(0, new Bezoeker("Arno",DateTime.Now));
            _bezoekers.Add(1, new Bezoeker("Peter",DateTime.MinValue));
        }
        public Bezoeker RegistreerBezoeker(Bezoeker bezoeker)
        {
            id++;
            bezoeker.SetId(id);
            return bezoeker;
        }
        public void RegistreerNaarLijst(Bezoeker bezoeker)
        {
            if (bezoeker == null) throw new BezoekerException("BezoekerManager - RegistreerNaarLijst1");
            if (bezoeker.Id == 0) throw new BezoekerException("BezoekerManager - RegistreerNaarLijst2");
            if (_bezoekers.ContainsKey(bezoeker.Id)) throw new BezoekerException("BezoekerManager - RegistreerNaarLijst3");
            _bezoekers.Add(bezoeker.Id, bezoeker);
        }
        public void VerwijderVanLijst(Bezoeker bezoeker)
        {
            if (bezoeker == null) throw new BezoekerException("BezoekerManager - VerwijderVanLijst1");
            if (bezoeker.Id == 0) throw new BezoekerException("BezoekerManager - VerwijderVanLijst2");
            if (!_bezoekers.ContainsKey(bezoeker.Id)) throw new BezoekerException("BezoekerManager - VerwijderVanLijst3");
            _bezoekers.Remove(bezoeker.Id);
        }
        public IReadOnlyList<Bezoeker> GeefAlleBezoerks()
        {
            return _bezoekers.Values.ToList().AsReadOnly();
        }
        public Bezoeker GeefBezoeker(int id)
        {
            if (!_bezoekers.ContainsKey(id)) throw new BezoekerException("BezoekerManager - GeefBezoeker");
            return _bezoekers[id];
        }
        public void UpdateBezoeker(Bezoeker bezoeker)
        {

            if (bezoeker == null) throw new BezoekerException("BezoekerManager - UpdateBezoeker1");
            if (bezoeker.Id == 0) throw new BezoekerException("BezoekerManager - UpdateBezoeker2");
            if (!_bezoekers.ContainsKey(bezoeker.Id)) throw new BezoekerException("BezoekerManager - UpdateBezoeker3");
            if (!_bezoekers[bezoeker.Id].IsDifferent(bezoeker)) throw new BezoekerException("BezoekerManager - UpdateBezoeker4");
            _bezoekers[bezoeker.Id] = bezoeker;
        }
    }
}
