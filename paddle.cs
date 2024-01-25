public class Paddle
{
    // Pozycja rakietki i jej wysokość
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Height { get; private set; }

    //pozycja i wysokość rakietki
    public Paddle(int x, int y, int height)
    {
        X = x;
        Y = y;
        Height = height;
    }

    //rakietka w górę
    public void MoveUp()
    {
        Y--;
    }

    //rakietka w dół
    public void MoveDown()
    {
        Y++;
    }
}
