package Horoscope;

import java.io.IOException;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.select.Elements;

public class horoscope {

	public static void main(String[] args) throws IOException {
		Document general = Jsoup.connect("http://www.stardm.com/daily-horoscopes/A1-daily-horoscopes.asp").get();
		Elements signs = general.select("html body div#container div#contentcontainer div#content div.post div.entry h4");
		Elements signForecastGeneral = general.select("html body div#container div#contentcontainer div#content div.post div.entry p");
		Document love = Jsoup.connect("http://www.stardm.com/daily-horoscopes/c1-daily-love-horoscopes.asp").get();
		Elements signForecastLove = love.select("html body div#container div#contentcontainer div#content div.post div.entry p");
		Document money = Jsoup.connect("http://www.stardm.com/daily-horoscopes/d1-daily-money-horoscopes.asp").get();
		Elements signForecastMoney = money.select("html body div#container div#contentcontainer div#content div.post div.entry p");
		signForecastGeneral.remove(0);
		signForecastGeneral.remove(0);
		signForecastMoney.remove(0);
		
		System.out.println("Today's forecast:");
		System.out.println();
		
		for	(int i = 0; i < signs.size(); i++)
		{
			System.out.println(i + ") " + signs.get(i).toString().substring(4, signs.get(i).toString().length() - 6));
			System.out.println("General: " + ": " + signForecastGeneral.get(i).toString().substring(3, signForecastGeneral.get(i).toString().length() - 5));
			System.out.println("Love: " + ": " + signForecastLove.get(i).toString().substring(3, signForecastLove.get(i).toString().length() - 5));
			System.out.println("Money: " + ": " + signForecastMoney.get(i).toString().substring(3, signForecastMoney.get(i).toString().length() - 5));
			System.out.println();
		}
	}
}
