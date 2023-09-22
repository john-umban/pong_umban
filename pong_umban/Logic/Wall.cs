using Godot;


public class Wall : Area2D
{
    public int PlayerScore = 0;
    public int EnemyScore = 0;
    public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            // Ball went off the side of the screen, reset it.
            ball.Reset();
            PlayerScore++;
        }
    }
}
