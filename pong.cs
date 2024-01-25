using System;
using System.Threading;

public class PongGame
{
    private int Width;
    private int Height;
    private Ball Ball;
    private Paddle LeftPaddle;
    private Paddle RightPaddle;

    //start gry
    public PongGame(int width, int height)
    {
        Width = width;
        Height = height;
        Ball = new Ball(width / 2, height / 2); //piłka na środku
        LeftPaddle = new Paddle(1, height / 2 - 2, 4); //lewa rak
        RightPaddle = new Paddle(width - 2, height / 2 - 2, 4); //prawa rak
    }
    public void Start()
    {
        Console.CursorVisible = false; //ukrycie kursora w konsoli
        Console.SetWindowSize(Width, Height);
        Console.SetBufferSize(Width, Height);

        //Pętla gry
        while (true)
        {
            Draw();
            HandleInput();
            Update(); 
            Thread.Sleep(200); //opóźnienie gry
        }
    }

    //rysowanie gry
    private void Draw()
    {
        Console.Clear();
        DrawPaddle(LeftPaddle);
        DrawPaddle(RightPaddle);
        DrawBall(Ball); 
    }

    // Rysowanie piłki
    private void DrawBall(Ball ball)
    {
        Console.SetCursorPosition(ball.X, ball.Y);
        Console.Write("O");
    }

    // Rysowanie rakietki
    private void DrawPaddle(Paddle paddle)
    {
        for (int i = 0; i < paddle.Height; i++)
        {
            Console.SetCursorPosition(paddle.X, paddle.Y + i);
            Console.Write("|");
        }
    }

    //obsługa wejścia klawiatury
    private void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            //kontrola lewej rakietki
            switch (key)
            {
                case ConsoleKey.W:
                    if (LeftPaddle.Y > 0) LeftPaddle.MoveUp();
                    break;
                case ConsoleKey.S:
                    if (LeftPaddle.Y < Height - LeftPaddle.Height) LeftPaddle.MoveDown();
                    break;
                //kontrola prawej rakietki
                case ConsoleKey.UpArrow:
                    if (RightPaddle.Y > 0) RightPaddle.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    if (RightPaddle.Y < Height - RightPaddle.Height) RightPaddle.MoveDown();
                    break;
            }
        }
    }

    //aktualizacja stanu gry
    private void Update()
    {
        Ball.Move(); 
        CheckCollision();
    }

    //Sprawdzanie kolizji
    private void CheckCollision()
    {
        //Odbijanie od górnej i dolnej krawędzi
        if (Ball.Y == 0 || Ball.Y == Height - 1)
            Ball.ChangeDirection(false, true);

        //Odbijanie od rakietek
        if ((Ball.X == LeftPaddle.X + 1 && Ball.Y >= LeftPaddle.Y && Ball.Y <= LeftPaddle.Y + LeftPaddle.Height) ||
            (Ball.X == RightPaddle.X - 1 && Ball.Y >= RightPaddle.Y && Ball.Y <= RightPaddle.Y + RightPaddle.Height))
        {
            Ball.ChangeDirection(true, false);
        }

        //Resetowanie piłki po wyjściu poza ekran
        if (Ball.X == 0 || Ball.X == Width - 1)
        {
            Ball = new Ball(Width / 2, Height / 2);
        }
    }
}
