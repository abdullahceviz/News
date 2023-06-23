using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string NewsAdded = "Haber Başarıyla eklendi.";
        public static string NewsDeleted = "Haber Başarıyla silindi.";
        public static string NewsUpdated = "Haber Başarıyla güncellendi.";
        public static string NewsCaptionNotEmpty = "Haber Başlığı Boş geçilemez!";
        public static string NewsContentNotEmpty = "Haber İçeriği Boş geçilemez!";
        public static string NewsUpdateError = "Bir başkasının haberini güncelleyemezsiniz!";
        public static string NewsDeleteError = "Bir başkasının haberini silemezsiniz!";

        public static string UserNotFound = "Kullanıcı Bulunamadı!";
        public static string PasswordError = "Şifre Bulunamadı!";
        public static string SuccessfulLogin = "Sisteme giriş başarılı!";
        public static string UserAlreadyExists = "Kullancı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";

        public static string AuthorizationDenied = "Yetkiniz yok!";
    }
}
