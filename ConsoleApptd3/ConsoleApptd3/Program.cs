using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "Etudiants.txt";

        while (true)
        {
            Console.WriteLine("Choisissez une option :");
            Console.WriteLine("1. Lister les renseignements du fichier.");
            Console.WriteLine("2. Lister les renseignements du fichier en format spécifié.");
            Console.WriteLine("3. Calcul statistique.");
            Console.WriteLine("4. Quitter.");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ListStudents(filePath);
                        break;
                    case 2:
                        ListStudentsFormatted(filePath);
                        break;
                    case 3:
                        CalculateStatistics(filePath);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez entrer 1, 2, 3 ou 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez entrer 1, 2, 3 ou 4.");
            }
        }
    }

    static void ListStudents(string filePath)
    {
        Console.Clear();
        Console.WriteLine("Liste des étudiants :");
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }

        Console.WriteLine();
    }

    static void ListStudentsFormatted(string filePath)
    {
        Console.Clear();
        Console.WriteLine("Liste des étudiants formatée :");
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(';'); // Supposons que les données sont séparées par des points-virgules (;)
            string formattedLine = $"{data[0].ToUpper()} {data[1]} {FormatDate(data[2])} {data[3]} {data[4]}";

            Console.WriteLine(formattedLine);
        }

        Console.WriteLine();
    }

    static string FormatDate(string date)
    {
        DateTime parsedDate;
        if (DateTime.TryParse(date, out parsedDate))
        {
            return parsedDate.ToString("dddd dd MMMM yyyy");
        }
        return date; // Retourne la date non formatée si la conversion échoue.
    }

    static void CalculateStatistics(string filePath)
    {
        Console.Clear();
        string[] lines = File.ReadAllLines(filePath);

        int totalStudents = lines.Length;
        int maleStudents = lines.Count(line => line.Split(';')[3].Trim().ToLower() == "masculin");
        int femaleStudents = totalStudents - maleStudents;

        double malePercentage = (double)maleStudents / totalStudents * 100;
        double femalePercentage = 100 - malePercentage;

        Console.WriteLine($"Nombre d'étudiants de sexe Masculin : {maleStudents} Hommes soit {malePercentage:F2}% des étudiants");
        Console.WriteLine($"Nombre d'étudiants de sexe Féminin : {femaleStudents} Femmes soit {femalePercentage:F2}% des étudiants");
        Console.WriteLine($"Nombre total d'étudiants : {totalStudents}");

        Console.WriteLine();
    }
}
