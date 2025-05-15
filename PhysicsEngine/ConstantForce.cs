
using System.Dynamic;
using System.Numerics;
using System.Runtime;

class ConstantForce : Module, IUpdateForces
{
    public Vector3 force;
    public DynamicBody? dynamicBody;

    protected override void Initialise()
    {
        dynamicBody = physicsObject.GetModule<DynamicBody>();

        if (dynamicBody is null)
        {
            throw new ModuleMissingException("Constant force module requires a dynamic body module.");
        }
    }

    public ConstantForce(Vector3 force)
    {
        this.force = force;
    }

    public void UpdateForce(float deltaTime)
    {
        dynamicBody.ApplyForce(force);
    }
}