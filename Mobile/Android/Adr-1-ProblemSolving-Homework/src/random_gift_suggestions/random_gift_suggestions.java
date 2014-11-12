package random_gift_suggestions;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class random_gift_suggestions {
	
	public static void main(String[] args) {
		Calendar calendar = Calendar.getInstance();
		List<Recepient> recepients = new ArrayList<Recepient>();
			
		Recepient newRecepient = new Recepient(new Gift("Roses", 10F), "Margaritta", calendar.DATE);
		newRecepient.setCurrentGift(new Gift("Wine", 15F));
		newRecepient.setCurrentGift(new Gift("Champagne", 25F));
		recepients.add(newRecepient);
		
		newRecepient = new Recepient(new Gift("Lego", 100F), "Andrew", calendar.DATE + 20);
		newRecepient.setCurrentGift(new Gift("Tablet", 215F));
		recepients.add(newRecepient);
			
		newRecepient = new Recepient(new Gift("Beer", 5F), "Peter", calendar.DATE + 10);
		newRecepient.setCurrentGift(new Gift("Whiskey", 10F));
		newRecepient.setCurrentGift(new Gift("Gym card", 23.5F));
		newRecepient.setCurrentGift(new Gift("Java masterclass tuition", 1200F));
		recepients.add(newRecepient);
		
		for (int i = 0; i < recepients.size(); i++)
		{
			Recepient recepient = recepients.get(i);
			Gift gift = recepient.getRandomGift();
			System.out.println(recepient.getCurrentName() + ": " + gift.getName() + ", price $" + gift.getPrice());
		}
	}
}
