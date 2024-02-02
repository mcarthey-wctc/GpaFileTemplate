using System;
using System.IO;

namespace CourseGPAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "courseData.txt";
            string choice;

            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    var grades = ReadFile(file);
                    CalculateGrades(grades);

                }
                else if (choice == "2")
                {
                    // TODO: ADD LOOP
                    // TODO: BREAK INTO METHODS
                    // write file from data
                    StreamWriter sw = new StreamWriter(file, true);

                    Console.WriteLine("Enter a course (Y/N)?");
                    var response = Console.ReadLine().ToUpper();

                    if (response != "Y") { break; }

                    Console.WriteLine("Enter the course name.");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the course grade.");
                    string grade = Console.ReadLine().ToUpper();

                    sw.WriteLine("{0}|{1}", name, grade);

                    sw.Close();
                } 


            } while (choice == "1" || choice == "2");

        }

        private static void CalculateGrades(string[] grades)
        {
            int gradePoints = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                gradePoints += grades[1] == "A" ? 4 : grades[1] == "B" ? 3 : grades[1] == "C" ? 2 : grades[1] == "D" ? 1 : 0;
            }

            double GPA = (double)gradePoints / grades.Length;
            Console.WriteLine("GPA: {0:N2}", GPA);
        }

        private static string[] ReadFile(string file)
        {
            string[] grades = new string[5];
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                sr.ReadLine(); // skip first line (i.e. headers in file)

                int i = 0;
                while (!sr.EndOfStream) 
                {
                    var row = sr.ReadLine();
                    var columns = row.Split(',');

                    var courseName = columns[0];
                    var grade = columns[1];

                    //var watching = columns[6]; // Drew Kjell|John Smith|Bill Jones
                    //var watchers = watching.Split('|');

                    grades[i] = grade;
                    Console.WriteLine(grades[i]);
                    i++;
                }

            }
            else
            {
                Console.WriteLine("File does not exist!");
            }

            return grades;
        }
    }
}

