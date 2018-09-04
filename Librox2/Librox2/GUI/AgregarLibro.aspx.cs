using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Librox2.GUI
{
    public partial class AgregarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveUploadedFile(Request.Files);
            }
        }
        public void SaveUploadedFile(HttpFileCollection httpFileCollection)
        {
            //  bool isSavedSuccessfully = true;
            string fName = "";
            foreach (string fileName in httpFileCollection)
            {
                HttpPostedFile file = httpFileCollection.Get(fileName);
                //Save file content goes here
                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var originalDirectory = new DirectoryInfo(Server.MapPath("~/LibrosPortadas/"));
                    string pathString = originalDirectory.ToString();
                    var fileName1 = Path.GetFileName(file.FileName);
                    bool isExists = System.IO.Directory.Exists(pathString);
                    if (!isExists)
                        System.IO.Directory.CreateDirectory(pathString);
                    var path = string.Format("{0}\\{1}", pathString, file.FileName);
                    file.SaveAs(path);
                }
            }
        }
    }
}