List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


//Use LINQ to find the first eruption that is in Chile and print the result.
 Eruption firstChileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
if (firstChileEruption != null)
{
    Console.WriteLine("First eruption in Chile:");
    Console.WriteLine(firstChileEruption);
}
else
{
    Console.WriteLine("No Chilean eruption found.");
}

//Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption firstHawaiianEruption = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (firstHawaiianEruption != null)
{
    Console.WriteLine("First eruption in Hawaiian Is:");
    Console.WriteLine(firstHawaiianEruption);
}
else
{
    Console.WriteLine("No Hawaiian Is eruption found.");
}

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption firstEruptionAfter1900InNZ = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location == "New Zealand");
if (firstEruptionAfter1900InNZ != null)
{
    Console.WriteLine("First eruption after 1900 in New Zealand:");
    Console.WriteLine(firstEruptionAfter1900InNZ);
}
else
{
    Console.WriteLine("No eruption found after 1900 in New Zealand.");
}

//Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> highElevationEruptions = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(highElevationEruptions, "Eruptions with elevation over 2000m:");

//Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(eruptionsStartingWithL, "Eruptions with volcano names starting with 'L':");
Console.WriteLine($"Number of eruptions found: {eruptionsStartingWithL.Count()}");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int highestElevation = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"Highest elevation: {highestElevation} meters");

//Use the highest elevation variable to find a print the name of the Volcano with that elevation.
string volcanoWithHighestElevation = eruptions.FirstOrDefault(e => e.ElevationInMeters == highestElevation)?.Volcano;
if (!string.IsNullOrEmpty(volcanoWithHighestElevation))
{
    Console.WriteLine($"Volcano with the highest elevation ({highestElevation} meters): {volcanoWithHighestElevation}");
}
else
{
    Console.WriteLine("No volcano found with the highest elevation.");
}

//Print all Volcano names alphabetically.
var sortedVolcanoNames = eruptions.Select(e => e.Volcano).OrderBy(name => name);
PrintEach(sortedVolcanoNames, "Volcano names alphabetically:");

//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
var ancientEruptions = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(ancientEruptions, "Eruptions before 1000 CE alphabetically by volcano name:");

//BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
var ancientVolcanoNames = eruptions
    .Where(e => e.Year < 1000)
    .OrderBy(e => e.Volcano)
    .Select(e => e.Volcano);
PrintEach(ancientVolcanoNames, "Volcano names of eruptions before 1000 CE (bonus):");
