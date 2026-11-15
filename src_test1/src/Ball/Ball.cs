using Godot;

public partial class Ball : CharacterBody2D {
    private const float Speed = 300.0f;

    private Vector2 velocity = new Vector2(1, -1).Normalized() * Speed;

    public override void _PhysicsProcess(double delta) {
        //Vector2 velocity = new Vector2(1, -1);


        var col = MoveAndCollide(velocity * (float)delta);
        if (col != null) {
            GD.Print("Collision with: " + col.GetCollider());
            velocity = velocity.Bounce(col.GetNormal());
        }
    }
}
