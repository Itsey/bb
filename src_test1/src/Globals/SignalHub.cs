public partial class SignalHub : Node
{
    public static SignalHub Instance { get; private set; }
    [Signal] public delegate void OnBallExitEventHandler();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public static void EmitBallExit()
    {
        Instance.EmitSignal(SignalName.OnBallExit);
    }
}
