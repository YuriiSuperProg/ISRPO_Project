public class Pastry {
    private string _name = "Безымянная выпечка";

    public string Name {
        get {
            return _name;
        }

        private set {
            if (string.IsNullOrWhiteSpace(value)) {
                _name = "Безымянная выпечка";
                return;
            }

            _name = value.Trim();
        }
    }

    public int Price { get; private set; }
    public int MaxPrice { get; private set; }
    public int Stock { get; private set; }
    public bool IsFresh { get; private set; }

    public Pastry(string name, int price, int stock) {
        Name = name;

        MaxPrice = price;
        if (MaxPrice <= 0) {
            MaxPrice = 100;
        }
        if (MaxPrice > 1000) {
            MaxPrice = 1000;
        }

        Price = price;
        if (Price < 0) {
            Price = 0;
        }
        if (Price > MaxPrice) {
            Price = MaxPrice;
        }

        Stock = stock;
        if (Stock < 0) {
            Stock = 0;
        }

        IsFresh = true;
    }

    public void Bake(int amount) {
        if (amount <= 0) {
            return;
        }

        Stock += amount;
        IsFresh = true;
    }

    public void Sell(int amount) {
        if (amount <= 0) {
            return;
        }
        if (amount > Stock) {
            return;
        }

        Stock -= amount;
        if (Stock == 0) {
            IsFresh = false;
        }
    }

    public void ChangePrice(int newPrice) {
        if (newPrice < 0) {
            return;
        }
        if (newPrice > MaxPrice) {
            return;
        }

        Price = newPrice;
    }

    public bool IsSoldOut() {
        return Stock == 0;
    }

    public string GetInfo() {
        return $">>> {Name} <<<\n" +
               $"Цена: {Price}/{MaxPrice}\n" +
               $"Остаток: {Stock}\n" +
               $"Свежая: {IsFresh}";
    }
}