using System;
using System.Collections.Generic;
using System.Linq;

public class AudioDocument : MultimediaDocument
{
    public AudioDocument()
    {
            
    }

    public string Samplerate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.Samplerate = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.Samplerate));
        base.SaveAllProperties(output);
    }
}

