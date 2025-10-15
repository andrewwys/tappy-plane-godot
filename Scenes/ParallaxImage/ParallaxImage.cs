using Godot;
using System;

public partial class ParallaxImage : Parallax2D
{
	[Export] private Texture2D _scrTexture;
	[Export] private Sprite2D _sprite2D;
	[Export] private float _speedScale; // 0 - 1

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
		Autoscroll = new Vector2(-_speedScale * GameManager.SCROLL_SPEED, 0);
		float scaleFactor = GetViewportRect().Size.Y / _scrTexture.GetHeight();

		_sprite2D.Texture = _scrTexture;
		_sprite2D.Scale = new Vector2(scaleFactor, scaleFactor);

		RepeatSize = new Vector2(_scrTexture.GetWidth() * scaleFactor, 0);
    }
}
