using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyLib;

namespace MyWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MyNameIs"] != null)
            {
                lblHelloWorld.Text = HelloWorld.GetHelloWorldMessage("My name is "+Request.QueryString["MyNameIs"]);
            }
            else
            {
                lblHelloWorld.Text = HelloWorld.GetHelloWorldMessage("from MyWebApp!");
            }
        }

        protected void btnClickMe_Click(object sender, EventArgs e)
        {
            new MyLib.EmailSender().SendEmail("Test Subject Email", lblHelloWorld.Text);
        }
    }
}