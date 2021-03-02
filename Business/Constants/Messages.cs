using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        // Brand Message
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi ";
        public static string BrandListed = "Markalar Listelendi";
        public static string BrandFinded = "Marka Bulundu";
        // Car Messagess
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi ";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarFinded = "Araba Bulundu";
        public static string CarDetailsListed = "Arabaların Detayları yükleniyor";
        //Color Messages
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi ";
        public static string ColorListed = "Renkler Listelendi";
        public static string ColorFinded = "Renk Bulundu";

        public static string MaxCarImage = "Bir Arabanın en fazla5 tane resmi olabilir ..";

        public static string ClaimsListed = "Yetkiler listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserAlreadyExists = "Bu mail adresi sistemimizde zaten kayıtlı";
        public static string UserNotFind = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı ";
        public static string SuccessLogin = "Giriş başarılı";
        public static string AccessTokenCreated = "Token oluşturuldu ";
    }
}
