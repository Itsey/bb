using Godot;

public partial class Player : Area2D
{
    [Export] private Marker2D LaunchMarker;
    [Export] private Sprite2D TurretSprite;
    public Marker2D LaunchPosition => LaunchMarker;
    public Sprite2D Turret => TurretSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
