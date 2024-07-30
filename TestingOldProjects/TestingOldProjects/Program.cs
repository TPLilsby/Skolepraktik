//Opgave 1 – basal brug af array
/*
int[]  antal;
antal = new int[10];

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine("Indtast et heltal: ");
    antal[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("\nTal i arrayet");

// Udskrevet med en for-løkke

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine(antal[i]);
}


// Udskrevet med en foreach-løkke

foreach (int item in antal)
{
    Console.WriteLine(item);
}
*/

//Opgave 2 – Udskriv kun de negative værdier
/*
int[] antal;
antal = new int[10];

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine("Indtast et heltal: ");
    antal[i] = int.Parse(Console.ReadLine());
}
Array.Sort(antal);

Console.WriteLine("\nTal i arrayet");

for (int i = 0; i < antal.Length; i++)
{
    if (antal[i] < 0)
    {
        Console.WriteLine(antal[i]);
    }
}
*/

//Opgave 3 – Udskriv summen
/*
int[] antal;
antal = new int[10];
int sum = 0;

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine("Indtast et heltal: ");
    antal[i] = int.Parse(Console.ReadLine());
    sum = sum + antal[i];
}

Console.WriteLine("\n" + sum);
*/

//Opgave 4 – Største og mindste værdi
/*
int[] antal;
antal = new int[10];

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine("Indtast et heltal: ");
    antal[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Største værdien: " + antal.Max() + "\nMindste værdien: " + antal.Min());
*/

//Opgave 5 - Sortering
/*
int i_antal;

Console.WriteLine("HVor mange tal ville du have  i arrayet? ");
i_antal = int.Parse(Console.ReadLine());

int[] antal;
antal = new int[i_antal];

for (int i = 0; i < antal.Length; i++)
{
    Console.WriteLine("Indtast et heltal: ");
    antal[i] = int.Parse(Console.ReadLine());
}

Array.Sort(antal);

for (int i = 0; i <= antal.Length; i++)
{
    Console.WriteLine("\n" + antal[i]);
}

// Aner det ikke...
*/

//Ekstraopgave 1

int j;
int n;

int array_s1;
Console.WriteLine("Hvor mange pladser skal der være i det første array? ");
array_s1 = int.Parse(Console.ReadLine());
int[] array_1;
array_1 = new int[array_s1];

int array_s2;
Console.WriteLine("Hvor mange pladser skal der være i det andet array? ");
array_s2 = int.Parse(Console.ReadLine());
int[] array_2;
array_2 = new int[array_s2];

int[] array_3;

array_3 = new int[array_s1 + array_s2];

for (j = 0; j < array_1.Length; j++)
{
    Console.WriteLine("Indtast tal i det første array: ");
    array_1[j] = int.Parse(Console.ReadLine());
}

for (n = 0; n < array_2.Length; n++)
{
    Console.WriteLine("Indtast tal i det andet array: ");
    array_2[n] = int.Parse(Console.ReadLine());
}

//Første metode jeg prøvet
for (int i = 0; i < array_3.Length; i++)
{   
    array_3[i] = array_1[j] & array_2[n];
    int samlet_arrray = array_3[i];

    Console.WriteLine(samlet_arrray);
}

//anden metode jeg prøvet
foreach (int item in array_1 && array_2)
{
    Console.WriteLine(item);
}


//Ekstraopgave 2
/*
string[] ord;
ord = new string[10];

for (int i = 0; i < ord.Length; i++)
{
    Console.WriteLine("Indtast et ord: ");
    ord[i] = Console.ReadLine();
}

Console.WriteLine("Søg på et ord i arrayet: ");
string søgning = Console.ReadLine();

for (int i = 0; i < ord.Length; i++)
{
    if (søgning == ord[i])
    {
        Console.WriteLine(i);
    }
}
*/