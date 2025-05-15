using System.Reflection;
using System.Runtime.CompilerServices;
using System.Timers;

class Engine
{
    DateTime last_frame;
    public int framerate;
    public System.Timers.Timer frameTimer;
    private List<PhysicsObject> physicsObjects;

    public Engine(int framerate)
    {
        this.framerate = framerate;

        frameTimer = new System.Timers.Timer(1000 / framerate);
        // Hook up the Elapsed event for the timer. 
        frameTimer.Elapsed += FrameUpdate;
        frameTimer.AutoReset = true;
        frameTimer.Stop();

        this.physicsObjects = [];
    }

    public Engine(int framerate, List<PhysicsObject> physicsElements)
    {
        this.framerate = framerate;

        frameTimer = new System.Timers.Timer(1000 / framerate);
        // Hook up the Elapsed event for the timer. 
        frameTimer.Elapsed += FrameUpdate;
        frameTimer.AutoReset = true;
        frameTimer.Stop();

        this.physicsObjects = physicsElements;
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

    public void Initialise()
    {
        foreach (PhysicsObject physicsObject in physicsObjects)
        {
            physicsObject.Initialise();
        }
    }

    public void FrameUpdate(object? sender, ElapsedEventArgs e)
    {
        DateTime time = DateTime.Now;
        float deltaTime = (float) (time - last_frame).TotalSeconds;
        last_frame = time;

        // Update Forces
        foreach (PhysicsObject element in physicsObjects)
        {
            foreach (Module module in element.modules)
            {
                var iUpdateForces = module as IUpdateForces;
                if (iUpdateForces is not null)
                {
                    iUpdateForces.UpdateForce(deltaTime);
                }
            }
        }

        // Update Positions
        foreach (PhysicsObject element in physicsObjects)
        {
            foreach (Module module in element.modules)
            {
                var iUpdatePosition = module as IUpdatePosition;
                if (iUpdatePosition is not null)
                {
                    iUpdatePosition.UpdatePosition(deltaTime);
                }
            }
        }

        Console.WriteLine(((PhysicsObject) physicsObjects[0]).position);
    }
}