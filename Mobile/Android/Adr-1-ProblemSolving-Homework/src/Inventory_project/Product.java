package Inventory_project;

import java.util.UUID;

public class Product {
	private java.lang.Long id;
	private float price;
	private int quantity;
	
	Product()
	{
		this.id = UUID.randomUUID().getMostSignificantBits();
	}
	
	Product(float _price)
	{
		if (this.id == null)
		{
			this.id = UUID.randomUUID().getMostSignificantBits();
		}
		
		if (_price < 0)
		{
			throw new IllegalArgumentException("Price cannot be less than 0!");
		}
		
		this.price = _price;
	}
	
	Product(int _quantity)
	{
		if (this.id == null)
		{
			this.id = UUID.randomUUID().getMostSignificantBits();
		}
		
		if (_quantity < 0)
		{
			throw new IllegalArgumentException("Quantity cannot be less than 0!");
		}
		
		this.quantity = _quantity;
	}
	
	Product(float _price, int _quantity)
	{
		if (this.id == null)
		{
			this.id = UUID.randomUUID().getMostSignificantBits();
		}
		
		if (_price < 0)
		{
			throw new IllegalArgumentException("Price cannot be less than 0!");
		}
		
		if (_quantity < 0)
		{
			throw new IllegalArgumentException("Quantity cannot be less than 0!");
		}
		
		this.price = _price;
		this.quantity = _quantity;
	}
	
	public long getId() {
		return id;
	}
		
	public float getPrice() {
		return price;
	}
	
	public void setPrice(float price) {
		if (price < 0)
		{
			throw new IllegalArgumentException("Price cannot be less than 0!");
		}
		
		this.price = price;
	}
	
	public int getQuantity() {
		return quantity;
	}
	
	public void setQuantity(int quantity) {
		if (quantity < 0)
		{
			throw new IllegalArgumentException("Quantity cannot be less than 0!");
		}
		
		this.quantity = quantity;
	}
}
