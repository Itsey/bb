using Godot;

public partial class Main : Node2D {
    private PackedScene ballScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        ballScene = ResourceLoader.Load<PackedScene>("res://Ball/ball.tscn");
    }

    // public override void _UnhandledInput(InputEvent @event) {
    //     base._UnhandledInput(@event);

    //     if (@event.IsActionPressed("ui_launchBall")) {
    //         GD.Print("yhup1");
    //         FireBall();
    //     } else {
    //         GD.Print("nope1");
    //     }

    // }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {

        if (Input.IsActionJustPressed("ui_launchBall")) {
            FireBall();
        } else {

        }
    }

    private void FireBall() {

        var ballInstance = ballScene.Instantiate<Ball>();
        AddChild(ballInstance);

        var spawn = GetNode<Marker2D>("LaunchPosition");
        ballInstance.GlobalPosition = spawn.GlobalPosition;


    }
}
