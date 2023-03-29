namespace Domino;

public static class Utils
{
    public static void WriteDominoes(IEnumerable<Domino> dominoes)
    {
        foreach (Domino domino in dominoes) Console.Write(domino + " ");
        Console.WriteLine();
    }
}