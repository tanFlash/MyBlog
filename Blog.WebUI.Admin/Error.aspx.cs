using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blog.WebUI
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
             
        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (Server.GetLastError() == null)
                {
                    lblWhat.Text = "No information about an error";
                    lblWhy.Text = "";
                    lblSuggestion.Text = "";
                }
                else
                {
                    Exception ex = Server.GetLastError().GetBaseException();
                    if (ex is HttpException)
                    {
                        HttpException hex = ex as HttpException;
                        lblWhat.Text = "Error: " + ex.Message;
                        lblWhy.Text = "";
                        if (hex.GetHttpCode() == 404)
                        {
                            lblSuggestion.Text = "Check whether the URL you specified is correct";
                        }
                    }
                    else
                    {
                        lblWhat.Text = "Unexpected error: " + ex.Message;
                        lblWhy.Text = "";
                        lblSuggestion.Text = "Contact the system administrator";
                    }
                }
            } 
            catch
            { }
           
        }
        }
    }
