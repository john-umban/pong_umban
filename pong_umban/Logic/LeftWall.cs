using Godot;
using System;

public class LeftWall : Area2D
{
    private int PlayerScore = 0;
    private Label scoreLabel;
    private Label difficultyLabel;

    private Ball ball;

    
    public override void _Ready()
    {
        
        scoreLabel = GetNode<Label>("PlayerScore");                                                         // Find the Label node by name "PlayerScore" and store it in scoreLabel.
       
        difficultyLabel = GetNode<Label>("DifficultyPlayer");                                               // Find "DifficultyNode" Node Label and store it in difficultyLabel.
       
        ball = GetNode<Ball>("../Ball");                                                                    // Find the Ball object in the scene and store a reference to it.

        UpdateScoreLabel();                                                                                 // Initialize the score label's text with the initial score.
    }

    public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            
            ball.Reset();                                                                                   // Ball went off the side of the screen, reset it.
            PlayerScore += 5;
            UpdateScoreLabel();                                                                             // Update the score label's text.

            GD.Print("Player 2 Score: " + PlayerScore);
            
            // *---------------------------------------------------------------------------------------------EnemyScore += 5;        

           
            if (PlayerScore >= 25 )                                                                          // Check if the player has reached a certain score (e.g., 5).                                                           
            {                                                                                                //&& EnemyScore >= 5)
                PlayerScore -= 3;
                difficultyLabel.Text = "Average Difficulty";

            //*---------------------------------------------------------------------------------------------Just in case: [(*) for lines in the same code] if points are met, increase the ball speed for higher difficulty  //ball.IncreaseSpeed(1000);
            }

            if (PlayerScore >= 40){
                PlayerScore -=1;
                difficultyLabel.Text = "Hard Difficulty";
            }
        }
    }

    private void UpdateScoreLabel()
    {
        if (scoreLabel != null)                                                                            // Update the score label's text to display the player's score.
        {

            if (PlayerScore >= 0 && PlayerScore < 50 ){                                                    //scoreLabel.Text = "Player 2 Score: " + PlayerScore;
                scoreLabel.Text = "Player 2 Score: " + PlayerScore;
            }
            
            else {
                scoreLabel.Text = "Player 2 Wins " ;
                GetTree().Paused = true;
            }

        }
    }
}
