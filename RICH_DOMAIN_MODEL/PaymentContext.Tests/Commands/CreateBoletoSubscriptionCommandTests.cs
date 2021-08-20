using System;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{   
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErroWhenNameIsNullOrEmpty()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = string.Empty;

            command.Validate();
            Assert.AreEqual(false, command.IsValid);
        }
    }
}