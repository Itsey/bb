using Godot;
using Plisky.Diagnostics;

public partial class Controller : Node {
    protected Bilge b;
    public DynamicTrace dt = new DynamicTrace();
    public float Speed { get; set; } = 300.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        b = dt.CreateBilge("Controller");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
    }


    public int BoxCount { get; set; } = 0;
    internal BoxRequest[] BoxesRequired() {

        if (BoxCount > 0) {
            return [];
        }
        return [new BoxRequest() { GridX = 2, GridY = 3 }];
    }

    internal void BoxCreated() {
        b.Verbose.Log("Box Created");
        BoxCount++;
    }

    internal void BoxDestroyed() {
        b.Verbose.Log("Box Destroyed");
        BoxCount--;
    }
}
