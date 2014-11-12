namespace NewsSystem.Controls
{
    using System;
    using System.Web.UI.WebControls;

    public partial class LikeControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LikePanelHolder.Visible = this.Context.User.Identity.IsAuthenticated;
        }

        public int LikesCount { get; set; }

        public object ArticleId { get; set; }

        public bool? UserVote { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.LableLikesCount.Text = this.LikesCount.ToString();

            if (this.UserVote.HasValue)
            {
                if (this.UserVote.Value)
                {
                    this.ButtonLike.Visible = false;
                    this.ButtonHate.Visible = true;
                }
                else
                {
                    this.ButtonLike.Visible = true;
                    this.ButtonHate.Visible = false;
                }
            }
        }

        public delegate void LikeControlEventHandler(object sender, LikeControlEventArgs e);

        public event LikeControlEventHandler ButtonClicked;

        protected void Vote_Command(object sender, CommandEventArgs e)
        {
            if (this.ButtonClicked != null)
            {
                this.ButtonClicked(this, new LikeControlEventArgs(e.CommandArgument, bool.Parse(e.CommandName.ToString())));
            }
        }
    }

    public class LikeControlEventArgs : EventArgs
    {
        public LikeControlEventArgs(object articleId, bool liked)
        {
            this.ArticleId = articleId;
            this.Liked = liked;
        }

        public object ArticleId { get; private set; }

        public bool Liked { get; private set; }
    }
}