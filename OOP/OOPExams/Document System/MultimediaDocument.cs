using System;
using System.Collections.Generic;
using System.Linq;

public abstract class MultimediaDocument : BinaryDocument
{
    //length
    public string Length { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }
}

