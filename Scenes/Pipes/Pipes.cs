using Godot;
using System;
using System.Runtime.Serialization;

public partial class Pipes : Node2D
{
	const float SCROLL_SPEED = 180.0f;

	[Export] private VisibleOnScreenNotifier2D _visibleNotifier;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_visibleNotifier.ScreenExited += OnScreenExited;
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
}
