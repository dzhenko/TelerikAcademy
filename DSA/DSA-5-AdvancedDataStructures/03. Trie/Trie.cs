namespace _03.Trie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        private class Node
        {
            public Node(char value)
            {
                this.Value = value;
                this.Count = 1;
                this.Children = new Dictionary<char, Node>();
            }

            public char Value { get; set; }
            public int Count { get; set; }

            public Dictionary<char, Node> Children { get; set; }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var other = obj as Node;
                return this.Value.Equals(other.Value);
            }

            public override string ToString()
            {
                return string.Format("{0} -> {1} times", this.Value, this.Count);
            }
        }

        private Node root;

        public Trie()
        {
            this.root = new Node('\0');
        }

        public void Add(string word)
        {
            var currNode = this.root;

            var i = 0;

            while (i < word.Length)
            {
                if (currNode.Children.Count == 0)
                {
                    foreach (var ch in word.Substring(i))
                    {
                        currNode.Children.Add(ch, new Node(ch));
                        currNode = currNode.Children[ch];
                    }

                    break;
                }
                
                if (currNode.Children.ContainsKey(word[i]))
                {
                    currNode = currNode.Children[word[i]];
                    currNode.Count++;
                }
                else
                {
                    currNode.Children.Add(word[i], new Node(word[i]));
                    currNode = currNode.Children[word[i]];
                }
                i++;
            }
        }

        public int GetWordOccurance(string word)
        {
            var currNode = this.root;

            var i = 0;

            while (true)
            {
                if (i == word.Length)
                {
                    if (currNode.Children.Count == 0)
                    {
                        return currNode.Count;
                    }
                    else
                    {
                        var childrenOcurences = 0;

                        foreach (var node in currNode.Children)
                        {
                            childrenOcurences += node.Value.Count;
                        }

                        return currNode.Count - childrenOcurences;
                    }
                }

                if (currNode.Children.ContainsKey(word[i]))
                {
                    currNode = currNode.Children[word[i]];
                    i++;
                }
                else
                {
                    break;
                }
            }

            return 0;
        }

        public int WordsCount
        {
            get
            {
                int answer = 0;

                foreach (var item in this.root.Children)
                {
                    answer += item.Value.Count;
                }

                return answer;
            }
        }

        public string GetMostCommonWord()
        {
            var node = this.root;

            string wordToReturn = null;
            char appendedLetter = '\0';

            while (node.Children.Count != 0)
            {
                var newNode = node.Children.First().Value;

                foreach (var child in node.Children)
                {
                    if (child.Value.Count >= newNode.Count)
                    {
                        newNode = child.Value;
                        appendedLetter = child.Key;
                    }
                }

                wordToReturn += appendedLetter;

                node = newNode;
            }

            return wordToReturn;
        }
    }
}
