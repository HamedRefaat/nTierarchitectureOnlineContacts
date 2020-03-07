using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnlineContacts.BLL.Helpers
{
    public static class BLLRegistration
    {

        public static Dictionary<Type, Type> GetTypesToRegister()
        {
            string Repositoriesnamespace = "OnlineContacts.BLL.Managers";
            string Interfacesnamespace = "OnlineContacts.BLL.Managers.Interfaces";
            Dictionary<Type, Type> dict = new Dictionary<Type, Type>();
            var Repositories = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsGenericType && t.Namespace == Repositoriesnamespace).ToList();

            var interfaces = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsInterface && !t.IsGenericType && t.Namespace == Interfacesnamespace).ToList();


            foreach (var _interface in interfaces)
            {
                var _class = Repositories.FirstOrDefault(d => d.Name == _interface.Name.Substring(1));
                if (!dict.ContainsKey(_interface) && _class != null)
                {
                    dict.Add(_interface, _class);
                }

            }

            return dict;
        }
    }
}
