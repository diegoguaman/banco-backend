using Xunit;

public class UnitTest1
{
    [Fact] // Indica que esta es una prueba unitaria
    public void TestSuma()
    {
        int resultado = 2 + 2;
        Assert.Equal(4, resultado); // Verifica que 2 + 2 realmente sea 4
    }
}

