
using System.Numerics;
using System.Runtime;

class ConstantForce : PhysicsElement, IUpdateForces
{
    public PhysicsObject target;
    public Vector3 force;

    public ConstantForce(PhysicsObject target, Vector3 force)
    {
        this.target = target;
        this.force = force;
    }

    public void UpdateForce(float deltaTime)
    {
        target.ApplyForce(force);
    }
}