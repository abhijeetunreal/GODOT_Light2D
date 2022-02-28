using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export] public int speed = 200;
	[Export] public float rotationSpeed = 5f;
	

	public Vector2 velocity = new Vector2();
	public int rotationDir = 0;
	

	public void GetInput()
	{
		velocity = new Vector2();
		rotationDir = 0;
	

		if (Input.IsActionPressed("right"))
			rotationDir += 1;

		if (Input.IsActionPressed("left"))
			rotationDir -= 1;
		

		if (Input.IsActionPressed("down"))
			velocity = new Vector2(-speed, 0).Rotated(Rotation);
			

		if (Input.IsActionPressed("up"))
			velocity = new Vector2(speed, 0).Rotated(Rotation);

		velocity = velocity.Normalized() * speed;
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		Rotation += rotationDir * rotationSpeed * delta;
		velocity = MoveAndSlide(velocity);
	}
}
