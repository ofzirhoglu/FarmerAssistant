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
    }
}