using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SqRootBtn.Text = "\u221A"; 
        }

        protected void Calculate_Click(object sender, EventArgs e)
        {
            if (ViewState["Result"] == null)
            {
                ViewState["Result"] = GetResult(ViewState["Operand0"].ToString(),
                                                    ViewState["Operand1"].ToString(),
                                                    ViewState["Operation0"].ToString());
            }

            this.Result.Text = ViewState["Result"].ToString();
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ViewState.Clear();
            this.Result.Text = "";
        }

        protected void Operation_Click(object sender, CommandEventArgs e)
        {
            if (ViewState["Index"] == null)
            {
                ViewState["Index"] = "0";
            }

            int index = int.Parse(ViewState["Index"].ToString());
            ViewState["Operation" + index] = e.CommandArgument.ToString();
            // second operation - show result of first two
            if (index > 0)
            {
                if (ViewState["Result"] == null)
                {
                    ViewState["Result"] = "";
                }

                ViewState["Result"] = this.GetResult(ViewState["Operand" + (index - 1)].ToString(),
                                                    ViewState["Operand" + index].ToString(),
                                                    ViewState["Operation" + (index - 1)].ToString());
            }
            ViewState["Index"] = index + 1;
        }
        
        protected void Digit_Click(object sender, CommandEventArgs e)
        {
            if (ViewState["Index"] == null)
            {
                ViewState["Index"] = "0";
            }

            string key = "Operand" + ViewState["Index"].ToString();
            if (ViewState[key] == null)
            {
                ViewState[key] = "";
            }

            ViewState[key] = ViewState[key].ToString() + e.CommandArgument.ToString();

            this.Result.Text = ViewState[key].ToString();
        }

        private string GetResult(string op1, string op2, string operation)
        {
            var num1 = double.Parse(op1);
            var num2 = double.Parse(op2);

            switch (operation)
            {
                case "+": return (num1 + num2).ToString();
                case "-": return (num1 + num2).ToString();
                case "*": return (num1 + num2).ToString();
                case "/": return (num1 + num2).ToString();
                case "sr": return (Math.Sqrt(num1)).ToString();
                default: return "Invalid input";
            }
        }
    }
}