using FredRodriguez.Library.Identity.Model;
using FredRodriguez.Library.Identity.Service.EventHandlers.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FredRodriguez.Library.Test
{
    [TestClass]
    public class UserCreateEventHandlerTest
    {
        [TestMethod]
        public void tryIdentity()
        {
            UserCreateCommand notification = new UserCreateCommand();
            var entry = new ApplicationUser
            {
                FirstName = notification.FirstName,
                LastName = notification.LastName,
                Email = notification.Email,
                UserName = notification.Email
            };
        }
    }
}
