using System;
using System.Collections.Generic;
using System.Linq;

public class PDFDocument : EncryptableDocument
{
    public PDFDocument()
    {

    }

    public string Pages { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.Pages = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}

