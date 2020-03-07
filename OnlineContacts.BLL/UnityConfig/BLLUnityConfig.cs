using OnlineContacts.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace OnlineContacts.BLL.UnityConfig
{
    public static class BLLUnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer BLLContainer => container.Value;
        #endregion


        public static void RegisterTypes(IUnityContainer container)
        {

            var ToRegister = DALRegistration.GetTypesToRegister();
           
            foreach (var item in ToRegister)
            {
                if (!container.IsRegistered(item.Key))
                {
                    container.RegisterType(item.Key, item.Value);
                }
            }

        }
    }
}
