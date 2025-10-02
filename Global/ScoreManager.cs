using Godot;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }

	private uint _score = 0;
	private uint _highScore = 0;
	private const string SCORE_FILE = "user://tappy.save";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		ResetScore();
		LoadScoreFromFile();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _ExitTree()
	{
		SaveScoreToFile();
	}

	public static uint GetScore()
	{
		return Instance._score;
	}

	public static void SetScore(uint score)
	{
		Instance._score = score;
		if (score > Instance._highScore)
		{
			Instance._highScore = score;
		}
		SignalManager.EmitOnScored();
	}

	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}

	public static uint GetHighScore()
	{
		return Instance._highScore;
	}

	public static void SetHighScore(uint highScore)
	{
		Instance._highScore = highScore;
	}

	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Write);
		file?.Store32(_highScore);
	}

	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(SCORE_FILE, FileAccess.ModeFlags.Read);
		_highScore = file?.Get32() ?? 0;
	}
}
