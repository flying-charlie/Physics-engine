using System.Runtime.CompilerServices;
using System.Timers;

class Engine
{
    DateTime last_frame;
    public int framerate;
    public System.Timers.Timer frameTimer;
    private List<PhysicsElement> physicsElements;

    public Engine(int framerate)
    {
        this.framerate = framerate;

        frameTimer = new System.Timers.Timer(1000 / framerate);
        // Hook up the Elapsed event for the timer. 
        frameTimer.Elapsed += FrameUpdate;
        frameTimer.AutoReset = true;
        frameTimer.Stop();

        this.physicsElements = [];
    }

    public Engine(int framerate, List<PhysicsElement> physicsElements)
    {
        this.framerate = framerate;

        frameTimer = new System.Timers.Timer(1000 / framerate);
        // Hook up the Elapsed event for the timer. 
        frameTimer.Elapsed += FrameUpdate;
        frameTimer.AutoReset = true;
        frameTimer.Stop();

        this.physicsElements = physicsElements;
    }

    public void Start()
    {
        last_frame = DateTime.Now;
        frameTimer.Start();
    }

    public void Stop()
    {
        frameTimer.Stop();
    }

    public void FrameUpdate(object? sender, ElapsedEventArgs e)
    {
        DateTime time = DateTime.Now;
        float deltaTime = (float) (time - last_frame).TotalSeconds;
        last_frame = time;

        // Update Forces
        foreach (PhysicsElement physics_object in physicsElements)
        {
            var iUpdateForces = physics_object as IUpdateForces;
            if (iUpdateForces is not null)
            {
                iUpdateForces.UpdateForce(deltaTime);
            }
        }

        // Update Positions
        foreach (PhysicsElement physics_object in physicsElements)
        {
            var iUpdatePosition = physics_object as IUpdatePosition;
            if (iUpdatePosition is not null)
            {
                iUpdatePosition.UpdatePosition(deltaTime);
            }
        }

        Console.WriteLine(((PhysicsObject) physicsElements[0]).position);
    }
}