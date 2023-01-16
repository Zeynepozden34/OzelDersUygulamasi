using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OzelDers.Core
{
    public static class Jobs
    {
        public static string InitUrL(string url)
        {
            #region Açıklamalar
            /* BU metot kendisine gelen url değişkeninin
            1 - Latin alfabesine çevrilen problem çıkaran İ-i ı-i gibi dönüşünleri yapacak
            2-türkçe karakter yerine latin albesindeki karşılıklarını koyacak
            3-Boşluklar yerine - koyacak
            4-(.),(/) gibi karakterleri kaldıracak
            */
            #endregion
            #region Sorunlu karakterler düzeltiliyor
            url = url.Replace("I", "i");
            url = url.Replace("İ", "i");
            url = url.Replace("ı", "i");
            #endregion

            #region küçük harfe dönüştürüldü
            url = url.ToLower();
            #endregion

            #region Türkçe karakterleri dönüştürdük
            url = url.Replace("ö", "o");
            url = url.Replace("ü", "u");
            url = url.Replace("ş", "s");
            url = url.Replace("ç", "c");
            url = url.Replace("ğ", "g");
            #endregion
            #region Boşuklar tire ile değiştirildi
            url = url.Replace(" ", "-");
            #endregion
            #region Sorunlu karakterler kaldırılıyor           
            url = url.Replace(".", "");
            url = url.Replace("/", "");
            url = url.Replace("\"", "");
            url = url.Replace("'", "");
            url = url.Replace("(", "");
            url = url.Replace(")", "");
            url = url.Replace("[", "");
            url = url.Replace("]", "");
            url = url.Replace("{", "");
            url = url.Replace("}", "");
            #endregion
            return url;
        }
            public static string UploadImage(IFormFile image)
            {
                var extension = Path.GetExtension(image.FileName);
                var randomName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", randomName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return randomName;
            }
            public static string CreateMessage(string title, string message, string alertType)
            {
                var msg = new AlertMessage
                {
                    Title = title,
                    Message = message,
                    AlertType = alertType
                };
                return JsonConvert.SerializeObject(msg);
            }

        
    }
}
