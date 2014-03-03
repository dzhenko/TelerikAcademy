using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}

public class DocumentSystem
{
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static List<Document> allDocuments = new List<Document>();
  
    private static void AddTextDocument(string[] attributes)
    {
        var doc = new TextDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        var doc = new PDFDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void AddWordDocument(string[] attributes)
    {
        var doc = new WordDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void AddExcelDocument(string[] attributes)
    {
        var doc = new ExcelDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void AddAudioDocument(string[] attributes)
    {
        var doc = new AudioDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void AddVideoDocument(string[] attributes)
    {
        var doc = new VideoDocument();

        foreach (var atr in attributes)
        {
            string[] splittedProp = atr.Split('=');

            doc.LoadProperty(splittedProp[0], splittedProp[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            allDocuments.Add(doc);
        }
    }

    private static void ListDocuments()
    {
        if (allDocuments.Count == 0)
        {
            Console.WriteLine("No documents found");
            return;
        }

        foreach (var doc in allDocuments)
        {
            Console.WriteLine(doc);
        }
    }

    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in allDocuments)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc as IEncryptable == null)
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
                else
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in allDocuments)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc as IEncryptable == null)
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
                else
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
        
    }

    private static void EncryptAllDocuments()
    {
        bool oneFound = false;

        foreach (var doc in allDocuments)
        {
            if (doc is IEncryptable)
            {
                oneFound = true;
                ((IEncryptable)doc).Encrypt();
            }
        }

        Console.WriteLine(oneFound ? "All documents encrypted" : "No encryptable documents found");
    }

    private static void ChangeContent(string name, string content)
    {
        bool found = false;
        foreach (var doc in allDocuments)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc as IEditable == null)
                {
                    Console.WriteLine("Document is not editable: {0}",doc.Name);
                }
                else
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
        
    }
}