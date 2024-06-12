using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
namespace BankoCheater
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Welcome to 'Johannes er gay', Cheats");
            string gamestate = "1Row";

            

            List<Plade> plates = new List<Plade>();

            plates.Add(new Plade(
                "Boris",
                new List<int> { 15, 41, 51, 71, 81 },
                new List<int> { 6, 18, 25, 34, 57 },
                new List<int> { 8, 19, 47, 59, 68 }
            ));

            plates.Add(new Plade(
                "Rasmus",
                new List<int> { 10, 31, 60, 70, 81 },
                new List<int> { 5, 27, 42, 52, 75 },
                new List<int> { 8, 19, 29, 55, 78 }
            ));

            plates.Add(new Plade(
                "Gustav",
                new List<int> { 1, 24, 31, 40, 70 },
                new List<int> { 7, 12, 25, 33, 87 },
                new List<int> { 19, 38, 43, 56, 67 }
            ));

            plates.Add(new Plade(
                "Johannes",
                new List<int> { 1, 14, 22, 70, 81 },
                new List<int> { 15, 26, 34, 72, 84 },
                new List<int> { 35, 49, 57, 68, 85 }
                ));

            

            DrawNumber("Please enter a number:");

            void DrawNumber(string message)
            {
                Console.WriteLine(message);
                int drawnNumber = 0;

                try
                {
                    drawnNumber = int.Parse(Console.ReadLine());
                    if (drawnNumber <= 0 || drawnNumber > 90)
                    {
                        DrawNumber("The number was out of range, please try a new one!");
                    }
                }
                catch (Exception ex)
                {
                    DrawNumber("That was not a number, please enter a real number: ");
                }


                foreach (Plade p in plates) { p.RemoveDrawnNumber(drawnNumber); }

                if (gamestate == "1Row")
                {
                    foreach (Plade plade in plates)
                    {
                        if (plade.CheckForOneRow())
                        {
                            gamestate = "2Rows";
                        }
                    }
                }
                else if (gamestate == "2Rows")
                {
                    foreach (Plade plade in plates)
                    {
                        if (plade.CheckForTowRows())
                        {
                            gamestate = "Full";
                        }
                    }       
                }
                else if (gamestate == "Full")
                {
                    foreach (Plade plade in plates)
                    {
                        if (plade.CheckForFullPlate())
                        {
                            gamestate = "Done";
                        }
                    }
                    
                }

                if (gamestate != "Done")
                {
                    DrawNumber("Please enter another number:");
                }
            }





        }
        public class Plade
        {
            public string Id { get; set; }
            public List<int> Row1 { get; set; }
            public List<int> Row2 { get; set; }
            public List<int> Row3 { get; set; }

            public Plade(string id, List<int> Row1, List<int> Row2, List<int> Row3)
            {
                this.Id = id;
                this.Row1 = Row1;
                this.Row2 = Row2;
                this.Row3 = Row3;
            }

            public void RemoveDrawnNumber(int number)
            {
                Row1.Remove(number);
                Row2.Remove(number);
                Row3.Remove(number);
            }

            public bool CheckForOneRow()
            {
                if (Row1.Count == 0 || Row2.Count == 0 || Row3.Count == 0)
                {
                    Console.WriteLine($"Banko med 1 række på plade: {Id}");

                    return true;
                }
                else { return false; }
            }


            public bool CheckForTowRows()
            {
                if ((Row1.Count == 0 && Row2.Count == 0) || (Row1.Count == 0 && Row3.Count == 0) || (Row2.Count == 0 && Row3.Count == 0))
                {
                    Console.WriteLine($"Banko med 2 rækker på plade: {Id}");

                    return true;
                }
                else { return false; }
            }
                public bool CheckForFullPlate()
            {
                if (Row1.Count == 0 && Row2.Count == 0 && Row3.Count == 0)
                {
                    Console.WriteLine($"Banko med fuld plade på plade: {Id}");

                    return true;
                }
                else { return false; }
            }
        }
    }

}
