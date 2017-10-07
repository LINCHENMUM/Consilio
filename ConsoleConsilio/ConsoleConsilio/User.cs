using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleConsilio
{


    public class User
    {
        private string _Id;
        private string _FirstName;
        private string _LastName;
        private List<string> _Friends;

        public static IList<User> users = new List<User>();
        

        public string Id {
            set;
            get;
        }

        public string FirstName
        {
            set;
            get;
        }
        public string LastName
        {
            set;
            get;
        }

        public List<string> Friends 
        {
            set;
            get;
        }

        public static User FromLine(string line)
        {
            var data = line.Split(',');
            return FromFields(data);
        }

        public static User FromFields(string[] data)
        {
            return new User()
            {
                Id = data[0],
                FirstName = data[1],
                LastName = data[2],
                Friends = GetFriends(data[3]),
            };
        }
        public static List<string> GetFriends(string field)
        {
            List<string> stringList = field.Split(';').ToList();
            return stringList;
            
        }

        public override string ToString()
        {
            return "User: " + Id + " " + FirstName + " " + LastName + " "+string.Join(";",Friends.ToArray());
        }

        public string[] FindUsersWithNthRelationship(int degree)
        {
            /*      * degree [type int] - if all second degree relationships are desired a 2 will be passed in      
             *      * return string[] - an array of type string which contains all Id's of users who are related to this user based on the given degree 
             *      */
            List<string> UsersWithNthRelationship = new List<string>();
            foreach (User user in users)
            {
                if (user.Friends.Count == degree)
                {
                    UsersWithNthRelationship.Add(user.Id);
                }
            }
            return UsersWithNthRelationship.ToArray();
        }

        public string[] FindUsersWithUser(string FirstName,string LastName)
        {
            /*      * FirstName [type string] -User's first name
             *      * LastName [type string] -User's last name
             *      * return string[] - an array of type string which contains all Id's of users who are related to this user based on the given first name, last name. 
             *      */
            List<string> UsersWithUser = new List<string>();
            string userId="";

            foreach (User user in users)
            {
                if (user.FirstName.Equals(FirstName) && user.LastName.Equals(LastName))
                {
                    userId = user.Id;
                }
            }

            foreach (User user in users)
            {
                if (user.Friends.Contains(userId))
                {
                    UsersWithUser.Add(user.Id);
                }
            }

            return UsersWithUser.ToArray();
        }

        public string[] FindUsersWithUserAndWithNthRelationship(string[] UsersWithNthRelationship, string[] UsersWithUser)
        {
            /*     * UsersWithNthRelationship [type string[] ] -User's Id list who has Nth relationship friends 
            *      * UsersWithUser [type string[] ] -User's Id list who has the friends based on the given user's first name and last name 
            *      * return string[] - an array of type string which contains all Id's of users who has both Nth relationship friends and the specific first name and last name friend. 
            *      */
            if (UsersWithNthRelationship == null || UsersWithUser == null)
            {
                return null;
            }

            List<string> list = GetAllSameElement(UsersWithNthRelationship, UsersWithUser);
            
            return list.ToArray();
        }

        public static List<string> GetAllSameElement(string[] strArr1, string[] strArr2)
        {
            /*    * strArr1 [type string[] ] -The first one array of string 
           *      * strArr2 [type string[] ] -The second one array of string
           *      * return List[string] - A list of string which are both in strArr1 and strArr2. 
           *      * if there are huge data, we need optimize the compare algorithm.
           *      */

            if (strArr1 == null || strArr2 == null)
            {
                return null;
            }
           
            List<string> strList1 = new List<string>(strArr1);
            List<string> strList2 = new List<string>(strArr2);

            return strList1.Intersect(strList2).ToList();
        }

    }
}
