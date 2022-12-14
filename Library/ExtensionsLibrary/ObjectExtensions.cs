using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ExtensionsLibrary
{
    public static class ObjectExtensions
    {
        public static T DeepCopy<T>(this T src) where T : new()
        {
            var json = JsonConvert.SerializeObject(src);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Json<T>(this T src) where T : new()
        {
            return JsonConvert.SerializeObject(src);
        }

        public static void SetCallByName<T>(this T source, string propertyName, T data) where T : new()
        {
            Type t = source.GetType();

            //プロパティのPropertyInfoを取得する
            PropertyInfo p = t.GetProperty(propertyName);

            //プロパティに値を設定する
            p.SetValue(source, data);
        }

        public static object GetCallByName<T>(this T source, string propertyName) where T : new()
        {
            Type t = source.GetType();

            //プロパティのPropertyInfoを取得する
            PropertyInfo p = t.GetProperty(propertyName);

            //プロパティに値を取得する
            return p.GetValue(source);
        }

        public static List<string> GetValidationErrorMessages<T>(this T data) where T : new()
        {
            var errorMessages = new List<string>();

            var validationContext = new ValidationContext(data);
            var validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(data, validationContext, validationResults, true) == false)
            {
                errorMessages.AddRange(validationResults.Select(x => x.ErrorMessage));
            }

            return errorMessages;
        }
    }
}
