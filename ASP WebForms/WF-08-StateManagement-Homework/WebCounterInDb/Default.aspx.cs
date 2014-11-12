using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using WebCounterInDb.Data;

namespace WebCounterInDb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new UsersDbContext();
            var usersCount = db.UsersCount.FirstOrDefault();
            usersCount.Count += 1;
            db.SaveChanges();

            Response.Clear();
            Bitmap generatedImage = new Bitmap(200, 20);
            Graphics gr = Graphics.FromImage(generatedImage);
            gr.DrawString(string.Format("Users in application: {0}", usersCount.Count), new Font("Arial", 13.4f), Brushes.MediumSeaGreen, 0, 0);

            Response.ContentType = "image/gif";
            generatedImage.Save(Response.OutputStream, ImageFormat.Gif);
        }
    }
}