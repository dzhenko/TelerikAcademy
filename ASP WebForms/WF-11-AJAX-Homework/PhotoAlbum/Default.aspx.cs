using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhotoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ImagesRepeater.DataSource = new int[] { 1, 2, 3, 4, 5, 6 };
            
                this.DataBind();
            }
        }

        protected void PrevImage_Click(object sender, EventArgs e)
        {
            var currentImage = this.PictureUrl.ImageUrl.Substring(this.PictureUrl.ImageUrl.IndexOf('/') + 1, 1);
            if (currentImage == "1")
            {
                currentImage = "7";
            }

            var newImage = int.Parse(currentImage) - 1;
            this.PictureUrl.ImageUrl = string.Format("images/{0}.jpg", newImage);
        }

        protected void NextImage_Click(object sender, EventArgs e)
        {
            var currentImage = this.PictureUrl.ImageUrl.Substring(this.PictureUrl.ImageUrl.IndexOf('/') + 1, 1);
            if (currentImage == "6")
            {
                currentImage = "0";
            }

            var newImage = int.Parse(currentImage) + 1;
            this.PictureUrl.ImageUrl = string.Format("images/{0}.jpg", newImage);
        }

        protected void ViewBtn_Command(object sender, CommandEventArgs e)
        {
            this.PictureUrl.ImageUrl = string.Format("images/{0}.jpg", int.Parse(e.CommandArgument.ToString()));

            this.MPE.Show();

            this.PictureView.Visible = true;
        }

        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            this.PictureView.Visible = false;
        }
    }
}