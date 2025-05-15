abstract class Module
{
    public PhysicsObject physicsObject;

    public void Initialise(PhysicsObject physicsObject)
    {
        this.physicsObject = physicsObject;
        Initialise();
    }

    protected virtual void Initialise(){}
}