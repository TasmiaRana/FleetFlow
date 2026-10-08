namespace OrderService.Practice;

// 1. Semi-auto property using the 'field' keyword
public class InventoryItem
{
	public string SKU { get; }

	public int Quantity
	{
		get => field;
		set
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be negative.");
			field = value; // Accesses the backing field directly
		}
	}

	public InventoryItem(string sku, int initialQuantity)
	{
		SKU = sku;
		Quantity = initialQuantity;
	}
}

// 2. Extension Member
public static class OrderExtensions
{
	public static bool IsPriority(this decimal orderAmount) => orderAmount > 500m;
}

// 3. Collection Expressions
public static class PracticeRunner
{
	public static void Run()
	{
		int[] pendingOrders = [101, 102, 103];
		int[] processedOrders = [201, 202];

		// Combining collections using spread operator (..)
		int[] allOrders = [.. pendingOrders, .. processedOrders, 301];

		Console.WriteLine($"Total tracked orders: {allOrders.Length}");

		var item = new InventoryItem("FLT-101", 20);
		item.Quantity = 35;

		decimal amount = 750m;
		Console.WriteLine($"Is priority: {amount.IsPriority()}");
	}
}