using System;
using System.IO;

namespace TestFinale
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = @"C:\Users\roberta.beretta\Documents\AcademyG\Week1.TestFinale\AcademyG.Week1.TestFinale",
                Filter = "spese.txt"
            };
            fsw.EnableRaisingEvents = true;
            fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | 
                NotifyFilters.DirectoryName | NotifyFilters.FileName;

            fsw.Created += GestoreSpesa.GestisciNuovaSpesa;

            Console.WriteLine("Premi q per uscire");
            while (Console.Read() != 'q') ;

        }
    }
}
