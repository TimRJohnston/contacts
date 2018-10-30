using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AngularPhonebookApp.Models;
using AngularPhonebookApp.Services;
using AngularPhonebookApp.Interfaces;
using System.Linq;
using AngularPhonebookApp.Controllers;
using AngularPhonebookApp.Models.Entity;

namespace Tests.Integration
{
    /// <summary>
    ///    Integration Tests for ContactController.
    /// </summary>
    /// 
    [TestClass]
    public class ContactControllerTest
    {

        private static DBSetupTestUtil dbUtil = new DBSetupTestUtil(@"Server=localhost;Database=TestDB;Trusted_Connection=True;");
        private static ContactController contactController = new ContactController();

        [TestInitialize]
        public void InitializeTests()
        {
            dbUtil.DeleteAllData();
        }

        [TestMethod]
        public void ShouldReturnAllContactsWhenIndexPageIsCalled()
        {
            ///ARRANGE            
            dbUtil.AddRow("Andy", "11111", "asdasd-asdsaf-asds-asda");
            dbUtil.AddRow("Sean", "22222", "3sdasd-asdsaf-asds-asd3");
            dbUtil.AddRow("Mark", "33333", "4sdasd-asdsaf-asds-asd4");

            //ACT
            var contacts = contactController.Index();

            //ASSERT   
            Assert.IsTrue(contacts.Count() == 3);
        }

        [TestMethod]
        public void ShouldReturnNewlyCreatedContact()
        {
            ///ARRANGE   

            //ACT
            contactController.Create(new ContactDTO { Name = "Jim", Number = "3333333" });

            //ASSERT
            IEnumerable<Contact> contacts = dbUtil.GetAllData();
            Assert.IsTrue(contacts.Any(x => x.ContactName.Equals("Jim")));
        }

        [TestMethod]
        public void ShouldReturnUpdatedContact()
        {
            ///ARRANGE            
            dbUtil.AddRow("Sam", "7878", "asdasd-asdsaf-asds-asda");
            int id = dbUtil.GetAllData().FirstOrDefault().ID;

            //ACT
            contactController.Edit(new ContactDTO { ID = id, Name = "Sam2", Number = "11111" });

            //ASSERT 
            Contact contact = dbUtil.GetAllData().FirstOrDefault();
            Assert.IsTrue(contact.Number.Equals("11111"));
        }

        [TestMethod]
        public void ShouldReturnCorrectContactWhenRequestedByID()
        {
            ///ARRANGE
            dbUtil.AddRow("Brian", "2222", "asdasd-asdsaf-asds-asda");
            int id = dbUtil.GetAllData().FirstOrDefault().ID;

            //ACT
            ContactDTO contactDto = contactController.Details(id);

            //ASSERT 
            Assert.IsTrue(contactDto.Name.Equals("Brian"));
        }

        [TestMethod]
        public void ShouldNotReturnContactWhenInvalidIdProvided()
        {
            ///ARRANGE
            dbUtil.AddRow("Brian", "2222", "asdasd-asdsaf-asds-asda");
            int invalidId = dbUtil.GetAllData().FirstOrDefault().ID + 1;

            //ACT
            ContactDTO contactDto = contactController.Details(invalidId);

            //ASSERT 
            Assert.IsTrue(contactDto.ID == 0);
        }

        [TestMethod]
        public void ShouldDeleteCorrectContact()
        {
            ///ARRANGE
            dbUtil.AddRow("Del", "00000", "asdasd-asdsaf-asds-asda");
            int id = dbUtil.GetAllData().FirstOrDefault().ID;
            //ACT
            var delete = contactController.Delete(id);
            //ASSERT 
            Assert.IsTrue(dbUtil.GetAllData().Count() == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void ShouldThrowExceptionWhenInvalidContactAddedToDB()
        {
            ///ARRANGE                    

            //ACT
            contactController.Create(new ContactDTO { Number = "3333333" });

            //ASSERT               
        }




    }
}
