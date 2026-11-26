public partial class Level : Node2D
{
    protected Bilge b;
    private Sprite2D TurretSprite;
    private PackedScene ballScene;
    private PackedScene boxScene;
    protected Controller ctrl;

    protected int boxCount = 0;
    private bool isBallOnScreen;
    [Export] private Player PlayerArea;

    public override void _Ready()
    {
        ballScene = ResourceLoader.Load<PackedScene>("res://Ball/Ball.tscn");
        boxScene = ResourceLoader.Load<PackedScene>("res://Boxes/Box.tscn");
        ctrl = GetNode<Controller>("/root/Controller");
        b = ctrl.dt.CreateBilge("Main");

        TurretSprite = PlayerArea.Turret;
        SignalHub.Instance.OnBallExit += OnBallExit;
        SpawnBox(new BoxRequest());
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        if (@event.IsActionPressed("ui_launchBall") && !isBallOnScreen) {
            b.Info.Log("ball launch request recieved");
            FireBall(Vector2.Zero);
        }
    }
    public override void _Process(double delta)
    {

        if (Input.IsActionPressed("ui_aimBall")) {
            b.Verbose.Log("Aiming");
            Vector2 mousePosition = GetGlobalMousePosition();
            Vector2 direction = mousePosition - TurretSprite.GlobalPosition;
            if (direction != Vector2.Zero) {
                var target = Vector2.Up.AngleTo(direction);
                TurretSprite.GlobalRotation = Mathf.Clamp(target, -Mathf.Pi / 2 + 0.2f, Mathf.Pi / 2 - 0.2f);
            }
        }

        if (Input.IsActionJustReleased("ui_aimBall") && !isBallOnScreen) {
            b.Verbose.Log("Aiming released");
            Vector2 direction = Vector2.Up.Rotated(TurretSprite.GlobalRotation);
            b.Info.Log($"fire control T:{Mathf.RadToDeg(TurretSprite.GlobalRotation)}[{TurretSprite.GlobalRotation}] B:{Mathf.RadToDeg(direction.Angle()).ToString()} [{direction.Angle()}]");

            FireBall(direction);
        }
    }

    private void SpawnBox(BoxRequest b)
    {
        var boxInstance = boxScene.Instantiate<Box>();
        AddChild(boxInstance);
        int xloc = 100 + Random.Shared.Next(400);
        boxInstance.GlobalPosition = new Vector2(xloc, 200);
        ctrl.BoxCreated();

    }

    private void FireBall(Vector2 mousePosition)
    {
        if (mousePosition == Vector2.Zero) {
            mousePosition = Vector2.Up.Rotated(TurretSprite.GlobalRotation);
        }

        var ballInstance = ballScene.Instantiate<Ball>();
        AddChild(ballInstance);

        var spawn = PlayerArea.LaunchPosition;


        ballInstance.GlobalPosition = spawn.GlobalPosition;
        mousePosition = mousePosition.Normalized() * ctrl.Speed;
        ballInstance.Velocity = mousePosition;
        isBallOnScreen = true;
    }
    private void OnBallExit()
    {
        foreach (var b in GetChildren())
        {
            if (b is Box box)
                box.GlobalPosition += new Vector2(0, 100); // move down one step
        }
        var br = ctrl.BoxesRequired();
        GD.Print("Boxes required: " + ctrl.BoxCount);
        foreach (var b in br) {
            SpawnBox(b);
        }
        isBallOnScreen = false;
    }
}
