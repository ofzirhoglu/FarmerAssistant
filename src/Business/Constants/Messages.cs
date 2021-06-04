using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string FieldAdded = "Tarla eklendi";
        public static string FieldDeleted = "Tarla silindi";
        public static string FieldUpdated = "Tarla güncellendi";
        public static string FieldsListed = "Tarlalar listelendi";
        public static string FieldGetById = "Tarla Id'ye göre getirildi";
        public static string FieldNameAlreadyExists = "Bu isimde zaten başka bir tarla var";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string GetUserById = "Kullanıcı Id ye göre getirildi";
        public static string GetUserClaims = "Kullanıcı yetkileri getirildi";

        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserGetById = "Kullanıcı id'ye göre getirildi";
        public static string UsersListNotFound = "Listelenecek kullanıcı bulunamadı";

        public static string UserGetByMail = "Kullanıcı mail'e göre getirildi";

        public static string PasswordChanged = "Parola değiştirildi";

        public static string UserDeleted = "Kullanıcı silindi";

        public static string UserUpdated = "Kullanıcı güncellendi";
    }
}