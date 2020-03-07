using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.DAL.Helpers
{
    public static class DALRegistration
    {
        public static Dictionary<Type, Type> GetTypesToRegister()
        {
            string Repositoriesnamespace = "OnlineContacts.DAL.Repositories";
            string Interfacesnamespace = "OnlineContacts.DAL.Repositories.Interfaces";
            Dictionary<Type, Type> dict = new Dictionary<Type, Type>();
            var Repositories = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsGenericType && t.Namespace == Repositoriesnamespace).ToList();

            var interfaces = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsInterface && !t.IsGenericType && t.Namespace == Interfacesnamespace).ToList();


            foreach (var _interface in interfaces)
            {
                // the rule here is that the interface is the same name as the class that implement it + on character at the beginnenig 'I' 
                var _class = Repositories.FirstOrDefault(d => d.Name == _interface.Name.Substring(1));
                if (!dict.ContainsKey(_interface))
                {
                    dict.Add(_interface, _class);
                }

            }

            return dict;
        }
    }
}
