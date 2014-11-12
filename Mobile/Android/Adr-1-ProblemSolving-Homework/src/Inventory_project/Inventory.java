package Inventory_project;

import java.util.ArrayList;
import java.util.List;

public class Inventory {
	List<Product> products;
	
	Inventory()
	{
		this.products = new ArrayList<Product>();
	}
	
	public void AddProduct(Product _product)
	{
		this.products.add(_product);
	}
	
	public void RemoveProduct(Product _product)
	{
		this.products.remove(_product);
	}
	
	public long SumQuantity()
	{
		long sum = 0;
		
		for (int i = 0; i < products.size(); i++)
		{
			sum += products.get(i).getQuantity();
		}
		
		return sum;
	}
	
	public float SumTotalPrice()
	{
		float totalPrice = 0;
		
		for (int i = 0; i < products.size(); i++)
		{
			totalPrice += products.get(i).getQuantity() * products.get(i).getPrice();
		}
		
		return totalPrice;
	}
}
