using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace _2280603165_NguyenHienThuc_Week3.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (string.IsNullOrEmpty(value))
                return default;

            try
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            catch
            {
                return default; // Nếu có lỗi khi Deserialize, trả về giá trị mặc định
            }
        }
    }
}
