using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class TrieTests
    {
        public static void Main()
        {
            // Test();

            var trie = new Trie();

            var words = new StreamReader("sampleText.txt").ReadToEnd().Split(new char[] { '.', '!', '?', ';', ' ', ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            var result = new StringBuilder();

            var searchedWords = new StreamReader("searchedWords.txt").ReadToEnd().Split(new char[] { '.', '!', '?', ';', ' ', ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int occurs = 0;
            foreach (var word in searchedWords)
            {
                result.Append(word);
                result.Append(" -> ");
                trie.TryFindWord(word, out occurs);
                result.Append(occurs);
                result.AppendLine(" times");
            }

            Console.Write(result.ToString());
        }

        private static void Test()
        {
            var a = new Trie();

            a.AddWord("hello");
            a.AddWord("hello");
            a.AddWord("hi");
            a.AddWord("helloo");

            int oc = 0;
            Console.WriteLine(a.TryFindWord("hel", out oc) + " -> " + oc + " times");

            Console.WriteLine(a.TryFindWord("hi", out oc) + " -> " + oc + " times");

            Console.WriteLine(a.TryFindWord("hii", out oc) + " -> " + oc + " times");

            Console.WriteLine(a.TryFindWord("hello", out oc) + " -> " + oc + " times");

            Console.WriteLine(a.TryFindWord("helloo", out oc) + " -> " + oc + " times");
        }
    }
}
