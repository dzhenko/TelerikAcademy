////Describe the strings in C#. What is typical for the data type? Describe the most important methods of the String class

//A string is a sequential collection of Unicode characters that is used to represent 

//text. A String object is a sequential collection of System.Char objects that represent a 

//string. The value of the String object is the content of the sequential collection, and 

//that value is immutable (that is, it is read-only). The maximum size of a String object in memory is 2 GB, or about 1 billion characters.

//This type allows us to manipulate character data through different methods and properties.

//Some of the most important methods are the following :

//1. Get lenght of the string ( text.Length )

//2. Convert to uppercase ( text.ToUpper() )

//3. Convert to lowercase ( text.ToLower() )

//4. Substring - get the first 10 characters ( text.Substring(0,10) )

//5. Remove leading or trailing whitespace ( text.Trim() )

//6. Split String by a char ( text.Split(' ') )

//7. Finding the index of a element(or string) ( text.IndexOf(“searchedText”) )

//8. Creating a copy of the string(not the reference var) ( text. Copy(originalString) )

//9. Checks if two reference vars are equal ( object.ReferenceEquals(str1 , str2) )

//10. Concatenates 2 strings ( string.Concat(str1, str2) )

//11. Append (similar to concatenate) text = text + textToAppend

//12. Replacing text in string ( text. Replace(“this”,”that”) )

//13. Comparison string.Compare(string1 , string2) or string1.CompareTo(string2)

//                            Returns 1 if the string1 is bigger than string2

//                            Returns -1 if the string2 is bigger than string1

//                            Returns 0 if they are of the same size