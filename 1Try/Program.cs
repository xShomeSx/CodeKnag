
#region used Packs
using System;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;
using System.Xml.Serialization;
#endregion

#region Running what?
class Programm      //Klasse   (Was gibt es für Klassen außer Programme?)
{
    
    #region EinstiegsVoid

    static void Main()
    {

        bool keepPlaying = true;                                 // WahrFalsch Wert für Weiterspielen Schleife

        while (keepPlaying)                                   
        {
            Console.WriteLine("Welcome to CodeKnagger!\n" +
                "Number Guessing in different Variations\n" +
                "Choose: \n" +
                "1. One try, just Right or False \n" +
                "2. Again only one guess now with call ><. \n" +
                "3. Multiple tries from now on \n" +
                "4. I count your tries! \n" +
                "5. Randomized Number \n" +
                "6. 3 different ranges (Modulo Operator) \n" +
                "7. Set the range yourself. \n" +
                "8." +
                "9." +
                "10." +
                "11." );

            int choice = ValInp(); // ValInp() könnte descriptiver benannt sein bspw GetValFromUserInp

            switch (choice)
            {
                case 1:
                    V1();
                    break; // einige breaks waren nicht eingerückt
                case 2:
                    V2();
                    break;
                case 3:
                    V3();
                    break;
                case 4:
                    V4();
                    break;
                case 5:
                    V5();
                    break;
                case 6:
                    V6();
                    break;
                case 7:
                    V7();
                    break;
                case 8:
                    V8();
                    break;
                case 9:
                    V9();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please choose a valid option! Press any button to retry.");
                    Console.ReadLine();
                    Console.Clear();
                    break;

            }
        }                                   // Weiterspielschleife

    }    //Auswahlmenü

    #endregion

    #region GameVariations

    static void V1()
    {
        Console.WriteLine("Easy start, guess one time: ");
        int choice = ValInp(); // Schön die input abfrage und validierung ausgelagert und wiederverwendet um redundanten code zu vermeiden
        int secnum = 5; // variablen Benennung mit mehreren wörtern je nach naming convention entweder CamelCase oder snake_case um leichter wörter zu trennen und lesbarkeit zu erhöhen bzw verwechselungen zu vermeiden


        if (choice != secnum)
        {
            Console.WriteLine("Sorry, maybe next time");
           
        }
        else
        {

            Console.WriteLine("Well done!");

        }

        RestartorMenu(V1); // hier auch naming convention consistent halten (RestartOrMenu)
        Console.Clear();
    }
    static void V2()
    {

        Console.WriteLine("One try again, now i call if u were >< : ");
        int choice = ValInp();
        int secnum = 6;

        if (choice < secnum)
        {
            Console.WriteLine("Try a bit higher!");
        }
        else if (choice > secnum)
        {
            Console.WriteLine("Nah, its a bit to high!"); // "vergleichendes" too immer mit zwei o (too late, too much, ...)
        }
        else
        {
            Console.WriteLine("Well done!");
        }
        RestartorMenu(V2);
        Console.Clear();

    }
    static void V3()
    {
        Console.WriteLine("Multiple tries from now on \n" +
            "guess: ");
        int choice = ValInp();
        int secnum = 7;
        
        while (choice != secnum)
        {

            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }        
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine("Great you did it!");
            }

            choice = ValInp();
            
        }

        RestartorMenu (V3);
        Console.Clear();

    }
    static void V4()
    {

        Console.WriteLine("Multiple tries from now on with counter \n" +
                   "guess: ");
        int choice = ValInp();
        int secnum = 10;
        int counter = 0;

        while (choice != secnum)
        {
            counter++;
            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }
            
            

            choice = ValInp();
            

        }

        counter++;

        if (counter == 1) 
        {
            Console.WriteLine("WoW you needed only " + counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed "+ counter + "tries!");
        }
            
        RestartorMenu(V4);
        Console.Clear();

    }
    static void V5()
    {
        Console.WriteLine("Randomized Number from now on! \n" +
                           "guess: ");
        int choice = ValInp();
        int secnum = new Random().Next();
        int counter = 0;

        while (choice != secnum)
        {
            counter++;
            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }



            choice = ValInp();


        }

        counter++;

        if (counter == 1)
        {
            Console.WriteLine("WoW you needed only " + counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + counter + "tries!");
        }

        RestartorMenu(V5);
        Console.Clear();
    }
    static void V6()
    {
        Console.WriteLine("choose your wished range! \n" +
                           "1. 1-100 \n" +
                           "2. 100-200 \n" +
                           "3. 1-1000 ");
        Random random = new Random();
        int choice = ValInp();
        int secnum = 0;                       
        int counter = 0;


        switch (choice)
        {
            case 1:
                {
                    Console.WriteLine("chosen range: 1-100");
                    secnum = random.Next() % 100 + 1;
                }
            break;
            case 2:
                {
                    Console.WriteLine("choosen range: 100-200");
                    secnum = random.Next() % 100 + 100;
                }
            break;
            case 3:
                {
                    Console.WriteLine("choosen range: 1-1000");
                    secnum = random.Next() % 1000 + 1;
                }
            break;
            default:
            {

            }
            break;
        }

        ValInp();
        while (choice != secnum)
        {
            counter++;
            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }



            choice = ValInp();


        }

        counter++;

        if (counter == 1)
        {
            Console.WriteLine("WoW you needed only " + counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + counter + "tries!");
        }

        RestartorMenu(V6);
        Console.Clear();

    }
    static void V7()
    {
        int upperbond;
        int lowerbond;
        Console.WriteLine("you set the range to guess! \n" +
                           "upperbond: ");
        upperbond = ValInp();
        Random random = new Random();
        Console.WriteLine("lower bond: ");
        lowerbond = ValInp();
        Console.WriteLine("now gues: ");
        int choice = ValInp();
        int secnum = random.Next(lowerbond, upperbond + 1);
        int counter = 0;
        

        while (choice != secnum)
        {
            counter++;
            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }



            choice = ValInp();


        }

        counter++;

        if (counter == 1)
        {
            Console.WriteLine("WoW you needed only " + counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + counter + "tries!");
        }

        RestartorMenu(V5);
        Console.Clear();
 
    }
    static void V8()
    {
       Random random = new Random();
        Console.WriteLine("Ill rate your tries, range is 1000-10000! \n" +
                            "guess: ");
        int choice = ValInp();
        int secnum = random.Next() % 10000 + 1000 + 1;
        int counter = 0;

        while (choice != secnum)
        {
            counter++;
            if (choice < secnum)
            {
                Console.WriteLine("its too low!");
            }
            else if (choice > secnum)
            {
                Console.WriteLine("Too high!");
            }



            choice = ValInp();


        }

        counter++;

        if (counter < 14)
        {
            Console.WriteLine("WoW you only needed " + counter + "tries!");
        }
        else if (choice > 14)
        {
            Console.WriteLine("Nah its ok but maybe there is a better tactic? you needed" + counter + "tries!");
        }
        else if (choice == 13 || counter == 14)
        {
            Console.WriteLine("Good job you needed " + counter + "tries! Thats pretty good!");
        }

        RestartorMenu(V5);
        Console.Clear();
    }
    static void V9()
    {
        Console.Clear();
    }

    #endregion

    #region dependencies

    static int ValInp()
    {
        int uinp = 0;
        bool vinp = false; // kann man so benennen, auf lange Sicht un mit mehr unterschiedlichen Leuten lohnt es sich längere deskriptivere Namen zu verwenden (bspw. isValidInput) [naming conventions bei bool oft beginnend mit "is" und quasi als Frage formuliert die man mit TRUE/FALSE beantworten würde]

        while (!vinp)
        {
            try
            {

                uinp = Convert.ToInt32(Console.ReadLine()); // hier könnte man input nehmen und in Int konvertieren aufsplitten für bessere lesbarkeit und leichtere Fehlersuche
                /*
                string rawInput = Console.ReadLine(); // vor try block
                try
                {
                    uinp = Convert.ToInt32(rawInput)
                */ 
                vinp = true;

            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid Input!");

            }
        }
        return uinp;
    }

    static void RestartorMenu(Action restartVersion)
    {
        Console.WriteLine("Restart (r)\n" +
            "go to MainMenu? (m)\n" +
            "End Game 'e'");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (choice == 'r')
        {
            Console.Clear();
            restartVersion();
        }
        else if (choice == 'm')
        {
            Console.Clear();
            return;
        }
        else if (choice == 'e')
        {
            Console.Clear();
            Environment.Exit(0);
            Console.WriteLine("Until next time!");
        }
        else
        {
            Console.WriteLine("Invalid input please use 'r','m' or 'e'");
            RestartorMenu(restartVersion);
        }
    }

    #endregion
}
#endregion
