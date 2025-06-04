
(string, int, string) values01 = ("a", 5, "c");
Console.WriteLine($"Values01 {values01}");

var values02 = ("a", 5, "c");
Console.WriteLine($"Values02 {values02}");
Console.WriteLine($"First item: {values02.Item1}");
Console.WriteLine($"Second item: {values02.Item2}");
Console.WriteLine($"Third item: {values02.Item2}");

// add names
(string FirstLetter, int theNumber, string SecondLetter) valuesWithNames01 = ("a", 5, "c");
Console.WriteLine($"First item: {valuesWithNames01.FirstLetter}");
Console.WriteLine($"Second item: {valuesWithNames01.theNumber}");
Console.WriteLine($"Third item: {valuesWithNames01.SecondLetter}");

// can use the actual name or the item number
var valuesWithNames02 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
Console.WriteLine($"First item: {valuesWithNames02.Item1}");
Console.WriteLine($"Second item: {valuesWithNames02.Item2}");
Console.WriteLine($"Third item: {valuesWithNames02.Item3}");

Console.WriteLine();

var foo = new { Prop1 = "first", Prop2 = "second" };
var bar = (foo.Prop1, foo.Prop2);
Console.WriteLine($"Inferred type: {bar.Prop1}; {bar.Prop2}");




















