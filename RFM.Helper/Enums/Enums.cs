using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFM.Helper.Enums
{
    public class Enums
    {
        public enum LoginResults
        {
            [EnumDescription("Başarılı")]
            Success,
            [EnumDescription("Kullanıcı veya şifre hatalı")]
            InvalidLogin,
            [EnumDescription("Kulanıcı aktif değil")]
            InactiveUser,
            [EnumDescription("API erişimi engellendi")]
            AccessDisabled,
            [EnumDescription("Kullanıcı ve şifre boş olamaz")]
            EmptyUserOrNamePass,
            [EnumDescription("Veritabanı hatası")]
            DbError,
        }
        public enum VoteResult
        {
            [EnumDescription("Başarılı")]
            Success,
            [EnumDescription("Film Bulunamadı")]
            InvalidMovie, 
            [EnumDescription("Veritabanı hatası")]
            DbError,
        }
        public enum RecommendationResult
        {
            [EnumDescription("Başarılı")]
            Success,
            [EnumDescription("Film Bulunamadı")]
            InvalidMovie,
            [EnumDescription("Veritabanı hatası")]
            DbError,
        }
        public enum EmailStatus
        {
            [EnumDescription("Gönderim Tamamlandı")]
            Success =10,
            [EnumDescription("Gönderim Bekliyor")]
            Draft =1,
            
        }
    }
}
