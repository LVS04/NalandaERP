using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DNXTest.Models
{
    public static class ContactExtensions
    {

        public static void CopyPropertiesFrom(this Contact targetObject, object source)
        {
            PropertyInfo[] allProperties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            PropertyInfo targetProperty;

            foreach (PropertyInfo fromProp in allProperties)
            {
                targetProperty = targetObject.GetType().GetProperty(fromProp.Name);
                if (targetProperty == null) continue;
                if (!targetProperty.CanWrite) continue;

                if (targetProperty.Name.ToLower() == "id" || targetProperty.Name.ToLower() == "contact" )
                    continue;

                if (targetProperty.PropertyType.Name.Contains("Contact") && targetProperty.PropertyType.Name.Length > 7 )
                {
                    foreach (PropertyInfo prop in targetProperty.Name.Split('.').Select(s => source.GetType().GetProperty(s)))
                    {
                        var obj = prop.GetValue(source, null);

                        foreach(PropertyInfo innerProp in obj.GetType().GetProperties())
                        {
                            var innerObj = innerProp.GetValue(obj, null);
                            if(innerProp.Name.ToLower() == "id" || innerProp.Name.ToLower() == "contact") continue;

                            var destProperty = targetObject.GetType().GetProperty(prop.Name);
                            var destInnerObj = destProperty.GetValue(targetObject, null);

                            var destInnerObjProperty = destInnerObj.GetType().GetProperty(innerProp.Name);
                            destInnerObjProperty.SetValue(destInnerObj, innerObj);
                        }  
                    }
                }
                else
                    targetProperty.SetValue(targetObject, fromProp.GetValue(source, null), null);
            }
        }
    }
}
