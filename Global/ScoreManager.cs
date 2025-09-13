using Godot;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }

	private int _score = 0;
	private int _highScore = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		ResetScore();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static int GetScore()
	{
		return Instance._score;
	}

	public static void SetScore(int score)
	{
		Instance._score = score;
		if (score > Instance._highScore)
		{
			Instance._highScore = score;
		}
	}

	public static void ResetScore()
	{
		Instance._score = 0;
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}

	public static int GetHighScore()
	{
		return Instance._highScore;
	}

	public static void SetHighScore(int highScore)
	{
		Instance._highScore = highScore;
	}
}
