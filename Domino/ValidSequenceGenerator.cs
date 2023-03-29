namespace Domino;

public static class ValidSequenceGenerator
{
    public static LinkedList<Domino> TryGenerateValidSequence(Domino[] dominoes, out Domino? misplaced)
    {
        var sequence = new LinkedList<Domino>();
        sequence.AddFirst(dominoes.First());
        
        return TryGenerateValidSequenceRecursively(
            dominoes,
            out misplaced,
            sequence,
            1
            );
    }

    private static LinkedList<Domino> TryGenerateValidSequenceRecursively(
        Domino[] dominoes,
        out Domino? misplaced,
        LinkedList<Domino> sequence,
        int start = 1 
    )
    {
        for (; start < dominoes.Length; start++)
        {
            Domino current = dominoes[start];
            Domino boundary = new (
                sequence.First().Left,
                sequence.Last().Right
            );
            
            // Для поітераційної перевірки, можна видалити:
            Utils.WriteDominoes(sequence);
            
            if (!boundary.Adjacent(current))
            {
                misplaced = current;
                return new LinkedList<Domino>();
            }
            
            current.AdjustFor(boundary);

            if (boundary.Left == current.Right && boundary.Right == current.Left)
            {
                var firstCaseInitialSequence = new LinkedList<Domino>(sequence);
                var secondCaseInitialSequence = new LinkedList<Domino>(sequence);
                firstCaseInitialSequence.AddFirst(current);
                secondCaseInitialSequence.AddLast(current);
                
                var firstCaseSequence = TryGenerateValidSequenceRecursively(
                    dominoes,
                    out misplaced,
                    firstCaseInitialSequence,
                    start + 1
                    );

                var secondCaseSequence = TryGenerateValidSequenceRecursively(
                    dominoes,
                    out misplaced,
                    secondCaseInitialSequence,
                    start + 1
                );

                if (firstCaseSequence.Any()) return firstCaseSequence;
                if (secondCaseSequence.Any()) return secondCaseSequence;
                return new LinkedList<Domino>();
            }
            else if (boundary.Left == current.Right)
            {
                sequence.AddFirst(current);
            }
            else
            {
                sequence.AddLast(current);
            }
        }

        misplaced = null;
        return sequence;
    }
}