public class Bakery {
    private List<Pastry> _pastries = new List<Pastry>();

    public string Name { get; private set; }

    public int Count {
        get {
            return _pastries.Count;
        }
    }

    public Bakery(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            Name = "Безымянная пекарня";
        } else {
            Name = name.Trim();
        }
    }

    public bool AddPastry(Pastry pastry) {
        if (pastry == null) {
            return false;
        }
        if (FindByName(pastry.Name) != null) {
            return false;
        }
        _pastries.Add(pastry);
        return true;
    }

    public Pastry? FindByName(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            return null;
        }

        string search = name.Trim().ToLower();

        foreach (Pastry pastry in _pastries) {
            if (pastry.Name.ToLower() == search) {
                return pastry;
            }
        }

        return null;
    }

    public bool RemoveByName(string name) {
        Pastry? pastry = FindByName(name);
        if (pastry == null) {
            return false;
        }
        return _pastries.Remove(pastry);
    }

    public int CountSoldOut() {
        int count = 0;
        foreach (Pastry pastry in _pastries) {
            if (pastry.IsSoldOut()) {
                count++;
            }
        }
        return count;
    }

    public List<Pastry> GetPastries() {
        return new List<Pastry>(_pastries);
    }
}