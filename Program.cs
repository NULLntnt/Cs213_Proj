using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    public class bookClub
    {
        public List<string> Members = new List<string>();
        public List<int> Phone = new List<int>();
        public List<string> Email = new List<string>();
        public List<string> Books = new List<string>();
        public List<int> Pages = new List<int>();
        public List<string> Category = new List<string>();
        public bookClub()
        {
            int counter = 1, phone_pageNum; //Can't use readline to initilize a list, so read a subsitiute variable then add it to the list instead
            string names;
            Console.WriteLine("Creating a new group of at least 10 members\n");
            while (true)
            {
                int innerCounter = 1;
                Console.Write("Enter the name of the memeber: ");
                names = Console.ReadLine();
                Members.Add(names);
                Console.Write("Enter the mobile number of the memeber: ");
            checkpoint:
                try //Exception handling to prevent crashes in running the code
                {
                    phone_pageNum = Convert.ToInt32(Console.ReadLine());
                    Phone.Add(phone_pageNum);
                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message + "\nTry entering again");
                    goto checkpoint;
                }
                Console.Write("Enter the email of the memeber: ");
                names = Console.ReadLine();
                Email.Add(names);
                counter++;
                while (true)
                {

                    Console.Write("\nEnter a book read by the member: ");
                    names = Console.ReadLine();
                    Books.Add(names);
                    Console.Write("\nEnter number of pages of the book: ");
                checkpoint2:
                    try
                    {
                        phone_pageNum = Convert.ToInt32(Console.ReadLine());
                        Pages.Add(phone_pageNum);
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine(a.Message + "\nTry entering again");
                        goto checkpoint2;
                    }
                    Console.Write("\nEnter the category of the book: ");
                    names = Console.ReadLine();
                    Category.Add(names);
                    innerCounter++;
                    if (innerCounter > 5)
                    {
                        char choice;
                    label1:
                        Console.WriteLine("Do you wish to add another book? (Type Y to add, Type N to exit)");
                        try { choice = Console.ReadLine()[0]; }
                        catch (Exception x) { Console.WriteLine("Wrong input. Try again\n"); goto label1; }
                        if (choice == 'n' || choice == 'N')
                        {
                            Console.WriteLine("Books initilizing done.\n");
                            Books.Add("-");//Key character separating books for each memeber. For instance if I want to reach the books for the second memeber I'll look for the books between the first and second dash 
                            Pages.Add(-1);
                            Category.Add("-");
                            break;
                        }
                        else if (choice == 'y' || choice == 'Y')
                        {

                        }
                        else
                        {
                            Console.WriteLine("Wrong input, go again");
                            goto label1;
                        }
                    }
                }
                if (counter > 10)
                {
                    char choice;
                label2:
                    Console.WriteLine("Do you wish to add another memeber? (Type Y to add, Type N to exit)");
                    choice = Console.ReadLine()[0];
                    if (choice == 'n' || choice == 'N')
                    {
                        Console.WriteLine("Members initilizing done, now exiting.\n");
                        break;
                    }
                    else if (choice == 'y' || choice == 'Y')
                    { }
                    else
                    {
                        Console.WriteLine("Wrong input, go again");
                        goto label2;
                    }
                }
            }
        }
        public void groupStats()//Number of books read by the whole group members. Number of pages read by the whole group members
        {
            int pageSum = 0, bookSum = 0;
            Console.WriteLine("Number of books read by the group: ");
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i] == "-")
                    continue;
                bookSum++;
            }
            Console.WriteLine(bookSum + "\n");
            Console.WriteLine("Number of Pages read by the group: ");
            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[i] != -1)
                    pageSum += Pages[i];
            }
            Console.WriteLine(pageSum + "\n");
        }
        public void categoryRanks() //Ranking of books categories mostly read by the group members [show the
        {                          //number alongside the category in the ranked list].
            List<string> categoryTemp = new List<string>();
            for (int i = 0; i < Category.Count; i++)//Adding the categories to a substitute list
                categoryTemp.Add(Category[i]);
            while (categoryTemp.Contains("-"))
            {
                categoryTemp.Remove("-");
            }
            Console.WriteLine("<<Categories Ranks By Most Read>>");
            Console.WriteLine("Category\t\t|\t  Frequency");
            Console.WriteLine("--------------------------------------------------------------");
            while (categoryTemp.Count != 0)//Sort by most frequent
            {
                int countFreq = 0;
                string freqElement = "";
                for (int i = 0; i < categoryTemp.Count; i++)
                {
                    string tempFrequentElement = categoryTemp[i];
                    int tempFreqCount = 0;
                    for (int j = 0; j < categoryTemp.Count; j++)
                        if (categoryTemp[j] == tempFrequentElement)
                            tempFreqCount++;
                    if (tempFreqCount > countFreq)
                    {
                        freqElement = tempFrequentElement;
                        countFreq = tempFreqCount;
                    }
                }
                Console.WriteLine("{0,-24}|{1,14}", freqElement, countFreq);

                while (categoryTemp.Contains(freqElement))
                {
                    categoryTemp.Remove(freqElement);
                }
            }
        }
        public void membersRanksBasedOnBooksRead() //Ranking of group members based on number of books read[show the number
        {                                        //alongside the member’s name in the ranked list].
            List<int> numOfBooks = new List<int>();
            int booksForEachMember = 0;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i] == "-")
                {
                    numOfBooks.Add(booksForEachMember);
                    booksForEachMember = -1;
                }
                booksForEachMember++;
            }
            Console.WriteLine("\n<<Members Ranks Based on Most Books>>");
            Console.WriteLine("Memeber\t\t\t|\tNumber Of Books");
            Console.WriteLine("--------------------------------------------------------------");
            for (int j = 0; j < Members.Count; j++)
            {
                for (int i = 0; i < numOfBooks.Count; i++)
                {
                    if (numOfBooks[i] == numOfBooks.Max())
                    {
                        Console.WriteLine("{0, -24}|{1,14}", Members[i], numOfBooks[i]);
                        numOfBooks[i] = numOfBooks.Min() - 1;
                        break;
                    }
                }
            }
        }
        public void memebersRanksBasedOnPages() //Ranking of group members based on number of pages read [show the number
        {                                      //alongside the member’s name in the ranked list].
            List<int> numOfPages = new List<int>();
            int pagesForEachMember = 0;
            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[i] == -1)
                {
                    numOfPages.Add(pagesForEachMember);
                    pagesForEachMember = 0;
                    continue;
                }
                pagesForEachMember += Pages[i];
            }
            Console.WriteLine("\n<<Members Ranks Based on Most Pages read>>");
            Console.WriteLine("Member\t\t\t|\tNumber of Pages");
            Console.WriteLine("--------------------------------------------------------------");
            for (int i = 0; i < Members.Count; i++)
            {
                for (int j = 0; j < numOfPages.Count; j++)
                {
                    if (numOfPages[j] == numOfPages.Max())
                    {
                        Console.WriteLine("{0, -24}|{1,14}", Members[j], numOfPages[j]);
                        numOfPages[j] = numOfPages.Min() - 1;
                        break;
                    }
                }
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bookClub Group1 = new bookClub();//Every object of bookClub is a group of readers
            Group1.groupStats();
            Group1.categoryRanks();
            Group1.membersRanksBasedOnBooksRead();
            Group1.memebersRanksBasedOnPages();
        }
    }
}






23
    1