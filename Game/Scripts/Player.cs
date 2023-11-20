using Godot;
using System;

enum PlayerState
{
	Move
};

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 200.0f;

	private PlayerState _playerState = PlayerState.Move;

	public override void _PhysicsProcess(double delta)
	{
		if (_playerState == PlayerState.Move)
			MoveState();
	}

	private void MoveState()
	{
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
			Velocity = direction * Speed;
		else
			Velocity = Vector2.Zero;

		MoveAndSlide();
	}
}
