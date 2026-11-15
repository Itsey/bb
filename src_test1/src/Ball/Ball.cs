using Godot;
using Plisky.Diagnostics;

public partial class Ball : CharacterBody2D {
    protected Bilge b;
    protected Controller ctrl;

    private const float Speed = 300.0f;

    override public void _Ready() {
        ctrl = GetNode<Controller>("/root/Controller");
        b = ctrl.dt.CreateBilge("Ball");
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
            }

            Velocity = Velocity.Bounce(col.GetNormal());
        }
    }
}
