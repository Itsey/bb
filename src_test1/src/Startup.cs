using Godot;
using Plisky.Diagnostics;
using Plisky.Diagnostics.Listeners;

public partial class Startup : Node {
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        GD.Print("BustABox Online.");
        var hnd = new TCPHandler("127.0.0.1", 9060);
        hnd.SetFormatter(new FlimFlamV4Formatter());
        Bilge.AddHandler(hnd);
        Bilge.SetConfigurationResolver((a, b) => {
            return System.Diagnostics.SourceLevels.Verbose;
        });


        Bilge.Alert.Online("BustABox");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
    }
}
