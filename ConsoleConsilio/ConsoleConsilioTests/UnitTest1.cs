using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleConsilio;
using System.Collections.Generic;


namespace ConsoleConsilioTests
{
    [TestClass]
    public class UnitTest1
    {
       
       public List<User> users = new List<User>();
              
        public void ToStringTest()
        {
            var user1 = new User();
            List<string> friends1 = new List<string>();
            friends1.Add("a003");
            friends1.Add("a005");
            friends1.Add("a010");

            user1.Id = "a001";
            user1.FirstName = "Neil";
            user1.LastName = "Avery";
            user1.Friends = friends1;
            string userToString = "User: " + user1.Id + " " + user1.FirstName + " " + user1.LastName + " " + string.Join(";", friends1.ToArray()); 

            Assert.AreEqual(userToString,user1.ToString());
        }

        [TestMethod]
        public void GetAllSameElementTest()
        {
            string[] friends1 = { "a003", "a005", "a010" };
            string[] friends2 = { "a003", "a006", "a011" };
            List<string> friends3 = new List<string>();
            friends3.Add("a003");

            List<string> result = User.GetAllSameElement(friends1, friends2);
            //Assert.AreEqual(friends3, result);
            CollectionAssert.AreEqual(friends3, result);
        }

        [TestMethod]
        public void FindUsersWithUserAndWithNthRelationshipTest()
        {
            string[] friends1 = { "a003", "a005", "a010" };
            string[] friends2 = { "a003", "a006", "a011" };
            string[] friends3 = { "a003" };

            var user = new User();

            string[] result = user.FindUsersWithUserAndWithNthRelationship(friends1, friends2);
            //Assert.AreEqual(friends3, result);
            CollectionAssert.AreEqual(friends3, result);
        }


        [TestMethod]
        public void FindUsersWithNthRelationshipTest()
        {
            var user1 = new User();
            List<string> friends1 = new List<string>();
            friends1.Add("a003");
            friends1.Add("a005");
            friends1.Add("a010");

            user1.Id = "a001";
            user1.FirstName = "Neil";
            user1.LastName = "Avery";
            user1.Friends = friends1;

            var user2 = new User();
            List<string> friends2 = new List<string>();
            friends1.Add("a003");
            friends1.Add("a006");
            friends1.Add("a011");

            user2.Id = "a002";
            user2.FirstName = "Neil";
            user2.LastName = "Leonard";
            user2.Friends = friends2;

            
            users.Add(user1);
            users.Add(user2);

            string[] UsersWithNthRelationship = user1.FindUsersWithNthRelationship(3);

            string[] userArr = { "a001", "a002" };
            Assert.AreEqual(userArr, UsersWithNthRelationship);
           // CollectionAssert.AreEqual( new List<string>(userArr), new List<string>(UsersWithNthRelationship));
        }
    }
}
