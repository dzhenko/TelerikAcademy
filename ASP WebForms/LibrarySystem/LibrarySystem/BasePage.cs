namespace LibrarySystem
{
    using System.Web.UI;

    using LibrarySystem.Data;

    public abstract class BasePage : Page
    {
        private readonly LibrarySystemDbContext data;

        public BasePage()
        {
            this.data = new LibrarySystemDbContext();
        }

        protected LibrarySystemDbContext Data
        {
            get { return this.data; }
        }
    }
}
