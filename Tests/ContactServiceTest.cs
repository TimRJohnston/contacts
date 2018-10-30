
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AngularPhonebookApp.Models;
using Moq;
using AngularPhonebookApp.Services;
using AngularPhonebookApp.Interfaces;
using System.Linq;
using AngularPhonebookApp.Models.Entity;

namespace Tests
{
    /// <summary>
    ///    Unit Tests for ContactService.
    /// </summary>
    /// 
    [TestClass]
    public class ContactServiceTest
    {
        private static List<Contact> mockContacts;
        private static Mock<IContactDataAccessLayer> mockDAL;
        private static Contact contact;
        private static ContactDTO contactDTO;
        private static ContactService contactService;

        [ClassInitialize]
        public static void TestSetup(TestContext testContext)
        {
            mockDAL = new Mock<IContactDataAccessLayer>();

            mockContacts = new List<Contact>()
            {
                    new Contact {ID = 1,ContactName = "John",Number = "1111111", SessionID = "sdasdsadsadsasad" },
                    new Contact {ID = 2,ContactName = "Jack",Number = "2222222", SessionID = "sdasdsadsadsasad" }
            };

            contact = new Contact { ID = 1, ContactName = "Jim", Number = "3333333", SessionID = "sdasdsadsadsasad" };
            contactDTO = new ContactDTO { ID = 1, Name = "Jim", Number = "3333333" };
            contactService = new ContactService(mockDAL.Object);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestMethod]
        public void ShouldReturnAllContacts()
        {
            ///ARRANGE            
            mockDAL.Setup(m => m.GetAllContacts()).Returns(mockContacts);

            //ACT
            var actual = contactService.GetAllContacts();

            //ASSERT
            Assert.AreEqual(actual.ToList().Count, mockContacts.Count);
        }



        [TestMethod]
        public void ShouldSaveNewContact_AndReturnIdWhenSuccessful()
        {
            ///ARRANGE            
            mockDAL.Setup(m => m.AddContact(It.IsAny<Contact>())).Returns(1);

            //ACT
            var actual = contactService.AddContact(contactDTO);

            //ASSERT
            Assert.AreEqual(actual, 1);
        }



        [TestMethod]
        public void ShouldReturnCorrectContactDetailsForGivenId()
        {
            ///ARRANGE            
            mockDAL.Setup(m => m.GetContactData(It.IsAny<int>())).Returns(contact);

            //ACT
            var actual = contactService.GetContactData(1);

            //ASSERT

            Assert.AreEqual(actual.ID, contact.ID);
        }

        [TestMethod]
        public void ShouldReturnIdWhenContactIsUpdated()
        {
            ///ARRANGE            
            mockDAL.Setup(m => m.UpdateContact(It.IsAny<Contact>())).Returns(1);

            //ACT
            var actual = contactService.UpdateContact(contactDTO);

            //ASSERT
            Assert.AreEqual(actual, 1);
        }

        [TestMethod]
        public void ShouldDeleteCorrectContact()
        {
            ///ARRANGE            
            mockDAL.Setup(m => m.DeleteContact(It.IsAny<int>())).Returns(1);

            //ACT
            var actual = contactService.DeleteContact(10);

            //ASSERT
            Assert.AreEqual(actual, 1);
        }
    }
}
