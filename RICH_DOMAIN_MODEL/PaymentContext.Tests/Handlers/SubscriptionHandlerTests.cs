using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName= "Bruce";
            command.LastName= "Wayne";
            command.Document= "99999999999";
            command.Email= "hello@teste.com";
            command.BarCode= "123456789";
            command.BoletoNumber= "123456789";
            command.PaymentNumber= "1321566";
            command.PaidDate= DateTime.Now;
            command.ExpireDate= DateTime.Now.AddMonths(1);
            command.Total= 60;
            command.TotalPaid= 60;
            command.Payer= "Wayne corp";
            command.PayerDocument= "123456791011";
            command.PayerDocumentType= EDocumentType.CPF;
            command.PayerEmail= "batman@wayne.com";
            command.Street= "sasasa";
            command.Number= "123";
            command.Neighborhood= "sasa";
            command.City= "sasa";
            command.State= "sasa";
            command.Country= "sasasasa";
            command.ZipCode= "312321321";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }
    }
}