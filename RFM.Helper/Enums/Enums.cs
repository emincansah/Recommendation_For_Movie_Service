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
            [EnumDescription("Portal erişimi engellendi")]
            AccessDisabled,
            [EnumDescription("Kullanıcı ve şifre boş olamaz")]
            EmptyUserOrNamePass,
            [EnumDescription("Veritabanı hatası veya erişimi yok")]
            DbError,
        }
    }
}
