package com.example.androidfragment;

public class Product {
	private String name;
	private String category;
	
	public Product(String name, String category){
		this.setName(name);
		this.setCategory(category);
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getCategory() {
		return category;
	}
	
	public void setCategory(String category) {
		this.category = category;
	}
}
