using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class TimerFotografAlbumu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string dizin = Server.MapPath("resimler") + "\\";
            DirectoryInfo di = new DirectoryInfo(dizin);
            DirectoryInfo[] klasorler = di.GetDirectories();
            foreach (DirectoryInfo album in klasorler)
            {
                listAlbumler.Items.Add(album.Name);
            }


            listAlbumler.SelectedIndex = 0;
            ResimGoster("ileri");

        }
    }

    void ResimGoster(string yon)
    {
        string albumDizin =
            Server.MapPath("resimler") + "\\" + listAlbumler.SelectedItem.Text;

        DirectoryInfo di = new DirectoryInfo(albumDizin);
        FileInfo[] resimler = di.GetFiles("*.jpg");

        
        int resimNo;
        if (ViewState["resimNo"] != null)
        {
            resimNo = (int)ViewState["resimNo"];
            if (yon == "ileri")
            {
                resimNo++;
         
                if (resimNo >= resimler.Length)
                    resimNo = 0;
            }
         
            else
            {
                resimNo--;
         
                if (resimNo < 0)
                    resimNo = resimler.Length - 1;
            }
            ViewState["resimNo"] = resimNo;
        }
        else
        {
            resimNo = 0;
            ViewState["resimNo"] = resimNo;
        }

        imgResim.ImageUrl =
        "resimler\\" + listAlbumler.SelectedItem.Text + "\\" + resimler[resimNo];
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ResimGoster("ileri");
    }

    protected void btnOnceki_Click(object sender, EventArgs e)
    {
        ResimGoster("geri");
    }

    protected void btnSonraki_Click(object sender, EventArgs e)
    {
        ResimGoster("ileri");
    }

    protected void btnDurdur_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = false;
    }

    protected void btnBaslat_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
    }


}