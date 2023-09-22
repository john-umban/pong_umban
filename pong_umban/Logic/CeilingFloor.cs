using Godot;

public class CeilingFloor : Area2D
{
    [Export]
    private int _bounceDirection = 1;

    public void OnAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            
            ball.Direction = (ball.Direction + new Vector2(0, _bounceDirection)).Normalized();                          // Ensures 'Ball' has a public 'direction' field or property
        }
    }
}
