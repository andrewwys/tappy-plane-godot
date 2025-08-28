using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	[Export] private Node2D _pipesHolder;
	[Export] private PackedScene _pipesScene;
	[Export] private Timer _spawnTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_spawnTimer.Timeout += SpawnPipes;
		SpawnPipes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public float GetRandomY()
	{
		return (float)GD.RandRange(_spawnUpper.GlobalPosition.Y, _spawnLower.GlobalPosition.Y);
	}

	public void SpawnPipes()
	{
		var newPipes = _pipesScene.Instantiate<Pipes>();
		newPipes.Position = new Vector2(_spawnLower.GlobalPosition.X, GetRandomY());
		_pipesHolder.AddChild(newPipes);
	}
}
