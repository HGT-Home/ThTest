using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Models.Helpers;

namespace ThTest.Infrastructures
{
    public enum ImageFolder { Category, Product, Customer, Employee };

    public static class FormFileExtension
    {
        private static int FileSize = 1024 * 1024;

        public static byte[] GetBytes(this IFormFile file)
        {
            if (file != null && file.Length <= FileSize)
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);

                    return ms.ToArray();
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="enuFolder"></param>
        /// <returns>Saved filename.</returns>
        public static string SaveImageFile(this IFormFile file, ImageFolder enuFolder, IPathProvider pvdPath)
        {
            // Limit 1Mb file size.
            if (file != null && file.Length <= FileSize)
            {
                string strFolder = pvdPath.MapPath("imgs", enuFolder.ToString());

                // Nếu chưa có thư mục chứa file hình thì tạo mới thư mục đó.
                // Cấu trúc là imgs/Category, imgs/Product, imgs/Customer, imgs/Employee
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }

                // Tạo tên file với tên file góc cộng thêm ngày giờ hiện tại.
                // VD: file: img.png => img.2017.12.24.16.30.25.fff.png.
                string strFilename = $"{Path.GetFileNameWithoutExtension(file.FileName)}.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff")}{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(strFolder, strFilename);

                using(FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                // Trả về path dạng Category/filename.xxx hoặc Product/filename.xxx
                return Path.Combine("imgs", enuFolder.ToString(), strFilename);
            }

            return null;
        }
    }
}
