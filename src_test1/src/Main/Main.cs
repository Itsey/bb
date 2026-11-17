using Godot;
using Plisky.Diagnostics;
using System;

public partial class Main : Node2D {
    protected Bilge b;
    private PackedScene ballScene;
    private PackedScene boxScene;
    protected Controller ctrl;

    protected int boxCount = 0;

    public override void _Ready() {
        ballScene = ResourceLoader.Load<PackedScene>("res://Ball/ball.tscn");
        boxScene = ResourceLoader.Load<PackedScene>("res://Boxes/box.tscn");
        ctrl = GetNode<Controller>("/root/Controller");
        b = ctrl.dt.CreateBilge("Main");

    }

    public override void _UnhandledInput(InputEvent @event) {
        base._UnhandledInput(@event);

        if (@event.IsActionPressed("ui_launchBall")) {
            b.Info.Log("ball launch request recieved");
            FireBall(Vector2.Zero);
        }
    }
    public override void _Process(double delta) {

        var br = ctrl.BoxesRequired();
        foreach (var b in br) {
            SpawnBox(b);
        }

        if (Input.IsActionPressed("ui_aimBall")) {
            var turret = GetNode<Sprite2D>("Player/Turret");
            b.Verbose.Log("Aiming");
            Vector2 mousePosition = GetGlobalMousePosition();
            var ttarg = turret.GetAngleTo(mousePosition);
            turret.Rotate(ttarg);
            // Add for debugging.  b.Direct.Write($"[STAT][Direction]", $"{mousePosition.Angle()}");
        }

        if (Input.IsActionJustReleased("ui_aimBall")) {
            var turret = GetNode<Sprite2D>("Player/Turret");
            b.Verbose.Log("Aiming released");
            Vector2 direction = Vector2.Right.Rotated(turret.GlobalRotation);
            b.Info.Log($"fire control T:{Mathf.RadToDeg(turret.GlobalRotation).ToString()}[{turret.GlobalRotation}] B:{Mathf.RadToDeg(direction.Angle()).ToString()} [{direction.Angle()}]");

            FireBall(direction);

        }

    }

    private void SpawnBox(BoxRequest b) {
        var boxInstance = boxScene.Instantiate<Box>();
        AddChild(boxInstance);
        int xloc = 100 + Random.Shared.Next(400);
        boxInstance.GlobalPosition = new Vector2(xloc, 200);
        ctrl.BoxCreated();

    }

    private void FireBall(Vector2 mousePosition) {
        if (mousePosition == Vector2.Zero) {
            mousePosition = new Vector2(1, -1);
        }

        var ballInstance = ballScene.Instantiate<Ball>();
        AddChild(ballInstance);

        var spawn = GetNode<Marker2D>("Player/Turret/LaunchPosition");


        ballInstance.GlobalPosition = spawn.GlobalPosition;
        mousePosition = mousePosition.Normalized() * ctrl.Speed;
        ballInstance.Velocity = mousePosition;
    }
}
