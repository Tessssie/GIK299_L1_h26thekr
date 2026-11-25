using System.Collections.Specialized;
using System.ComponentModel.Design;


namespace GIK299_labb_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sätter variabeln bool till true, programmet körs endast då.
            bool runProgram = true;

            //En while-loop som kommer köras så länge runProgram = true
            while (runProgram == true)
            {
                //Programmets meny.
                Console.WriteLine("Hej och välkommen till wind chill-kalkylatorn!\n\nVänligen välj något av dessa alternativ, svara med 1 eller 2:");
                Console.WriteLine();
                Console.WriteLine("\t1. Beräkna wind chill-temperatur.\n\t2. Avsluta.");
                string inputAnswer = Console.ReadLine();//En liten fördröjning till nästa utskrift.
                Console.WriteLine();//Tom rad för mer lättläst program.

                //En switch som väljer väg utifrån vad användaren har valt i menyn.
                switch (inputAnswer)
                {

                    case "1":
                        //En while-loop med TryParse.
                        //Om användaren skriver in ogiltig input.
                        bool validTemperature = false;
                        double outTemp = 0;
                        
                        while (!validTemperature)
                        {
                            Console.WriteLine("Skriv in vad temperaturen ute är, i Celsius tack:");
                            string inputTemp = Console.ReadLine();
                            Console.WriteLine();
                            Thread.Sleep(800);
                            validTemperature = double.TryParse(inputTemp, out outTemp);


                            if (!validTemperature)
                            {
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

                            Console.WriteLine("Nu kan du skriva in vindhastigheten:");
                            string inputWindSpeed = Console.ReadLine();
                            Console.WriteLine();
                            Thread.Sleep(800);
                            validWindSpeed = double.TryParse(inputWindSpeed, out windSpeed);

                            if (!validWindSpeed)
                            {
                                Console.WriteLine("Ogiltig inmatning, försök igen.");
                                Console.WriteLine();
                                Thread.Sleep(800);
                            }

                        }
                            Console.WriteLine();
                            Console.WriteLine("Skrev du i km/h eller m/s?");
                            string speedUnit = Console.ReadLine();
                            Thread.Sleep(800);
                            Console.WriteLine();
                            //Omvandlar svaren från string till double
                            //double outTemp = Double.Parse(inputTemp);
                            //double windSpeed = Double.Parse(inputWindSpeed);

                            //Om användaren svarat i m/s
                            if (speedUnit == "m/s")
                            {
                                windSpeed = windSpeed * 3.6;

                            }

                            // Räknar ut Math.Pow till windChillTemperature-formeln
                            double powWS = Math.Pow(windSpeed, 0.16);

                            // Wind chill-uträkningen
                            double windChillTemperature = 13.12 + 0.6215 * outTemp - 11.37 * powWS + 0.3965 * outTemp * powWS;

                            //Utskrift med resultatet
                            Thread.Sleep(800);
                            Console.WriteLine("Det är " + outTemp.ToString("F1") + "º ute och vinden blåser i " + windSpeed.ToString("F1") + " km/h.\nDetta betyder att wind chill-temperaturen är " + windChillTemperature.ToString("F1") + "º.");
                            Thread.Sleep(2000);
                            Console.WriteLine();

                            //Utskrift beroende på resultatet på windChillTemperature
                            if (windChillTemperature >= -25) // Lägg till om det är varmare ute!!!
                            { Console.WriteLine("\tKlassificering: Kallt"); }
                            else if (windChillTemperature < -25 && windChillTemperature >= -35)
                            { Console.WriteLine("\tKlassificering: Mycket kallt"); }
                            else if (windChillTemperature < -35 && windChillTemperature >= -60)
                            { Console.WriteLine("\tKlassificering: Risk för frostskada"); }
                            else
                            { Console.WriteLine("\tKlassificering: Stor risk för frostskada."); }
                            Thread.Sleep(5000);
                            Console.WriteLine();
                            break;
                    case "2":
                                runProgram = false;
                                Console.WriteLine("Tack och hej!");
                                Thread.Sleep(3000); //Låter programmet hållas öppet så användaren hinner se utskriften. 
                                break;

                            //Om användaren skriver in ett ogiltigt svar. Loopas tillbaka till menyn.
                            default:
                                runProgram = true;
                                Console.WriteLine("Du har skrivit in ett ogiltigt svar.");
                                Console.WriteLine();
                                Thread.Sleep(3000);//Låter programmet hållas öppet så användaren hinner se utskriften.
                                break;

                            }
                        }
                }
            }

        }





