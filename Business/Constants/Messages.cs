using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryNameInvalid = "Ürün ismi geçersiz";
        public static string CategoriesListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Bakım Saati";
        public static string NotFoundProduct = "Ürün bulunamadı";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameAlreadyExist = "Aynı isme sahip ürün zaten var";
        public static string CheckIfProductCountOfCategoryCorrect = "Bir kategoride en fazla 10 ürün bulunmalıdır";
        public static string CategoryLimitExceded = "Kategori sayısı 15'ten fazla olduğu için ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yoktur";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
