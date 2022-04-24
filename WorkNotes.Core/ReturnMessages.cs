using System.Collections.Generic;

namespace WorkNotes.Core
{
    public static class ReturnMessages
    {

        public static KeyValuePair<string, string> SUCCESSFUL = new KeyValuePair<string, string>("000", "İşlem başarılı.");
        public static KeyValuePair<string, string> GENERIC_ERROR = new KeyValuePair<string, string>("001", "Beklenmeyen bir hata oluştu.");
        public static KeyValuePair<string, string> MODEL_VALIDATION_ERROR = new KeyValuePair<string, string>("002", "Girilen değerler hatalı, lütfen kontrol ederek tekrar giriniz. </br></br> {0}.");

        public static KeyValuePair<string, string> CREATE_ERROR = new KeyValuePair<string, string>("100", "Kayıt işlemi yapılırken bir hata oluştu.");
        public static KeyValuePair<string, string> UPDATE_ERROR = new KeyValuePair<string, string>("101", "Güncelleme işlemi yapılırken bir hata oluştu.");
        public static KeyValuePair<string, string> DELETE_ERROR = new KeyValuePair<string, string>("102", "Silme işlemi yapılırken bir hata oluştu.");
        public static KeyValuePair<string, string> CREATE_SUCCESSFUL = new KeyValuePair<string, string>("103", "Kayıt başarıyla eklendi.");
        public static KeyValuePair<string, string> UPDATE_SUCCESSFUL = new KeyValuePair<string, string>("104", "Güncelleme işlemi başarıyla gerçekleştirildi.");
        public static KeyValuePair<string, string> DELETE_SUCCESSFUL = new KeyValuePair<string, string>("105", "Silme işlemi başarıyla gerçekleştirildi.");

        public static KeyValuePair<string, string> CONNECTION_ERROR = new KeyValuePair<string, string>("200", "Bağlantı kurulurken bir hata oluştu.");
        public static KeyValuePair<string, string> MONGO_DB_ERROR = new KeyValuePair<string, string>("201", $"Beklenmeyen bir hata oluştu.");
        public static KeyValuePair<string, string> MONGO_DB_CONN_NOT_FOUND_IN_CONFIGURATION = new KeyValuePair<string, string>("202", "Config içerisinde MongoDB bağlantı bilgisi bulunamadı.");
        public static KeyValuePair<string, string> MONGO_DB_NAME_NOT_FOUND_IN_CONFIGURATION = new KeyValuePair<string, string>("203", "Config içerisinde MongoDB veritabanı bilgisi bulunamadı.");

        public static KeyValuePair<string, string> ITEM_NOT_FOUND = new KeyValuePair<string, string>("2", "Veri bulunamadı.");
    }
}
