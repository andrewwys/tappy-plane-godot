using Godot;
using System;
using System.Runtime.Serialization;

public partial class Pipes : Node2D
{
	const float SCROLL_SPEED = 180.0f;

	[Export] private VisibleOnScreenNotifier2D _visibleNotifier;

	private Area2D _upperPipe;
	private Area2D _lowerPipe;
	private Area2D _laser;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get Nodes
		_upperPipe = GetNode<Area2D>("UpperPipe");
		_lowerPipe = GetNode<Area2D>("LowerPipe");
		_laser = GetNode<Area2D>("Laser");

		// Connect signals
		_visibleNotifier.ScreenExited += OnScreenExited;
		_upperPipe.BodyEntered += OnPipeBodyEntered;
		_lowerPipe.BodyEntered += OnPipeBodyEntered;
		_laser.BodyEntered += OnLaserBodyEntered;

		SignalManager.Instance.OnPlaneDied += OnPlaneDied;
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
	}

	private void OnPlaneDied()
	{
		SetPhysicsProcess(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position += new Vector2(-SCROLL_SPEED * (float)delta, 0);
	}

	public void OnScreenExited()
	{
		QueueFree();
	}

	private void OnPipeBodyEntered(Node2D body)
	{
		if (body is Plane)
		{
			GD.Print($"{body.Name} hit a pipe");
			(body as Plane).Die();
		}
	}
	
	private void OnLaserBodyEntered(Node2D body)
	{
		if (body is Plane)
		{
			ScoreManager.IncrementScore();
			// GD.Print($"Score: {ScoreManager.GetScore()}, High Score: {ScoreManager.GetHighScore()}");
		}
	}
}
