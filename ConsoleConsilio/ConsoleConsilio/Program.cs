using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleConsilio
{
    public class Program
    {
        public static User userObject = new User();
        public static int NthRelationship = 2;
        public static string FirstName = "Alison";
        public static string LastName = "Hodges";


        static void Main(string[] args)
        {
            args = new[] { "../../Flatfile/SocialNetwork.csv" };
            User.users = ReadUsersCSV(args[0]);

           /*Test the output for the 1st question
            foreach (var user in User.users)
                Console.WriteLine(user);
                Console.ReadLine();
           */

            string[] UsersWithNthRelationship = userObject.FindUsersWithNthRelationship(NthRelationship);

            /* Test the output for the 2nd question
            for (int i = 0; i < User.UsersWithNthRelationship.Length; i++)
                 Console.WriteLine(User.UsersWithNthRelationship[i]);       
                 Console.ReadLine();
            */
            string[] UsersWithUser = userObject.FindUsersWithUser(FirstName, LastName);

            /* Test the output for the prepare of 3rd question
            for (int i = 0; i < User.UsersWithUser.Length; i++)
                Console.WriteLine(User.UsersWithUser[i]);
                Console.ReadLine();

            */
            string[] UsersWithUserAndWithNthRelationship = userObject.FindUsersWithUserAndWithNthRelationship(UsersWithNthRelationship, UsersWithUser);
            // Test the output for the 3rd question
            Console.Write(UsersWithUserAndWithNthRelationship[0]);
            for (int i = 1; i < UsersWithUserAndWithNthRelationship.Length; i++)
                // Console.WriteLine(UsersWithUserAndWithNthRelationship[i]);
                Console.Write(", {0}", UsersWithUserAndWithNthRelationship[i]);
                Console.ReadLine();

        }

       public static IList<User> ReadUsersCSV(string path,bool hasHeaders=true)
        {
            /*      * path [type string] - The CSV file directory  
             *      * hasHeaders [type bool, default true]- If thare is header in csv file, then we need ignore the first line
             *      * return IList[ User] - A  list of users, user is the user object instanced from user class
             *      */
            var reader = new TextFieldParser(path)
            {
                Delimiters = new[] { "," },
                TrimWhiteSpace = true,
            };

            var list = new List<User>();
            if (hasHeaders)
            {
                reader.ReadLine();
            }

            while (!reader.EndOfData)
            {
                list.Add(User.FromFields(reader.ReadFields()));
            }

            return list;
        }

    }
}
