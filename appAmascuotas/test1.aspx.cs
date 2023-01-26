using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appAmascuotas
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save(object sender, EventArgs e)
        {
            
            
            byte[] data;
            WebClient webClient = new WebClient();
            data = webClient.DownloadData(hfImageUrl.Value);
            File.WriteAllBytes(Server.MapPath("~/Imagenes/staticImage.jpg"), data);
            imgServer.ImageUrl = "~/Imagenes/staticImage.jpg";
            imgServer.AlternateText = "~/Imagenes/staticImage.jpg";
        }
    }
}