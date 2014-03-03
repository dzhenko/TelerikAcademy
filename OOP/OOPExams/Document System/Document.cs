using System;
using System.Collections.Generic;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }
    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException("Invalid key!");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object> ("name",this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();

        this.SaveAllProperties(properties);

        properties.Sort((x,y) => x.Key.CompareTo(y.Key));

        StringBuilder sb = new StringBuilder();

        sb.Append(this.GetType().Name);
        sb.Append('[');

        var encriptableDoc = this as EncryptableDocument;

        if (encriptableDoc != null && encriptableDoc.IsEncrypted)
        {
            sb.Append("encrypted");
            sb.Append("]");
        }

        else
        { 
            foreach (var item in properties)
            {
                if (item.Value != null )
                {
                    sb.AppendFormat("{0}={1};", item.Key, item.Value);
                }
            }

            sb.Length--;
            sb.Append("]");
        }

        return sb.ToString();
    }
}

