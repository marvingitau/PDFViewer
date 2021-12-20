using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPPdfViewer.Models
{
    public class FilesUpload
    {

        public int ID { get; set; }
        public  string DocName { get; set; }
    }

    public class MyFiles:DbContext
    {
        public MyFiles()
        {

        }
        public DbSet<FilesUpload> Files { get; set; }
    }
}