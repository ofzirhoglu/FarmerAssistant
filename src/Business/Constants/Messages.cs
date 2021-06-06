using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {


        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string PasswordError = "Parola hatası";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string GetUserClaims = "Kullanıcı yetkileri getirildi";
        public static string UserGetByMail = "Kullanıcı mail'e göre getirildi";
        public static string PasswordChanged = "Parola değiştirildi";

        //! Users
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserGetById = "Kullanıcı id'ye göre getirildi";
        public static string UserAlreadyExists = "Bu kullanıcı zaten var";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UsersListNotFound = "Listelenecek kullanıcı bulunamadı";
        //! Users

        //! Fields
        public static string FieldAdded = "Tarla eklendi";
        public static string FieldDeleted = "Tarla silindi";
        public static string FieldUpdated = "Tarla güncellendi";
        public static string FieldGetById = "Tarla Id'ye göre getirildi";
        public static string FieldNameAlreadyExists = "Bu isimde zaten başka bir tarla var";
        public static string FieldNotFound = "Tarla bulunamadı";
        public static string FieldsListed = "Tarlalar listelendi";
        public static string FieldsListNotFound = "Listelenecek Tarla bulunamadı";
        //! Fields

        //! Companies
        public static string CompanyAdded = "Firma eklendi";
        public static string CompanyDeleted = "Firma silindi";
        public static string CompanyUpdated = "Firma Güncellendi";
        public static string CompanyGetById = "Firma id'ye göre getirildi";
        public static string CompanyNameAlreadyExists = "Bu isimde zaten başka bir firma var";
        public static string CompanyNotFound = "Firma bulunamadı";
        public static string CompaniesListed = "Firmalar listelendi";
        public static string CompaniesListNotFound = "Listelenecek firma bulunamadı";
        //! Companies

        //! SaleTypes
        public static string SaleTypeAdded = "Satış tipi eklendi";
        public static string SaleTypeDeleted = "Satış tipi silindi";
        public static string SaleTypeUpdated = "Satış tipi Güncellendi";
        public static string SaleTypeGetById = "Satış tipi id'ye göre getirildi";
        public static string SaleTypeNameAlreadyExists = "Bu isimde zaten başka bir satış tipi var";
        public static string SaleTypeNotFound = "Satış tipi bulunamadı";
        public static string SaleTypesListed = "Satış tipleri listelendi";
        public static string SaleTypesListNotFound = "Listelenecek satış tipi bulunamadı";
        //! SaleTypes

        //! HarvestTypes
        public static string HarvestTypeAdded = "Hasat tipi eklendi";
        public static string HarvestTypeDeleted = "Hasat tipi silindi";
        public static string HarvestTypeUpdated = "Hasat tipi Güncellendi";
        public static string HarvestTypeGetById = "Hasat tipi id'ye göre getirildi";
        public static string HarvestTypeNameAlreadyExists = "Bu isimde zaten başka bir hasat tipi var";
        public static string HarvestTypeNotFound = "Hasat tipi bulunamadı";
        public static string HarvestTypesListed = "Hasat tipleri listelendi";
        public static string HarvestTypesListNotFound = "Listelenecek hasat tipi bulunamadı";
        //! HarvestTypes

    }
}