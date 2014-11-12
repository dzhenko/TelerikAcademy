package random_gift_suggestions;

public class Gift {
	private String currentName;
	private Float currentPrice;
	
	Gift()
	{
		this.currentName = "";
		this.currentPrice = 0F;
	}
	
	Gift(String name, Float price)
	{
		this.setName(name);
		this.setPrice(price);
	}
	
	public String getName() {
		return currentName;
	}
	
	public void setName(String name) {
		this.currentName = name;
	}
	
	public Float getPrice() {
		return currentPrice;
	}
	
	public void setPrice(Float price) {
		this.currentPrice = price;
	}
}