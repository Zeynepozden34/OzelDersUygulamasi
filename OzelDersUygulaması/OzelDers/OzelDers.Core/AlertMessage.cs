using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Core
{
    public class AlertMessage
    {
        public string Title { get; set; } // uyarı başlıpı
        public string Message { get; set; } // uyarı mesajı
        public string AlertType { get; set; } // uyarı mesaj tipi, görünümü
    }
}
