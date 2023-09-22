using Godot;

public class RightWall : Area2D
{
    public int EnemyScore = 0;
    private Label scoreLabel;
    private Label difficultyLabel;
    private Ball ball;

    public override void _Ready()
    {
        
        scoreLabel = GetNode<Label>("EnemyScore");                          // Find "EnemyScore" Node Label and store it in scoreLabel.

        difficultyLabel = GetNode<Label>("DifficultyEnemy");                // Find "DifficultyNode" Node Label and store it in difficultyLabel.

        ball = GetNode<Ball>("../Ball");                                    // Find the Ball object in the scene and store a reference to it.
        
        UpdateScoreLabel();                                                 // Initialize the score label's text with the initial score.
    }

   public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            EnemyScore += 5;
            ball.Reset();                                                   // if Ball went off the side of the screen, reset it.
            UpdateScoreLabel();                                             // Update the score label's text.
            GD.Print("Player 1 Score: " + EnemyScore);
            
            // *------------------------------------------------------------EnemyScore += 5;        


            
            if (EnemyScore >= 25 )                                          // Check if the player has reached a certain score (e.g., 5).
            {                                                               //&& EnemyScore >= 5)
                EnemyScore -= 3;
                difficultyLabel.Text = "Average Difficulty";

            //*-------------------------------------------------------------Just in case: [(*) for lines in the same code] if points are met, increase the ball speed for higher difficulty  //ball.IncreaseSpeed(1000);
            }

            if (EnemyScore >= 40){
                EnemyScore -=1;
                difficultyLabel.Text = "Hard Difficulty";
            }
        }
    }


    private void UpdateScoreLabel()
    {
        if (scoreLabel != null)                                            //Update the score label's text to display the player's score.
        {
                                                                           
             //*-----------------------------------------------------------scoreLabel.Text = "Player 2 Score: " + EnemyScore;

            if (EnemyScore >= 0 && EnemyScore < 50 ){
                scoreLabel.Text = "Player 1 Score: " + EnemyScore;
            }
            
            else {
                scoreLabel.Text = "Player 1 Wins " ;
                GetTree().Paused = true;
            }

        }
    }
}
