using System.Reflection;

namespace AktieSkat.Tests;

public class AktieSkatBeregnerTests
{
    [Fact]
    public void BeregnSkat_NulAktieindkomst_GiverNulSkat()
    {
        // Arrange
        decimal aktieindkomst = 0m;

        // Act
        decimal skat = BeregnSkat(aktieindkomst);

        // Assert
        Assert.Equal(0m, skat);
    }

    [Fact]
    public void BeregnSkat_IndkomstPaa10000_BeskattesMed27Procent()
    {
        // Arrange
        decimal aktieindkomst = 10_000m;

        // Act
        decimal skat = BeregnSkat(aktieindkomst);

        // Assert
        Assert.Equal(2_700m, skat);
    }

    [Fact]
    public void BeregnSkat_IndkomstPaaGraensen_BeskattesMed27Procent()
    {
        // Arrange
        decimal aktieindkomst = 79_400m;

        // Act
        decimal skat = BeregnSkat(aktieindkomst);

        // Assert
        Assert.Equal(21_438m, skat);
    }

    [Fact]
    public void BeregnSkat_IndkomstPaa100000_BeskatterOverskydendeMed42Procent()
    {
        // Arrange
        decimal aktieindkomst = 100_000m;

        // Act
        decimal skat = BeregnSkat(aktieindkomst);

        // Assert
        Assert.Equal(30_090m, skat);
    }

    [Fact]
    public void BeregnSkat_IndkomstPaa200000_BeskatterOverskydendeMed42Procent()
    {
        // Arrange
        decimal aktieindkomst = 200_000m;

        // Act
        decimal skat = BeregnSkat(aktieindkomst);

        // Assert
        Assert.Equal(72_090m, skat);
    }

    private static decimal BeregnSkat(decimal aktieindkomst)
    {
        Type? beregnerType = AppDomain.CurrentDomain.GetAssemblies()
            .Select(assembly => assembly.GetType("AktieSkatBeregner"))
            .FirstOrDefault(type => type is not null);

        Assert.NotNull(beregnerType);

        object beregner = Activator.CreateInstance(beregnerType!)!;
        MethodInfo? beregnSkat = beregnerType!.GetMethod("BeregnSkat", [typeof(decimal)]);

        Assert.NotNull(beregnSkat);

        return (decimal)beregnSkat!.Invoke(beregner, [aktieindkomst])!;
    }
}
