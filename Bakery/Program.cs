Bakery bakery = new Bakery("   Сладкий уголок   ");

Pastry croissant = new Pastry("   Круассан   ", 150, 10);
Pastry eclair = new Pastry("Эклер", 120, 5);
Pastry empty = new Pastry("   ", -50, -3);

Console.WriteLine($">>> {bakery.Name}: выпечки {bakery.Count} <<<");
Console.WriteLine();

Console.WriteLine(bakery.AddPastry(croissant));
Console.WriteLine(bakery.AddPastry(eclair));
Console.WriteLine(bakery.AddPastry(empty));
Console.WriteLine(bakery.AddPastry(croissant));

Console.WriteLine($"Выпечки: {bakery.Count}");
Console.WriteLine();

croissant.Sell(3);
croissant.Bake(5);
croissant.ChangePrice(200);

eclair.Sell(5);

Console.WriteLine($"Круассан: остаток {croissant.Stock}, цена {croissant.Price}");
Console.WriteLine($"Эклер продан полностью: {eclair.IsSoldOut()}");
Console.WriteLine($"Закончилось: {bakery.CountSoldOut()}");
Console.WriteLine();

Pastry? found = bakery.FindByName("  эклер ");
if (found != null) {
    Console.WriteLine($"Найдено: {found.Name}");
} else {
    Console.WriteLine("Не найдено");
}

Console.WriteLine($"Удалён отсутствующий: {bakery.RemoveByName("Торт")}");
Console.WriteLine($"Выпечки после проверок: {bakery.Count}");
Console.WriteLine();

List<Pastry> all = bakery.GetPastries();
foreach (Pastry pastry in all) {
    Console.WriteLine(pastry.GetInfo());
    Console.WriteLine();
}