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
                    // write file from data

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

                int i = 0;
                while (!sr.EndOfStream) 
                {
                    var row = sr.ReadLine();
                    var columns = row.Split('|');

                    grades[i] = columns[1];
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

