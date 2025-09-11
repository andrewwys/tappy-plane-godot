using Godot;

public partial class Plane : CharacterBody2D
{
	const float GRAVITY = 800.0f;
	const float POWER = -300.0f;

	// Export event handler for plane hitting the floor or pipes
	

	[Export] private AnimationPlayer _animationPlayer;
	[Export] private AnimatedSprite2D _planeSprite;

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

		if (IsOnFloor())
		{
			GD.Print("Hit the floor");
			Die();
		}
	}

	public void Die()
	{
		GD.Print("Plane Died");
		_planeSprite.Stop();
		SetPhysicsProcess(false);
		SignalManager.EmitOnPlaneDied();
	}
}
