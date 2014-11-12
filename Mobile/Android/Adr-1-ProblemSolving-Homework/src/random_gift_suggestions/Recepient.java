package random_gift_suggestions;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Recepient {
	List<Gift> currentGifts;
	private String currentName;
	private int giftDate;
	
	Recepient()
	{
		this.currentGifts = new ArrayList<Gift>();
		this.setCurrentName("");
		this.setGiftDate(0);
	}
	
	Recepient(Gift gift, String name, int date)
	{
		this.currentGifts = new ArrayList<Gift>();
		this.currentGifts.add(gift);
		this.setCurrentName(name);
		this.setGiftDate(date);
	}

	public List<Gift> getCurrentGifts() {
		return this.currentGifts;
	}

	public void setCurrentGift(Gift currentGift) {
		this.currentGifts.add(currentGift);
	}

	public String getCurrentName() {
		return currentName;
	}

	public void setCurrentName(String currentName) {
		this.currentName = currentName;
	}

	public int getGiftDate() {
		return giftDate;
	}

	public void setGiftDate(int giftDate) {
		this.giftDate = giftDate;
	}
	
	public Gift getRandomGift()
	{
		Random random = new Random();
		return this.currentGifts.get(random.nextInt(currentGifts.size()));
	}
}
