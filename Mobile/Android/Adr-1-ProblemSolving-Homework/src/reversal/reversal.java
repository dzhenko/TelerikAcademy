package reversal;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.StringBuilder;

public class reversal {

	public static void main(String args[]) throws IOException {
		System.out.println("Enter a string:");
		
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		String userInput = br.readLine();
		
		System.out.println("Original: " + userInput);
		
		StringBuilder sb = new StringBuilder();
		
		for (int i = userInput.length() - 1; i >= 0 ; i--)
		{
			//System.out.println(userInput.charAt(i));
			sb.append(userInput.charAt(i));
		}
		
		System.out.println("Reversed: " + sb.toString());
	}
}
