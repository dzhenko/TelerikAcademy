using System;
using System.Collections.Generic;
using System.Linq;

public class ExcelDocument : OfficeDocuments
{
    public ExcelDocument()
    {
            
    }

    public string Rows { get; protected set; }
    public string Cols { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = value;
        }
        else if (key == "cols")
        {
            this.Cols = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
        base.SaveAllProperties(output);
    }
}

