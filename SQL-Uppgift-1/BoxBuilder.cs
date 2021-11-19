using System;
using System.Data;
using System.Linq;

namespace SQL_Uppgift_1
{
    static class Box
    {
        public static void Simple(string[] rows)
        {
            string longestRow = rows.OrderByDescending(s => s.Length).First();

            Console.Write("┌");
            for (int i = 0; i < longestRow.Length; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("──┐");


            foreach (var line in rows)
            {
                Console.Write($"│ {line}");
                int spaces = longestRow.Length - line.Length;
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" │");
            }

            Console.Write("└");
            for (int i = 0; i < longestRow.Length; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("──┘");
        }

        public static void Table(DataTable dta, int lenght) //Skapar grafik åt tabellen där all data kan visas i ett rutnät.
                                                            //Teoretiskt oändligt många rows och columns kan skrivar ut. Längd på column baseras på längsta columntext
                                                            //Funkar inte om kollumerna är bredare än console window. Blir automatiskt radbyte då som bråkar med strukturen
        {
            int columnsWritten = 1;
            int rowsWritten = 0;
            int rowStartsWritten = 0;
            
            //Topp  Skriver ut "taket" baserat på hur många columns
            Console.Write("┌");
            foreach (DataColumn person in dta.Columns)
            {
                for ( int i= 0; i < lenght + 2; i++) // +2 iochmed att det finns mellanrum
                {
                    Console.Write("─");
                }
                
                if (columnsWritten != dta.Columns.Count)
                    Console.Write("┬");
                else 
                    Console.WriteLine("┐");
                columnsWritten++;
            }

            
            //Mitt  Skriver ut all data samt radbyte baserat på antal column och hur många rows.
            foreach (DataRow person in dta.Rows)
            {
                Console.Write("│ ");
                for (int i = 0; i < person.ItemArray.Length; i++)
                {
                    int spaces = lenght - person[i].ToString().Length;   //räknar ut hur mycket mellanrum det är kvar tills slutet av "boxen" så alla "boxar" blir lika stora
                    Console.Write(person[i]);
                    for (int s = 0; s < spaces; s++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" │ ");
                }
                Console.WriteLine();
          
                //Radbrytaren    separerar varje row samt skriver olika baserat på om det är sista row eller inte
                if (rowStartsWritten < dta.Rows.Count)
                {
                    if (rowStartsWritten < dta.Rows.Count-1) //*Vet inte varför jag har -1 här. Säkert pga hur långa strings jag skriver ut, så går säkert att ordna bort om man ändrar längd på vissa strings
                    {
                        Console.Write("├─");
                    }
                    else Console.Write("└─");
                    rowStartsWritten++;
                }

                columnsWritten = 1;

                //Radbrytning utfyllning
                for (int i = 0; i < person.ItemArray.Length; i++)   
                {
                    for (int l = 0; l < lenght; l++) 
                    {
                        Console.Write("─");
                    }

                    //Columnbrytning    Separerar columns samt skriver olika baserat på om det är sista row eller inte
                    if (columnsWritten < dta.Columns.Count)
                    {
                        if (rowsWritten < dta.Rows.Count -1)
                        {
                            Console.Write("─┼─");                            
                        }
                        else Console.Write("─┴─");
                        rowsWritten++;
                    }

                    //Radfyllning kant  Markerar slutet av radbrytningen samt skriver olika baserat på om det är sista row eller inte
                    else 
                    {
                        if (rowsWritten < dta.Rows.Count && dta.Rows.Count !=1)
                        {
                            Console.WriteLine("─┤");
                        }
                        else Console.WriteLine("─┘");

                    }
                    columnsWritten++;
                }
            }
        }
    }
}
