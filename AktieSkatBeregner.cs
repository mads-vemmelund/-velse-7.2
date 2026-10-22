public class AktieSkatBeregner
{
    private const decimal Graense = 79_400m;
    private const decimal LavSkattesats = 0.27m;
    private const decimal HoejSkattesats = 0.42m;

    public decimal BeregnSkat(decimal aktieindkomst)
    {
        decimal indkomstMedLavSats = Math.Min(aktieindkomst, Graense);
        decimal indkomstMedHoejSats = Math.Max(aktieindkomst - Graense, 0m);

        return indkomstMedLavSats * LavSkattesats
            + indkomstMedHoejSats * HoejSkattesats;
    }
}