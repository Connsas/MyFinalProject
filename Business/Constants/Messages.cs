using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductCountOfCategoryError = "Bir kategoride 10 adetten fazla ürün bulunamaz.";
        public static string ProductNameAlreadyExists = "Bu ürüne sahip ürün zaten mevcut.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered;
        public static string UserNotFound;
        public static string PasswordError = "Şifre Yanlış";
        public static string SuccessfulLogin;
        public static string UserAlreadyExists;
        public static string AccessTokenCreated;
    }
}
