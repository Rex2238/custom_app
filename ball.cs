public class Ball
{
    //Pozycja piłki
    public int X { get; set; }
    public int Y { get; set; }

    //Kierunek ruchu piłki
    public int XDirection { get; set; }
    public int YDirection { get; set; }

    //Początkowa pozycja i kierunek ruchu piłki
    public Ball(int initialX, int initialY)
    {
        X = initialX;
        Y = initialY;
        XDirection = 1; // początkowy kierunek ruchu w poziomie
        YDirection = -1;
    }
    //przemieszczaniepiłki
    public void Move()
    {
        X += XDirection;
        Y += YDirection;
    }
    // Metoda do zmiany kierunku ruchu piłki
    public void ChangeDirection(bool changeX, bool changeY)
    {
        if (changeX) XDirection *= -1; //w poziomie
        if (changeY) YDirection *= -1; //w pionie
    }
}
