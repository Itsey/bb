public partial class Box : CharacterBody2D {
    protected Bilge b;
    protected Controller ctrl;

    public override void _Ready() {
        ctrl = GetNode<Controller>("/root/Controller");
        b = ctrl.dt.CreateBilge("Main");
    }

    public int BoxStrength { get; set; } = 1;

    public void Hit(int ballPower) {
        b.Verbose.Log($"Ball {ballPower} hit Box {BoxStrength}");
        BoxStrength -= ballPower;
        if (BoxStrength <= 0) {
            b.Verbose.Log("Box destroyed");
            QueueFree();
        }
    }
    public override void _PhysicsProcess(double delta) {
    }

}
