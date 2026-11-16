using Godot;
using Plisky.Diagnostics;

public partial class Main : Node2D {
	protected Bilge b;
	private PackedScene ballScene;
	protected Controller ctrl;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		ballScene = ResourceLoader.Load<PackedScene>("res://Ball/ball.tscn");
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
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		if (Input.IsActionPressed("ui_aimBall")) {
			var turret = GetNode<Sprite2D>("Player/Turret");
			b.Verbose.Log("Aiming");
			Vector2 mousePosition = GetGlobalMousePosition();
			turret.LookAt(mousePosition);
			turret.Rotate(1.57f);
			// Add for debugging.  b.Direct.Write($"[STAT][Direction]", $"{mousePosition.Angle()}");
		}

		if (Input.IsActionJustReleased("ui_aimBall")) {
			var turret = GetNode<Sprite2D>("Player/Turret");
			b.Verbose.Log("Aiming released");
			Vector2 direction = Vector2.Right.Rotated(turret.GlobalRotation);
			direction = direction.Rotated(4.712f);
			FireBall(direction);

		}

	}

	private void FireBall(Vector2 mousePosition) {
		if (mousePosition == Vector2.Zero) {
			mousePosition = new Vector2(1, -1);
		}

		var ballInstance = ballScene.Instantiate<Ball>();
		AddChild(ballInstance);

		var spawn = GetNode<Marker2D>("Player/LaunchPosition");


		ballInstance.GlobalPosition = spawn.GlobalPosition;
		mousePosition = mousePosition.Normalized() * ctrl.Speed;
		ballInstance.Velocity = mousePosition;



	}
}
