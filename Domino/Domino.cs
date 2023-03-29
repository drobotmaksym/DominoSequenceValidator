namespace Domino;

public struct Domino
{
    public int Left;
    public int Right;

    public Domino(int left, int right)
    {
        Left = left;
        Right = right;
    }

    public bool Adjacent(Domino domino)
    {
        return Left == domino.Left || 
               Left == domino.Right || 
               Right == domino.Right || 
               Right == domino.Left;
    }

    public void AdjustFor(Domino domino)
    {
        if (Left == domino.Right || Right == domino.Left) return;
        (Right, Left) = (Left, Right);
    }

    public override string ToString()
    {
        return $"[{Left}|{Right}]";
    }
}