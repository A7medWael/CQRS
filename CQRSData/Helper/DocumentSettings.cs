using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSData.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string FolderName)
        {
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", FolderName);
            var filename =$"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";
            var filpath = Path.Combine(folderpath, filename);
            using(var stream=new FileStream(filpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filename;

            
        }
    }
}
