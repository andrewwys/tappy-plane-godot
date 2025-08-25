using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	const float GRAVITY = 800.0f;
	const float POWER = -400.0f;

	[Export] private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = POWER;
			// play animation
			_animationPlayer.Play("POWER");
		}
		else
		{
			velocity.Y += GRAVITY * (float)delta;
		}
		Velocity = velocity;
		MoveAndSlide();

		
	}
}
