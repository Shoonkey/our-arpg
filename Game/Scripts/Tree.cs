using Godot;
using System;

public enum TreeState {
	Natural,
	Infected,
	Corrupted
};

public partial class Tree : StaticBody2D
{
	[Export]
	public TreeState _treeState = TreeState.Natural;

	private Sprite2D _sprite;

	private Texture2D _treeNatural = ResourceLoader.Load<Texture2D>("res://Assets/Tree.png");
	private Texture2D _treeInfected = ResourceLoader.Load<Texture2D>("res://Assets/TreeInfected.png");
	private Texture2D _treeCorrupted = ResourceLoader.Load<Texture2D>("res://Assets/TreeCorrupted.png");

	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>(nameof(Sprite2D));
	}

	public override void _Process(double delta)
	{
		_sprite.Texture = _treeState switch {
			TreeState.Natural => _treeNatural,
			TreeState.Infected => _treeInfected,
			TreeState.Corrupted => _treeCorrupted,
			_ => throw new NotImplementedException("Invalid tree state")
		};
	}
}
