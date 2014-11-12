using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCounterInMemory
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usersCount = 0;
            Application.Lock();
            if (Application["Users"] == null)
            {
                Application["Users"] = 0;
            }

            Application["Users"] = (int)Application["Users"] + 1;
            usersCount = (int)Application["Users"];
            Application.UnLock();

            Response.Clear();
            Bitmap generatedImage = new Bitmap(200, 20); 
            Graphics gr = Graphics.FromImage(generatedImage);
            gr.DrawString(string.Format("Users in application: {0}",usersCount), new Font("Arial",13.4f),Brushes.MediumSeaGreen, 0, 0);
            
            Response.ContentType = "image/gif";
            generatedImage.Save(Response.OutputStream,ImageFormat.Gif);
        }
    }
}