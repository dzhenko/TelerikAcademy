package Inventory_project;

public class Inventory_project {

	public static void main(String[] args) {
		Inventory shop = new Inventory();
		shop.AddProduct(new Product(10F, 100)); // 10*100=1000
		shop.AddProduct(new Product(1.1F, 225)); // 1.1*225=247.5
		shop.AddProduct(new Product(2.5F, 10)); // 2.5*10=25
		
		System.out.println("Total shop quantities: " + shop.SumQuantity());
		System.out.println("Total shop sales price: $" + shop.SumTotalPrice());
	}

}
