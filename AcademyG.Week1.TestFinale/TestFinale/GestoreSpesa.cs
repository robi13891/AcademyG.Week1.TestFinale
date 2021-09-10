using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFinale.Handler;

namespace TestFinale
{
    public class GestoreSpesa
    {
        static List<Spesa> speseDaGestire = new List<Spesa>();
        static List<Spesa> speseApprovate = new List<Spesa>()
        {
            new Spesa
            {
                Data = new DateTime(2021,05,19),
                Categoria = "Alloggio",
                Descrizione = "due notti in albergo",
                Importo = 120,
                IsApproved = true,
                LivelloApprovazione = "Manager",
                ImportoRimborsato = 120

            },
            new Spesa
            {
                Data = new DateTime(2021,08,09),
                Categoria = "Alloggio",
                Descrizione = "una notti in albergo",
                Importo = 75,
                IsApproved = true,
                LivelloApprovazione = "Manager",
                ImportoRimborsato = 75

            }
        };
        static List<Spesa> speseNonApprovate = new List<Spesa>()
        {
            new Spesa
            {
                Data = new DateTime(2021,08,09),
                Categoria = "Alloggio",
                Descrizione = "un mese in albergo",
                Importo = 3000,
                IsApproved = false,
                LivelloApprovazione = "",
                ImportoRimborsato = 0

            }
        };
        static string path2 = @"C:\Users\roberta.beretta\Documents\AcademyG\Week1.TestFinale\spese_elaborate.txt";

        public static void GestisciNuovaSpesa(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Gestione dell'evento {e.ChangeType} sul file {e.Name}");
            LeggiSpesa(e);
            ApprovaSpesa();
            GestioneSpesaApprovata();
            ScriviSpesa();

        }

        private static void GestioneSpesaApprovata()
        {
            RimborsoFactory factory = new RimborsoFactory();
            foreach (Spesa spesa in speseApprovate)
            {
                factory.NuovoRimborso(spesa);
            }
        }

        private static void ApprovaSpesa()
        {

            IHandler manager = new ManagerHandler();
            IHandler operationalManager = new OperationalManagerHandler();
            IHandler ceo = new CEOHandler();

            manager.SetNext(operationalManager).SetNext(ceo);

            foreach (Spesa spesa in speseDaGestire)
            {
                Spesa spesaGestita = manager.Handle(spesa);

                if (spesaGestita.IsApproved == true)
                {
                    speseApprovate.Add(spesaGestita);
                    Console.WriteLine("Spesa gestita correttamente");
                }
                else if (spesaGestita.IsApproved == false)
                {
                    speseNonApprovate.Add(spesaGestita);
                    Console.WriteLine($"Spesa non approvata per importo superiore alla soglia");
                }

            }

        }

        private static void LeggiSpesa(FileSystemEventArgs e)
        {
            try
            {
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    Console.WriteLine($"Lettura del file {e.Name} in corso");
                    string header = reader.ReadLine();
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        var dati = line.Split(";");
                        Spesa spesa = new Spesa();
                        spesa.Data = DateTime.Now;
                        spesa.Categoria = dati[1];
                        spesa.Descrizione = dati[2];
                        spesa.Importo = double.Parse(dati[3]);
                        speseDaGestire.Add(spesa);
                        line = reader.ReadLine();
                    };



                    Console.WriteLine("\nFine del file");
                }


            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ScriviSpesa()
        {

            try
            {
                using (StreamWriter writer = new StreamWriter(path2, false))
                {

                    writer.WriteLine("Data\t\tCategoria\t\tDescrizione\t\tStato\t\tLvl Approvazione\tImporto Rimborsato");


                    foreach (Spesa spesa in speseApprovate)
                    {
                        writer.WriteLine("{0,10}{1,10}{2,30}{3,20}{4,20}{5,20}", spesa.Data.ToString("yyyy-MM-dd"), spesa.Categoria,
                            spesa.Descrizione, "APPROVATA", spesa.LivelloApprovazione, spesa.ImportoRimborsato);
                    }
                    foreach (Spesa spesa in speseNonApprovate)
                    {
                        writer.WriteLine("{0,10}{1,10}{2,30}{3,20}{4,20}{5,20}", spesa.Data.ToString("yyyy-MM-dd"), spesa.Categoria,
                            spesa.Descrizione, "RESPINTA", "-", "-");
                    }
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
