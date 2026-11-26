using System.Collections.Specialized;
using System.ComponentModel.Design;


namespace GIK299_labb_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ Wind Chill-kalkylator ~~~~~~~~~~~~~~~~~~~~");

            bool runProgram = true;

            //En while-loop som kommer köras tills användaren avslutar programmet
            while (runProgram == true)
            {
                //Programmets meny.
                Console.ForegroundColor = ConsoleColor.Cyan; //Trevlig färg på texten.
                Console.WriteLine("Vänligen välj något av dessa alternativ, svara med 1 eller 2:");
                Console.WriteLine();
                Console.WriteLine("\t1. Beräkna wind chill-temperatur.\n\t2. Avsluta.");
                string inputAnswer = Console.ReadLine();
                Console.WriteLine();//Tom rad för mer lättläst program.

                //En switch som väljer väg utifrån vad användaren har valt i menyn.
                switch (inputAnswer)
                {

                    case "1":
                        
                        bool validTemperature = false;
                        double outTemp = 0;

                        //En while-loop med TryParse för att kontrollera
                        //om användaren skriver in ogiltig input.
                        while (!validTemperature)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Skriv in vad temperaturen ute är, i Celsius tack:");
                            string inputTemp = Console.ReadLine();
                            Console.WriteLine();
                            Thread.Sleep(800); //Liten fördröjning till nästa utskrift
                            validTemperature = double.TryParse(inputTemp, out outTemp);


                            if (!validTemperature)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ogiltig inmatning, försök igen.");
                                Console.WriteLine();
                                Thread.Sleep(800);
                            }
                        }

                        //En while-loop med TryParse.
                        //Om användaren skriver in ogiltig input.
                        bool validWindSpeed = false;
                        double windSpeed = 0;

                        while (!validWindSpeed)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Nu kan du skriva in vindhastigheten, gärna km/h:");
                            string inputWindSpeed = Console.ReadLine();
                            Console.WriteLine();
                            Thread.Sleep(800);
                            validWindSpeed = double.TryParse(inputWindSpeed, out windSpeed);

                            if (!validWindSpeed)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ogiltig inmatning, försök igen.");
                                Console.WriteLine();
                                Thread.Sleep(800);
                            }

                        }

                        string speedUnit = "x";

                        //En while-loop för att kontrollera att användaren skriver in km/h eller m/s.
                        while (speedUnit != "km/h" && speedUnit != "m/s")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Skrev du i km/h eller m/s?");
                            speedUnit = Console.ReadLine();
                            Console.WriteLine();
                            Thread.Sleep(800);
                            
                            if (speedUnit != "km/h" && speedUnit != "m/s")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ogiltig inmatning, försök igen.");
                                Console.WriteLine();
                                Thread.Sleep(800);
                            }
   
                        }
                        //Beräkning till km/h om användaren skrivit in m/s.
                        if (speedUnit == "m/s")
                        {
                            windSpeed = windSpeed * 3.6;

                        }

                        // Räknar ut Math.Pow till windChillTemperature-formeln
                        double powWindSpeed = Math.Pow(windSpeed, 0.16);

                        /* DEBUG! Breakpoint på raden nedanför Wind chill-uträknings kommentaren.
                         * Använder T = - 15, V = 10 m/s.
                         * Locals innan F10: windSpeed = 36. outTemp = -10
                         * Locals efter F10: windChillTemperature = -26,9
                         * Reflektion: Skrev in 10 m/s och programmet räknade ut vindhastigheten
                         * till 36 km/h vilket är rätt.
                         * Det är ett bra sätt att se att beräkningen
                         * blir korrekt. I det här fallet känns resultatet rimligt.
                         */

                        // Wind chill-uträkningen
                        double windChillTemperature = 13.12 + 0.6215 * outTemp - 11.37 * powWindSpeed + 0.3965 * outTemp * powWindSpeed;

                        //Utskrift med resultatet
                        Console.WriteLine("Det är " + outTemp.ToString("F1") + "º ute och vinden blåser i " + windSpeed.ToString("F1") + " km/h.\nDetta betyder att wind chill-temperaturen är " + windChillTemperature.ToString("F1") + "º.");
                        Thread.Sleep(800);
                        Console.WriteLine();

                        //Utskrift beroende på resultatet på windChillTemperature
                        if (windChillTemperature >= -25)
                        { Console.WriteLine("\tKlassificering: Kallt"); }

                        else if (windChillTemperature < -25 && windChillTemperature >= -35)
                        { Console.WriteLine("\tKlassificering: Mycket kallt"); }

                        else if (windChillTemperature < -35 && windChillTemperature >= -60)
                        { Console.WriteLine("\tKlassificering: Risk för frostskada"); }

                        else
                        { Console.WriteLine("\tKlassificering: Stor risk för frostskada."); }

                        Thread.Sleep(3000);
                        Console.WriteLine();
                        Console.WriteLine();

                        break;

                    case "2":
                        runProgram = false;
                        Console.WriteLine("Tack och hej!");
                        Thread.Sleep(3000); //Låter programmet hållas öppet så användaren hinner se utskriften. 
                        break;

                    //Om användaren skriver in ett ogiltigt svar. Loopas tillbaka till menyn.
                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ogiltig inmatning, försök igen.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Thread.Sleep(800);
                        break;     
                }
            }
        }
    }
}





