using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public enum ImageFolder { Category, Product, Customer, Employee };

    public static class FromFileExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="enuFolder"></param>
        /// <returns>Saved filename.</returns>
        public static string SaveImageFile(this IFormFile file, ImageFolder enuFolder)
        {
            if (file != null && file.Length <= 1024 * 1024)
            {
                string strFolder = Path.Combine(Directory.GetCurrentDirectory(), "imgs", enuFolder.ToString());

                // Nếu chưa có thư mục chứa file hình thì tạo mới thư mục đó.
                // Cấu trúc là imgs/Category, imgs/Product, imgs/Customer, imgs/Employee
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }

                // Tạo tên file với tên file góc cộng thêm ngày giờ hiện tại.
                // VD: file: img.png => img.2017.12.24.16.30.25.png.
                string strFilename = $"{Path.GetFileNameWithoutExtension(file.FileName)}.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "imgs", enuFolder.ToString(), file.Name);

                using(FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                return strFilename;
            }

            return null;
        }
    }
}
