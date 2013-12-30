//Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) 
//operation over the first letter of the string with the first of the key, the second – with the second, etc. 
//When the last key character is reached, the next is the first.

using System;
using System.Text;

class EncodingDecodingString
{
    static void Main()
    {
        Console.WriteLine("Enter the message to encode/decode : ");
        string message = Console.ReadLine();
        Console.WriteLine("Enter the encrypting key : ");
        string key = Console.ReadLine();
        //string message = "If you like making more cupcakes I would love to have a dozen or two";
        //string key = "please";

        StringBuilder Encryption = EnDeCrypt(message, key);

        Console.WriteLine(Encryption);

        string newInput = Encryption.ToString();

        StringBuilder Decryption = EnDeCrypt(newInput, key);
        Console.WriteLine(Decryption); // it actually works ... cant believe it :)
    }

    private static StringBuilder EnDeCrypt(string message, string key)
    {
        StringBuilder answer = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            answer.Append((char)(message[i] ^ key[i % key.Length]));
        }
        return answer;
    }
}

