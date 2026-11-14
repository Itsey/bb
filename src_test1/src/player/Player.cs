using Godot;

public partial class Player : Sprite2D {
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Texture = GD.Load<Texture2D>("res://player/spritecreate.png");

        Hframes = FrameCount;
        Vframes = 1;

        SetAngle(180);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
    }



    private const int FrameCount = 37;
    private const float AngleStep = 5.0f;

    public void SetAngle(float angle) {
        angle = Mathf.Clamp(angle, 0.0f, 180.0f);

        Frame = Mathf.RoundToInt(
            (180.0f - angle) / AngleStep
        );
    }
}
