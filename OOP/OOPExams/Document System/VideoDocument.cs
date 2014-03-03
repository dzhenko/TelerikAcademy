using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VideoDocument : MultimediaDocument
{
    public VideoDocument()
    {

    }

    public string Framerate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.Framerate = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.Framerate));
        base.SaveAllProperties(output);
    }
}
