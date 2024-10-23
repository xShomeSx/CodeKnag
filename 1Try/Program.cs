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
                "11.");

            int Choice = Valid_Input(); // ValInp() könnte descriptiver benannt sein bspw GetValFromUserInp

            switch (Choice)
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
        }                                   

    }    

    #endregion

    #region GameVariations

    static void V1()
    {
        Console.WriteLine("Easy start, guess one time: ");
        int Choice = Valid_Input();
        int Secret_Number = 5;


        if (Choice != Secret_Number)
        {
            Console.WriteLine("Sorry, maybe next time");

        }
        else
        {

            Console.WriteLine("Well done!");

        }

        Restart_Or_Menu(V1); 
        Console.Clear();
    }
    static void V2()
    {

        Console.WriteLine("One try again, now i call if u were >< : ");
        int Choice = Valid_Input();
        int Secret_Number = 6;

        if (Choice < Secret_Number)
        {
            Console.WriteLine("Try a bit higher!");
        }
        else if (Choice > Secret_Number)
        {
            Console.WriteLine("Nah, its a bit to high!"); // "vergleichendes" too immer mit zwei o (too late, too much, ...)
        }
        else
        {
            Console.WriteLine("Well done!");
        }
        Restart_Or_Menu(V2);
        Console.Clear();

    }
    static void V3()
    {
        Console.WriteLine("Multiple tries from now on \n" +
            "guess: ");
        int Choice = Valid_Input();
        int Secret_Number = 7;

        while (Choice != Secret_Number)
        {

            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine("Great you did it!"); // theoretisch kann man hier auch das else streichen und den console output wie unten im kommentar nach der schleife einfügen, da diese ja sowieso mit success endet. ist letztendlich Geschmacksache und ich finde es auch schön wie hier alle möglichen outcomes zusammen zu haben
            }

            Choice = Valid_Input();

        }
        // wenn oben weggelassen, dann stattdessen hier nach ende der schleife
        // Console.WriteLine("Great you did it!");
        Restart_Or_Menu(V3);
        Console.Clear();

    }
    static void V4()
    {

        Console.WriteLine("Multiple tries from now on with counter \n" +
                   "guess: ");
        int Choice = Valid_Input();
        int Secret_Number = 10;
        int Counter = 1;

        while (Choice != Secret_Number)
        {
            Counter++;
            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }



            Choice = Valid_Input();


        }

        Counter++; // statt hier beim richtigen guess um eins zu erhöhen, damit die Anzahl stimmt, könnte man auch oben mit int counter = 1; starten. Erneut Geschmacksache aber spart theoretisch ne Zeile I guess

        if (Counter == 1)
        {
            Console.WriteLine("WoW you needed only " + Counter + " try!"); // da counter hier sowieso immer 1 ist, kann man auch einfach fix ne eins in den string schreiben, dann hat man nur "string" statt "string" + counter + "string"
        }
        else
        {
            Console.WriteLine("Great u needed " + Counter + " tries!");
        }

        Restart_Or_Menu(V4);
        Console.Clear();

    }
    static void V5()
    {
        Console.WriteLine("Randomized Number from now on! \n" +
                           "guess: ");
        int Choice = Valid_Input();
        int Secret_Number = new Random().Next();
        int Counter = 1;

        while (Choice != Secret_Number)
        {
            Counter++;
            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }



            Choice = Valid_Input();


        }


        if (Counter == 1)
        {
            Console.WriteLine("WoW you needed only " + Counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + Counter + "tries!");
        }

        Restart_Or_Menu(V5);
        Console.Clear();
    }
    static void V6()
    {
        Console.WriteLine("choose your wished range! \n" + 
                           "1. 1-100 \n" +
                           "2. 100-200 \n" +
                           "3. 1-1000 ");
        Random RandomNumber = new Random();
        int Choice = Valid_Input();
        int Secret_Number = 0;
        int Counter = 1;


        switch (Choice)
        {
            case 1:
                {
                    Console.WriteLine("chosen range: 1-100");
                    Secret_Number = RandomNumber.Next() % 100 + 1;
                }
                break;
            case 2:
                {
                    Console.WriteLine("choosen range: 100-200");
                    Secret_Number = RandomNumber.Next() % 100 + 100;
                }
                break;
            case 3:
                {
                    Console.WriteLine("choosen range: 1-1000");
                    Secret_Number = RandomNumber.Next() % 1000 + 1;
                }
                break;
            default:
                {

                }
                break;
        }

        Valid_Input(); // Was passiert hier? ValInp() wird aufgerufen und der Wert nirgendwo verwendet. Ich nehme an da sollte ein `choice =` vor?
        while (Choice != Secret_Number)
        {
            Counter++;
            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }



            Choice = Valid_Input();


        }

        

        if (Counter == 1)
        {
            Console.WriteLine("WoW you needed only " + Counter + "try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + Counter + "tries!");
        }

        Restart_Or_Menu(V6);
        Console.Clear();

    }
    static void V7()
    {
        int Upper_Bound; // bound nicht mit bond verwechseln
        int Lower_bound;
        Console.WriteLine("you set the range to guess! \n" +
                           "upper bond: ");
        Upper_Bound = Valid_Input();
        Random RandomNumber = new Random();
        Console.WriteLine("lower bond: ");
        Lower_bound = Valid_Input();
        Console.WriteLine("now guess: ");
        int Choice = Valid_Input();
        int Secret_Number = RandomNumber.Next(Lower_bound, Upper_Bound + 1);
        int Counter = 1;


        while (Choice != Secret_Number)
        {
            Counter++;
            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }



            Choice = Valid_Input();


        }

        
        if (Counter == 1)
        {
            Console.WriteLine("WoW you needed only " + Counter + " try!");
        }
        else
        {
            Console.WriteLine("Great u needed " + Counter + " tries!");
        }

        Restart_Or_Menu(V5);
        Console.Clear();

    }
    static void V8()
    {
        Random RandomNumber = new Random();
        Console.WriteLine("Ill rate your tries, range is 1000-10000! \n" +
                            "guess: ");
        int Choice = Valid_Input();
        int Secret_Number = RandomNumber.Next() % 10000 + 1000 + 1;
        int Counter = 1;

        while (Choice != Secret_Number)
        {
            Counter++;
            if (Choice < Secret_Number)
            {
                Console.WriteLine("its too low!");
            }
            else if (Choice > Secret_Number)
            {
                Console.WriteLine("Too high!");
            }



            Choice = Valid_Input();


        }


        if (Counter < 14)
        {
            Console.WriteLine("WoW you only needed " + Counter + " tries!");
        }
        else if (Choice > 14)
        {
            Console.WriteLine("Nah its ok but maybe there is a better tactic? you needed " + Counter + " tries!");
        }
        else if (Choice == 13 || Counter == 14)
        {
            Console.WriteLine("Good job you needed " + Counter + " tries! Thats pretty good!");
        }

        Restart_Or_Menu(V5);
        Console.Clear();
    }
    static void V9()
    {
        Console.Clear();
    }

    #endregion

    #region utils

    static int Valid_Input()
    {
        int User_Input = 0;
        bool valid_input = false; // kann man so benennen, auf lange Sicht un mit mehr unterschiedlichen Leuten lohnt es sich längere deskriptivere Namen zu verwenden (bspw. isValidInput) [naming conventions bei bool oft beginnend mit "is", "has", ... und quasi als Frage formuliert die man mit TRUE/FALSE beantworten würde]

        while (!valid_input)
        {
            try
            {

                User_Input = Convert.ToInt32(Console.ReadLine()); // hier könnte man input nehmen und in Int konvertieren aufsplitten für bessere lesbarkeit und leichtere Fehlersuche
                /*
                string rawInput = Console.ReadLine(); // vor try block
                try
                {
                    uinp = Convert.ToInt32(rawInput)
                */
                valid_input = true;

            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid Input!");

            }
        }
        return User_Input;
    }

    static void Restart_Or_Menu(Action restartVersion)
    {
        Console.WriteLine("Restart (r)\n" +
            "go to MainMenu? (m)\n" +
            "End Game (e)");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (choice == 'r')
        {
            Console.Clear();
            restartVersion(); // die Idee ist cool, schön umgesetzt die Funktion als Action mitzugeben und aufzurufen
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
            Restart_Or_Menu(restartVersion); // kann man auf jeden fall so machen. Das Fachwort hier ist Rekursion, also Code der sich (unter bestimmten Bedingungen) selbst aufruft.
            // Rekursion wird neben Benutzerinteraktion wie hier oft verwendet um algorithmen recheneffizient aufzubauen bspw bei Sortieralogrithmen wie QuickSort
        }
    }

    #endregion
}
#endregion
