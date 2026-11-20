using Godot;
using Plisky.Diagnostics;

public partial class Ball : CharacterBody2D {
    protected Bilge b;
    protected Controller ctrl;

    private const float Speed = 300.0f;
    private const float VelocityMultiplier = 1.3f;
    [Export] private Sprite2D BallSprite;
    [Export] private Timer SpeedUpTimer;

    override public void _Ready() {
        ctrl = GetNode<Controller>("/root/Controller");
        b = ctrl.dt.CreateBilge("Ball");
        SpeedUpTimer.Timeout += OnSpeedUpTimerTimeout;
    }

    public override void _Input(InputEvent @event) {
        base._Input(@event);
    }

    public override void _PhysicsProcess(double delta) {

        var col = MoveAndCollide(Velocity * (float)delta);
        if (col != null) {

            var hitWhat = col.GetCollider();

            if (hitWhat is Node n) {
                b.Info.Log($"Collision with {n.Name}");
                if (n.Name == "baseline") {
                    this.QueueFree();
                }
                if (n.Name == "Box") {
                    var box = n as Box;
                    box.Hit(1);
                    ctrl.BoxDestroyed();  // todo wrong loc
                }
            }

            Velocity = Velocity.Bounce(col.GetNormal());
        }
    }

    private void OnSpeedUpTimerTimeout()
    {
        Velocity *= VelocityMultiplier;
        GD.Print($"Speeding up to {Velocity.Length()}");
    }
}
