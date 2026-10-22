using System.Globalization;

CultureInfo danskKultur = CultureInfo.GetCultureInfo("da-DK");
Console.Write("Indtast aktieindkomst i kr.: ");

string? indtastning = Console.ReadLine();

if (decimal.TryParse(indtastning, NumberStyles.Number, danskKultur, out decimal aktieindkomst))
{
    var beregner = new AktieSkatBeregner();
    decimal skat = beregner.BeregnSkat(aktieindkomst);

    Console.WriteLine($"Beregnet skat: {skat.ToString("N2", danskKultur)} kr.");
}
else
{
    Console.WriteLine("Ugyldigt beløb. Indtast et tal, f.eks. 10000 eller 10.000,50.");
}