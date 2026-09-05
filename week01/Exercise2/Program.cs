
using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        // Variable to store the letter grade
        string letter;

        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the grade sign
        string sign;
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // There is no A+ grade
        if (letter == "A")
        {
            if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        // There are no F+ or F- grades
        if (letter == "F")
        {
            sign = "";
        }

        // Display the final letter grade and sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine whether the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time!");
        }
    }
}

