using Godot;

public partial class Ball : CharacterBody2D {
    private const float Speed = 300.0f;

    private Vector2 velocity = new Vector2(1, -1).Normalized() * Speed;

    public override void _PhysicsProcess(double delta) {
        //Vector2 velocity = new Vector2(1, -1);


        var col = MoveAndCollide(velocity * (float)delta);
        if (col != null) {

            var hitWhat = col.GetCollider();

            if (hitWhat is Node n) {
                GD.Print($"Collision with {n.Name}");
                if (n.Name == "baseline") {
                    this.QueueFree();
                }
            }

            velocity = velocity.Bounce(col.GetNormal());
        }
    }
}
