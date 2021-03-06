using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem kapalıdır";
        public static string CarListed = "Arabalar Listelendi";
        public static string BrandListed = "Markalar Listelendi";
        public static string Success = "İşlem Başarılı";
        public static string Failed = "İşlem Başarısız!";
        public static string CarInvalid = "Araba Bulunamadı";
        public static string CustomerInvalid = "Müşteri Bulunamadı";
        public static string CarPictureNumberExceded = "Bir araba için en fazla beş adet resim eklenebilir.";
        public static string ImagesNotFound = "Resim Bulunamadı";
        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";

        public static string UserRegistered = "UserRegistered";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string AccessTokenCreated = "AccessTokenCreated";

        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string InvalidDate = "InvalidDate";

        public static string DisplacementAdded = "DisplacementAdded";

        public static string InsufficientFindex = "Yetersiz Findex Puanı";

        public static string ImageAdded = "Resim Eklendi";
    }
}
