using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Address Book ADO");
            AddressRepo Repo = new AddressRepo();
          //  Repo.CheckConnection();
            AddressBookModel Add = new AddressBookModel();
            /*Add.first_name = "Pratibha";
            Add.last_name = "Karande";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = "400701";
            Add.phone_number = "9987936149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Friend";*/
            // Repo.AddContacts(Add);
            // Console.WriteLine("**********Inserted Record**********");
            // Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Add.first_name, Add.last_name, Add.address, Add.city, Add.state, Add.zip, Add.phone_number, Add.addressBook_Name, Add.addressBook_Type);
            // Repo.EditRecordUsingName(Add);
            // Add.first_name = "Pratibha";
            // Repo.DeleteContact(Add);
            // Repo.RetriveRecord();
            //Repo.CountByCityState();
            //Repo.SortRecord();
            //Repo.CountByPerson();
            /* int count =  Repo.RetriveAllRecord();
             Console.WriteLine(count);
 */
            /*Add.last_name = "rane";
            Add.first_name = "Nilesh";
           string name = Repo.UpdateContact(Add);*/

            int count = Repo.getEmployeeDataWithGivenRange();
            Console.WriteLine(count);

            /*int count = Repo.RetrivePersonsBelongingCityOrState();
            Console.WriteLine(count);*/
            /*Add.addressBook_id = 103;
            Add.first_name = "Pratibha";
            Add.last_name = "Mastud";
            Add.address = "Seawoods";
            Add.city = "Mumbai";
            Add.state = "Maharashtra";
            Add.zip = 400701;
            Add.phone_number = "9676736149";
            Add.addressBook_Name = "ABNameFriend";
            Add.addressBook_Type = "Family";
            Add.address_id = 103;
            bool count = Repo.AddNewContacts(Add);
            Console.WriteLine(count);*/

            Console.WriteLine("Employee payroll using thread ");
            string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Being first task");
                GetLongestWord(words);
            },
            () =>
            {
                GetMostCommonWords(words);
            },
            () =>
            {
                GetCountForWord(words, "sleep");
            }
            );

            #endregion
        }

        private static void GetCountForWord(string[] words, string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine($"Task 3 ----------the word ''''{term}'''' occors { findWord.Count()} times.");
        }

        private static void GetMostCommonWords(string[] words)
        {
            var orderfrequency = from word in words where word.Length > 6 group word by word into g orderby g.Count() descending select g.Key;
            var commonWords = orderfrequency.Take(30);
            StringBuilder strb = new StringBuilder();
            strb.Append("Task 2 is The most common word are");
            foreach (var v in commonWords)
            {
                strb.AppendLine(" " + v);

            }
            Console.WriteLine(strb.ToString());
        }
        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words orderby w.Length descending select w).First();
            Console.WriteLine($"Task 1 ----The longest word is { longestWord}");
            return longestWord;
        }

        static string[] CreateWordArray(string url)
        {
            Console.WriteLine($"Retriving from{url}");
            string blog = new WebClient().DownloadString(url);
            return blog.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}