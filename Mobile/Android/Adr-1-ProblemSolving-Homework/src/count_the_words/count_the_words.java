package count_the_words;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class count_the_words {

	public static void main(String[] args) throws IOException {
		System.out.println("Enter a string:");
		
		// TODO: Uncomment if you want to use the console reader!
		//BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		//String userInput = br.readLine();
		
		String path = "C:\\testdata.txt";
		List<String> testData = Files.readAllLines(Paths.get(path), StandardCharsets.UTF_8);
		String userInput = testData.toString();
		// TODO: Used to remove the [] from the file, no idea from where.
		userInput = userInput.substring(1, userInput.length() - 1);
		
		String[] userInputSeparated = userInput.split("[\\s;.,:'!?()-]");
		
		Map<String, Integer> dictionary = new HashMap<String, Integer>();
		for (int i = 0; i < userInputSeparated.length; i++){
			if (dictionary.containsKey(userInputSeparated[i]))
			{
				//System.out.println(userInputSeparated[i] + " -> already exists!");
				Integer occurance = dictionary.get(userInputSeparated[i]);
				occurance++;
				dictionary.put(userInputSeparated[i], occurance);
			}
			else
			{
				//System.out.println(userInputSeparated[i] + " -> doesn't exist!");
				dictionary.put(userInputSeparated[i], 1);
			}
		}
		
		System.out.println("Unique word occurances are " + dictionary.size() + " as follows:");
		
		for (Map.Entry<String, Integer> entry : dictionary.entrySet()) {
		    String key = entry.getKey();
		    Integer value = entry.getValue();
		    System.out.println("'" + key + "' " + " occurances: " + value);
		}
	}
}