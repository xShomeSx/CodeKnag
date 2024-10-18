#region Program
class Program
{
    
    #region Main
    static void Main()
    {

        while (true) // infinite loop -> exit condition in ShowRestartOrMenuChoice                                   
        {

            Console.WriteLine( // multiline string because its sexier than a bunch of + signs and \n line breaks
                """
                Welcome to CodeKnagger!
                A number guessing game in different Variations.

                Type the number of your chosen variant and confirm with 'Enter':
                    1.  One try, just Right or False
                    2.  Again only one guess now with call > <
                    3.  Multiple tries from now on
                    4.  I count your tries!
                    5.  Randomized Number
                    6.  3 different ranges (Modulo Operator)
                    7.  Set the range yourself
                    8.  I rate your total attempts, range is 1000-10000
                    9.  I rate your total attempts, set the range yourself
                    10. You choose a range and think of a number for me to guess
                """
            );

            int userChoice = getValidIntFromUserInput();

            switch (userChoice)
            {
                case 1:
                    V1();
                    break;
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
                case 10:
                    V10();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please choose a valid option! Press any button to retry.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

            }
        }
    }

    #endregion

    #region GameVariations

    static void V1()
    {
        // declare un-initialized variables first
        int userGuessInt; // technically we could declare this upon initialization, but declaring all relevant variables at the top makes it more readable

        //declare initialized variables first
        int correctNumberToGuess = 5;

        // now we can take care of the logic
        Console.WriteLine("Simple start, guess once:\n");
        userGuessInt = getValidIntFromUserInput();
        
        if (userGuessInt != correctNumberToGuess)
        {
            Console.WriteLine("Sorry, maybe next time");
        }
        else
        {
            Console.WriteLine("Well done!\n");
        }

        ShowRestartOrMenuChoice(V1);
    }
    static void V2()
    {
        // declare un-initialized variables first
        int userGuessInt;

        // now declare initialized variables
        int correctNumberToGuess = 6;

        // now we can take care of the logic
        Console.WriteLine("Again, one attempt but I'll let you know if you were too high or too low:\n");
        userGuessInt = getValidIntFromUserInput();

        if (userGuessInt == correctNumberToGuess)
        {
           Console.WriteLine("Well done!\n");
        }
        else
        {
            printHigherLowerText(userGuessInt, correctNumberToGuess);  // we will use this a bunch of time so lets make a function for it to reduce redundancy
        }

        ShowRestartOrMenuChoice(V2);
    }

    static void V3()
    {
        // declare un-initialized variables first
        int userGuessInt;

        // now declare initialized variables
        int correctNumberToGuess = 7;

        // now we can take care of the logic
        Console.WriteLine("Multiple tries from now on:\n");
        userGuessInt = getValidIntFromUserInput();
        
        while (userGuessInt != correctNumberToGuess)
        {

            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
            
        }

        Console.WriteLine("Well done!\n");
        ShowRestartOrMenuChoice (V3);
    }

    static void V4()
    {
        // declare un-initialized variables first
        int userGuessInt;

        // now declare initialized variables
        int correctNumberToGuess = 10;
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        // now we can take care of the logic
        Console.WriteLine("Multiple tries from now on with a counter:\n");
        userGuessInt = getValidIntFromUserInput();

        while (userGuessInt != correctNumberToGuess)
        {
            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
            counter++; // increment counter after every attempt
        }

        printSuccessTextWithCounter(counter); // this too can be moved to a function to reduce redundancy
        ShowRestartOrMenuChoice(V4);
    }

    static void V5()
    {
        // declare un-initialized variables first
        int userGuessInt;

        // now declare initialized variables
        int correctNumberToGuess = new Random().Next();
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        // now we can take care of the logic
        Console.WriteLine("Randomized number from now on!:\n");
        userGuessInt = getValidIntFromUserInput();

        while (userGuessInt != correctNumberToGuess)
        {
            printHigherLowerText(userGuessInt, correctNumberToGuess);

            userGuessInt = getValidIntFromUserInput();
            counter++; // increment counter after every attempt
        }

        printSuccessTextWithCounter(counter);
        ShowRestartOrMenuChoice(V5);
    }

    static void V6()
    {
        // declare un-initialized variables first
        int userGuessInt;
        int chosenRangeOption; // this choice has a very different purpose from the last one, so lets keep them in separate variables

        // now declare initialized variables
        Random random = new Random();
        bool isValidOption = true; // assume the option is valid until proven otherwise (default)
        int correctNumberToGuess = 0;                       
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        // now we can take care of the logic
        Console.WriteLine(
                """
                Please choose your desired range:
                    1. 1-100
                    2. 100-200
                    3. 1-1000
                """
            );

        do // use do-while to execute once and check condition only after that
        {
            chosenRangeOption = getValidIntFromUserInput();
        
            switch (chosenRangeOption)
            {
                case 1:
                    Console.WriteLine("chosen range: 1-100\n");
                    correctNumberToGuess = random.Next() % 100 + 1;
                    break;
                case 2:
                    Console.WriteLine("chosen range: 100-200\n");
                    correctNumberToGuess = random.Next() % 100 + 100;
                    break;
                case 3:
                    Console.WriteLine("chosen range: 1-1000\n");
                    correctNumberToGuess = random.Next() % 1000 + 1;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please choose a valid option!\n");
                    isValidOption = false;
                    break;
            }

        } while (!isValidOption); // if the option chosen by the user is not valid, the loop will run again

        // user has made a valid range choice, now we can start guessing
        Console.WriteLine("Guess now:\n");
        userGuessInt = getValidIntFromUserInput();

        while (userGuessInt != correctNumberToGuess)
        {
            counter++;
            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
        }

        printSuccessTextWithCounter(counter);
        ShowRestartOrMenuChoice(V6);
    }

    static void V7()
    {
        // declare un-initialized variables first
        int upperBound;
        int lowerBound;
        int userGuessInt;
        int correctNumberToGuess; // technically we can declare it when initializing it, but this seems cleaner and more readable

        // now declare initialized variables
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        // now we can take care of the logic
        Console.WriteLine("You set the range to guess!\nupper bound:\n");
        upperBound = getValidIntFromUserInput();
        Console.WriteLine("lower bound:\n");
        lowerBound = getValidIntFromUserInput();
        Console.Clear(); // user made their choice, let's clean up the screen before they guess
        Console.WriteLine("chosen range: " + lowerBound + "-" + upperBound + "\n");

        // now that the bounds are set, lets generate the random number and start the guessing
        correctNumberToGuess = new Random().Next(lowerBound, upperBound + 1);
        Console.WriteLine("Guess now:\n");
        userGuessInt = getValidIntFromUserInput();
        
        while (userGuessInt != correctNumberToGuess)
        {
            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
            counter++; // increment counter after every attempt
        }

        printSuccessTextWithCounter(counter);
        ShowRestartOrMenuChoice(V7); 
    }

    static void V8() 
    {
        // declare un-initialized variables first
        int userGuessInt;

        // now declare initialized variables
        int upperBound = 1000; // lets define the bounds and such as vars make it easier to change them if ever necessary
        int lowerBound = 10000;
        int optimizedMaxAttempts = 13;
        int correctNumberToGuess = new Random().Next(upperBound, lowerBound + 1);
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        Console.WriteLine("Ill rate your tries, range is 1000-10000! \n" +
                            "guess: ");
        userGuessInt = getValidIntFromUserInput();
        
        while (userGuessInt != correctNumberToGuess)
        {
            counter++;
            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
        }

        printSuccessTextWithCounterFeedback(counter, optimizedMaxAttempts); // we will re-use this too, so lets make a function for it to reduce redundancy
        ShowRestartOrMenuChoice(V8);
    }

    static void V9()
    {
        // declare un-initialized variables first
        int upperBound;
        int lowerBound;
        int userGuessInt;
        int correctNumberToGuess;
        int optimizedMaxAttempts;

        // now declare initialized variables
        int counter = 1; // start counter at '1' because there must always be at least one attempt

        // now we can take care of the logic
        Console.WriteLine("You set the range to guess!\nupper bound:\n");
        upperBound = getValidIntFromUserInput();
        Console.WriteLine("lower bound:\n");
        lowerBound = getValidIntFromUserInput();
        Console.Clear(); // user made their choice, let's clean up the screen before they guess
        Console.WriteLine("chosen range: " + lowerBound + "-" + upperBound + "\n");

        // now that the bounds are set we determine the optimized number of attempts
        optimizedMaxAttempts = getOptimizedMaxAttempts(upperBound - lowerBound);

        // now that we have that, lets generate the random number and start the guessing
        correctNumberToGuess = new Random().Next(lowerBound, upperBound + 1);
        Console.WriteLine("Guess now:\n");
        userGuessInt = getValidIntFromUserInput();
        
        while (userGuessInt != correctNumberToGuess)
        {
            printHigherLowerText(userGuessInt, correctNumberToGuess);
            userGuessInt = getValidIntFromUserInput();
            counter++; // increment counter after every attempt
        }

        printSuccessTextWithCounterFeedback(counter, optimizedMaxAttempts);
        ShowRestartOrMenuChoice(V9); 
    }

    static void V10()
    {
        // declare un-initialized variables first
        int upperBound;
        int lowerBound;

        // now we can take care of the logic
        Console.WriteLine("You set the range, I'll guess the number!\nupper bound:\n");
        upperBound = getValidIntFromUserInput();
        Console.WriteLine("lower bound:\n");
        lowerBound = getValidIntFromUserInput();
        Console.Clear(); // user made their choice, let's clean up the screen before they guess
        Console.WriteLine("chosen range: " + lowerBound + "-" + upperBound + "\n");
        Console.WriteLine("Think of a number within this range.");
        // Start the recursive guessing process
        int guessCount = GuessNumberRecursively(lowerBound, upperBound, 1);
        printSuccessTextWithCounterFeedback(guessCount, getOptimizedMaxAttempts(upperBound - lowerBound), true);
        ShowRestartOrMenuChoice(V5);
    }

    #endregion

    #region HelperFunctions

    static int getValidIntFromUserInput()
    {
        bool isValidInput = false;
        int userInputInt = -1; // this should logically never be returned as -1 but compiler is worried about it not being declared in some code paths

        while (!isValidInput)
        {
            string rawUserInputString = Console.ReadLine();

            try
            {
                userInputInt = Convert.ToInt32(rawUserInputString.Trim());
                isValidInput = true;
                return userInputInt;

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input! Please enter the number of your choice");
            }
        }
        return userInputInt; // this can't ever be reached under normal circumstances
    }

    static void ShowRestartOrMenuChoice(Action lastVariantAction)
    {
        Console.WriteLine("Restart (r)\n" +
            "Main Menu? (m)\n" +
            "Quit (q)");
        char userInputCharacter = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch(userInputCharacter)
        {
            case 'r':
                Console.Clear();
                lastVariantAction();
                break;
            case 'm':
                Console.Clear();
                return;
            case 'q':
                Console.Clear();
                Console.WriteLine("Thanks for playing and until next time! \nPress any key to quit...");
                Console.ReadKey();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input please use 'r','m' or 'q'");
                ShowRestartOrMenuChoice(lastVariantAction);
                break;
        }
    }

    static void printHigherLowerText(int userGuessInt, int correctNumberToGuess)
    {
        if (userGuessInt < correctNumberToGuess)
            {
                Console.WriteLine("Guess a bit higher!\n");
            }
            else if (userGuessInt > correctNumberToGuess)
            {
                Console.WriteLine("Too high!\n");
            }
    }

    static void printSuccessTextWithCounter(int counter)
    {

        if (counter == 1) 
        {
            Console.WriteLine("Wow, you only needed a single try!\n");
        }
        else
        {
            Console.WriteLine("Well done! You needed a total of "+ counter + " attempts!\n");
        }

    }

    static void printSuccessTextWithCounterFeedback(int counter, int optimizedMaxAttempts, bool isCodeGuessing=false)
    {
        /**
        * In the next line of code is a ternary operator which is used to assign a value to the variable 'pronoun'
        * based on the condition 'isCodeGuessing'. 
        * 
        * Syntax:
        * <condition> ? <true-value> : <false-value>;
        * 
        * If 'isCodeGuessing' is true, 'pronoun' is assigned the value "I".
        * Otherwise, 'pronoun' is assigned the value "You".
        * 
        * Equivalent if-else logic would look like this:
        * 
        * if (isCodeGuessing)
        * {
        *     pronoun = "I";
        * }
        * else
        * {
        *     pronoun = "You";
        * }
        * 
        * The ternary operator allows for more concise code by replacing this if-else block. It should be used for simple if-else value assignments.
        */
        string pronoun = isCodeGuessing ? "I" : "You";
        if (counter < optimizedMaxAttempts)
        {
            Console.WriteLine("Wow! " + pronoun + " only needed " + counter + " attempts! You got lucky there!");
        }
        else if (counter > optimizedMaxAttempts)
        {
            Console.WriteLine(pronoun + " did it after " + counter + " attempts! Is there maybe a tactic to get it more quickly?");
        }
        else if (counter == optimizedMaxAttempts)
        {
            Console.WriteLine("Good job! " + pronoun + " needed " + counter + " attempts! Thats pretty good!");
        }
    }

    static int getOptimizedMaxAttempts(int range)
    {
        // to determine the max number of attempts when making mathematically optimal guesses take log2 of 'range' rounded up
        return (int)Math.Ceiling(Math.Log2(range));
    }

    static int GuessNumberRecursively(int lowerBound, int upperBound, int guessCount)
    {
        if (lowerBound > upperBound)
        {
            Console.WriteLine("Something went wrong. Please ensure the lower bound is less than or equal to the upper bound.");
            return guessCount; // or throw an exception
        }

        // Calculate middle point: (upper - lower) finds the range, /2 divides it in half,
        // + lowerBound shifts it to the correct position within the range.
        // This simplifies to (lower + upper) / 2 for more efficiency.
        int guess = (lowerBound + upperBound) / 2;
        Console.WriteLine("Is your number " + guess + "? (y/h/l)");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true hides the pressed key
        switch (keyInfo.Key)
        {
            case ConsoleKey.Y:
                return guessCount;
            case ConsoleKey.H:
                return GuessNumberRecursively(guess + 1, upperBound, guessCount + 1);
            case ConsoleKey.L:
                return GuessNumberRecursively(lowerBound, guess - 1, guessCount + 1);
            default:
                Console.WriteLine("Invalid input. Please press 'y', 'h', or 'l'.");
                return GuessNumberRecursively(lowerBound, upperBound, guessCount);
        }
    }


    #endregion
}
#endregion
