using Godot;

public partial class Ball : CharacterBody2D {



    public override void _PhysicsProcess(double delta) {

        Vector2 velocity = new Vector2(1, -1);
        var col = MoveAndCollide(velocity * (float)delta);
        if (col != null) {
            GD.Print("Collision with: " + col.GetCollider());
        }
    }
}
