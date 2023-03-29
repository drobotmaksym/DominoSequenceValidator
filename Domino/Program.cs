using System.Text;

namespace Domino;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program
{
    private static readonly Domino[] Dominoes = {
        new (0, 0),
        new (0, 1),
        new (1, 2),
        new (0, 2),
        new (0, 3),
        new (0, 4),
        new (0, 5),
        new (0, 6),
        new (1, 1),
        new (1, 3),
        new (1, 4),
        new (1, 5),
        new (1, 6),
        new (2, 2),
        new (3, 3),
        new (2, 4),
        new (2, 5),
        new (2, 6),
        new (4, 4),
        new (3, 4),
        new (3, 6),
        new (4, 5),
        new (4, 6),
        new (3, 5),
        new (5, 5),
        new (2, 3),
        new (5, 6),
        new (6, 6)
    };
    
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        var sequence = ValidSequenceGenerator.TryGenerateValidSequence(
            Dominoes,
            out var misplaced
            );
        
        if (sequence.Count == 0)
        {
            Console.WriteLine("☒ Послідовність не відповідає правилам:");
            Console.WriteLine($"Доміно {misplaced.ToString()} розміщено невірно.");
        }
        else
        {
            Console.WriteLine("☑ Послідовність відповідає правилам.");
            Console.WriteLine("Один із можливих варіантів розміщення доміно:");
            Utils.WriteDominoes(sequence);
        }
    }
}
