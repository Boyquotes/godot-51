using Godot;
using System;

public class Player : KinematicBody2D
{
    Vector2 velocity;

    public override void _Ready()
    {
        velocity = new Vector2(0, 0);
    }

    public override void _Process(float delta)
    {
        MoveAndSlide(velocity * 400);
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey eventKey)
        {
            if (eventKey.Pressed)
            {
                if (eventKey.Scancode == (int)KeyList.Up)
                {
                    velocity.y -= 1;
                }

                if (eventKey.Scancode == (int)KeyList.Down)
                {
                    velocity.y += 1;
                }
            }
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape)
            {
                GetTree().Quit();
            }
        }
    }
}
