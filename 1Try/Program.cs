using System;
using System.Numerics; // Für BigInteger

class Program
{
    // Eine einzelne Instanz von Random wiederverwenden für bessere Zufallszahlen
    static Random rand = new Random();

    static void Main()
    {
        bool keepPlaying = true;

        while (keepPlaying)
        {
            Console.WriteLine("Willkommen beim Codeknacker!\n" +
                "Wähle eine Variante:\n" +
                "1. Variante 1\n" +
                "2. Variante 2\n" +
                "3. Variante 3\n" +
                "4. Variante 4\n" +
                "5. Variante 5\n" +
                "6. Variante 6\n" +
                "7. Variante 7\n" +
                "8. Variante 8\n" +
                "9. Variante 9\n" +
                "10. Variante 10\n" +
                "0. Beenden");

            int choice = ValidInput(0, 10);

            switch (choice)
            {
                case 1:
                    Variante1();
                    break;
                case 2:
                    Variante2();
                    break;
                case 3:
                    Variante3();
                    break;
                case 4:
                    Variante4();
                    break;
                case 5:
                    Variante5();
                    break;
                case 6:
                    Variante6();
                    break;
                case 7:
                    Variante7();
                    break;
                case 8:
                    Variante8();
                    break;
                case 9:
                    Variante9();
                    break;
                case 10:
                    Variante10();
                    break;
                case 0:
                    keepPlaying = false;
                    Console.WriteLine("Bis zum nächsten Mal!");
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
                    break;
            }

            Console.WriteLine();
        }
    }
#region Spielvarianten
    // Variante 1: Einfache Zahl raten
    static void Variante1()
    {
        const int geheimzahl = 42; // Vorgegebene Geheimzahl

        Console.WriteLine("Variante 1: Rate die Geheimzahl.");
        Console.Write("Dein Tipp: ");
        int tipp = ValidInput();

        if (tipp == geheimzahl)
        {
            Console.WriteLine("Die Zahl ist richtig!");
        }
        else
        {
            Console.WriteLine("Die Zahl ist falsch.");
        }
    }

    // Variante 2: Hinweis, ob Zahl zu groß oder zu klein ist
    static void Variante2()
    {
        const int geheimzahl = 42;

        Console.WriteLine("Variante 2: Rate die Geheimzahl.");
        Console.Write("Dein Tipp: ");
        int tipp = ValidInput();

        if (tipp == geheimzahl)
        {
            Console.WriteLine("Die eingegebene Zahl ist richtig.");
        }
        else if (tipp < geheimzahl)
        {
            Console.WriteLine("Die eingegebene Zahl ist zu klein.");
        }
        else
        {
            Console.WriteLine("Die eingegebene Zahl ist zu groß.");
        }
    }

    // Variante 3: Wiederholung bis die Zahl gefunden wurde
    static void Variante3()
    {
        const int geheimzahl = 42;

        Console.WriteLine("Variante 3: Rate die Geheimzahl.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);
    }

    // Variante 4: Zähler der Versuche
    static void Variante4()
    {
        const int geheimzahl = 42;
        int versuche = 0;

        Console.WriteLine("Variante 4: Rate die Geheimzahl.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");
    }

    // Variante 5: Zufällige Geheimzahl
    static void Variante5()
    {
        int geheimzahl = rand.Next(1, 101); // Zufallszahl zwischen 1 und 100
        int versuche = 0;

        Console.WriteLine("Variante 5: Rate die zufällige Geheimzahl zwischen 1 und 100.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");
    }

    // Variante 6: Zufallszahl mit Modulo-Operator
    static void Variante6()
    {
        int geheimzahl = rand.Next() % 1000 + 1; // Zufallszahl zwischen 1 und 1000
        int versuche = 0;

        Console.WriteLine("Variante 6: Rate die Geheimzahl zwischen 1 und 1000.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");
    }

    // Variante 7: Benutzerdefinierter Zahlenbereich
    static void Variante7()
    {
        Console.WriteLine("Variante 7: Wähle den Zahlenbereich.");

        Console.Write("Untere Grenze: ");
        int untereGrenze = ValidInput();

        Console.Write("Obere Grenze: ");
        int obereGrenze = ValidInput();

        if (untereGrenze > obereGrenze)
        {
            // Grenzen tauschen
            int temp = untereGrenze;
            untereGrenze = obereGrenze;
            obereGrenze = temp;
        }

        int geheimzahl = rand.Next(untereGrenze, obereGrenze + 1);
        int versuche = 0;

        Console.WriteLine($"Rate die Geheimzahl zwischen {untereGrenze} und {obereGrenze}.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");
    }

    // Variante 8: Bewertung der Versuche
    static void Variante8()
    {
        Console.WriteLine("Variante 8: Wähle den Zahlenbereich.");

        Console.Write("Untere Grenze: ");
        int untereGrenze = ValidInput();

        Console.Write("Obere Grenze: ");
        int obereGrenze = ValidInput();

        if (untereGrenze > obereGrenze)
        {
            // Grenzen tauschen
            int temp = untereGrenze;
            untereGrenze = obereGrenze;
            obereGrenze = temp;
        }

        int geheimzahl = rand.Next(untereGrenze, obereGrenze + 1);
        int versuche = 0;

        // Berechnung der optimalen Anzahl an Versuchen (log₂(N))
        int optimalVersuche = (int)Math.Ceiling(Math.Log2(obereGrenze - untereGrenze + 1));

        Console.WriteLine($"Rate die Geheimzahl zwischen {untereGrenze} und {obereGrenze}.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");

        if (versuche < optimalVersuche)
        {
            Console.WriteLine("Wow, du hattest Glück und hast weniger Versuche gebraucht als erwartet!");
        }
        else if (versuche == optimalVersuche)
        {
            Console.WriteLine("Gut gemacht, du hast die optimale Anzahl von Versuchen gebraucht!");
        }
        else
        {
            Console.WriteLine("Du könntest deine Strategie verbessern. Versuche es erneut!");
        }
    }

    // Variante 9: Mathematische Bewertung
    static void Variante9()
    {
        Console.WriteLine("Variante 9: Wähle den Zahlenbereich.");

        Console.Write("Untere Grenze: ");
        int untereGrenze = ValidInput();

        Console.Write("Obere Grenze: ");
        int obereGrenze = ValidInput();

        if (untereGrenze > obereGrenze)
        {
            // Grenzen tauschen
            int temp = untereGrenze;
            untereGrenze = obereGrenze;
            obereGrenze = temp;
        }

        int geheimzahl = rand.Next(untereGrenze, obereGrenze + 1);
        int versuche = 0;

        // Berechnung der optimalen Anzahl an Versuchen (log₂(N))
        int optimalVersuche = (int)Math.Ceiling(Math.Log2(obereGrenze - untereGrenze + 1));

        Console.WriteLine($"Rate die Geheimzahl zwischen {untereGrenze} und {obereGrenze}.");

        int tipp;

        do
        {
            Console.Write("Dein Tipp: ");
            tipp = ValidInput();
            versuche++;

            if (tipp == geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist richtig.");
            }
            else if (tipp < geheimzahl)
            {
                Console.WriteLine("Die eingegebene Zahl ist zu klein.");
            }
            else
            {
                Console.WriteLine("Die eingegebene Zahl ist zu groß.");
            }
        }
        while (tipp != geheimzahl);

        Console.WriteLine($"Du hast {versuche} Versuche gebraucht.");

        if (versuche < optimalVersuche)
        {
            Console.WriteLine("Hervorragend! Du hast weniger Versuche gebraucht als mathematisch erwartet.");
        }
        else if (versuche == optimalVersuche)
        {
            Console.WriteLine("Sehr gut! Du hast die optimale Anzahl von Versuchen erreicht.");
        }
        else
        {
            Console.WriteLine("Du hast mehr Versuche gebraucht als nötig. Überlege dir eine bessere Strategie.");
        }

        Console.WriteLine("\nErklärung:");
        Console.WriteLine($"Die minimale Anzahl von Versuchen, um die Zahl zu erraten, beträgt log₂(N) = {optimalVersuche}, wobei N die Anzahl der möglichen Zahlen ist.");
    }

// Variante 10: Große Zahlen mit BigInteger - 200 Zufallszahlen generieren
static void Variante10()
{
    Console.WriteLine("Variante 10: Generiere und überprüfe 200 zufällige BigInteger-Zahlen.");

    Console.Write("Untere Grenze: ");
    BigInteger untereGrenze = ValidBigIntegerInput();

    Console.Write("Obere Grenze: ");
    BigInteger obereGrenze = ValidBigIntegerInput();

    if (untereGrenze > obereGrenze)
    {
        // Grenzen tauschen
        BigInteger temp = untereGrenze;
        untereGrenze = obereGrenze;
        obereGrenze = temp;
    }

    Console.WriteLine($"Generiere 200 zufällige Zahlen zwischen {untereGrenze} und {obereGrenze}...");

    List<BigInteger> zufallsZahlen = new List<BigInteger>();

    for (int i = 0; i < 200; i++)
    {
        BigInteger zahl = RandomBigInteger(untereGrenze, obereGrenze);
        zufallsZahlen.Add(zahl);
    }

    // Ergebnisse auf der Konsole ausgeben
    Console.WriteLine("Generierte Zahlen:");
    foreach (BigInteger zahl in zufallsZahlen)
    {
        Console.WriteLine(zahl);
    }

    // Optional: Zahlen in eine Datei schreiben
    Console.WriteLine("Möchtest du die Zahlen in eine Datei speichern? (ja/nein)");
    string antwort = Console.ReadLine()?.ToLower();
    if (antwort == "ja")
    {
        string pfad = "GenerierteZahlen.txt";
        File.WriteAllLines(pfad, zufallsZahlen.Select(z => z.ToString()));
        Console.WriteLine($"Die Zahlen wurden in {pfad} gespeichert.");
    }

    Console.WriteLine("Fertig!");
}
#endregion
 #region Helferfunktionen
    // Hilfsfunktion zur Validierung der Benutzereingabe (Integer)
    static int ValidInput()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine ganze Zahl eingeben:");
            }
        }
    }

    // Überladene Funktion zur Validierung mit Bereich
    static int ValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result >= min && result <= max)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Bitte eine Zahl zwischen {min} und {max} eingeben:");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine ganze Zahl eingeben:");
            }
        }
    }

    // Hilfsfunktion zur Validierung der Benutzereingabe (BigInteger)
    static BigInteger ValidBigIntegerInput()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (BigInteger.TryParse(input, out BigInteger result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine gültige Zahl eingeben:");
            }
        }
    }

    // Funktion zur Generierung einer zufälligen BigInteger innerhalb eines Bereichs
    static BigInteger RandomBigInteger(BigInteger min, BigInteger max)
    {
        BigInteger range = max - min + 1;
        int bytesLength = (int)Math.Ceiling(BigInteger.Log(range, 256));
        byte[] bytes = new byte[bytesLength];

        BigInteger result;

        do
        {
            rand.NextBytes(bytes);
            result = new BigInteger(bytes.Abs()); // Absolutwert, um negative Zahlen zu vermeiden
        }
        while (result >= range);

        return result + min;
    }
#endregion
}

// Erweiterungsmethode, um den Absolutwert eines Byte-Arrays (V10 Beliebiger Zahlenraum) zu erhalten
static class Extensions
{
    public static byte[] Abs(this byte[] bytes)
    {
        if (bytes[bytes.Length - 1] >= 128)
        {
            // Wenn das höchste Bit gesetzt ist, ist die Zahl negativ
            byte carry = 1;
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(~bytes[i]);
                bytes[i] += carry;
                if (bytes[i] != 0)
                {
                    carry = 0;
                }
            }
        }
        return bytes;
    }
}