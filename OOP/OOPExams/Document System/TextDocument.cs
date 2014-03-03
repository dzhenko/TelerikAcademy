using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextDocument : Document, IEditable
{
    public TextDocument()
    {

    }

    public string Charset { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

