using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        public IQueryable<string> GetProducers()
        {
            return Producer.GetProducers().Select(x => x.Name).AsQueryable();
        }

        public IQueryable<string> GetExtras()
        {
            return Extra.GetExtras().Select(e => e.Name).AsQueryable();
        }

        public IQueryable<string> GetEngines()
        {
            return new[] {"V8", "V6", "V4", "Diesel", "Electric"}.AsQueryable();
        }

        protected void CarProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarModel.DataSource = Producer.GetProducers().Where(p => p.Name == this.CarProducer.SelectedValue).FirstOrDefault().Models;
            this.CarModel.DataBind();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            var extras = new List<string>();
            foreach (ListItem item in this.Extras.Items)
            {
                if (item.Selected)
                {
                    extras.Add(item.Value);
                }
            }
            
            this.Result.Text = string.Format("Your choice is {0} {1} with {2} engine and the following extras: {3}.",
                this.CarProducer.SelectedValue, this.CarModel.SelectedValue, this.Engine.SelectedValue, string.Join(", ", extras));
        }
    }
}