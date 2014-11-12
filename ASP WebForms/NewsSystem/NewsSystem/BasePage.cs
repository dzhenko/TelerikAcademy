namespace NewsSystem
{
    using System.Web.UI;

    using NewsSystem.Data;

    public class BasePage : Page
    {
        private readonly NewsSystemDbContext data;

        public BasePage()
        {
            this.data = new NewsSystemDbContext();
        }

        protected NewsSystemDbContext Data
        {
            get { return this.data; }
        }
    }
}