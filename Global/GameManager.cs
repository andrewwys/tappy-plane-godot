using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	public const float SCROLL_SPEED = 180.0f;

	private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");
	private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void LoadMain()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
	}

	public static void LoadGame()
	{
		ScoreManager.ResetScore();
		Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
	} 
}
