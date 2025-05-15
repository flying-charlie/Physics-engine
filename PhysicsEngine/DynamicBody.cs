using System.Numerics;

class DynamicBody : Module, IUpdatePosition
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public float mass;

    public DynamicBody(float mass)
    {
        this.velocity = Vector3.Zero;
        this.mass = mass;
        this.acceleration = Vector3.Zero;
    }

    public DynamicBody(float mass, Vector3 velocity)
    {
        this.velocity = velocity;
        this.mass = mass;
        this.acceleration = Vector3.Zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    public void ApplyImpulse(Vector3 impulse)
    {
        velocity += impulse / mass;
    }

    public void UpdatePosition(float deltaTime)
    {
        velocity += acceleration * deltaTime;
        physicsObject.position += velocity * deltaTime;
        acceleration = new Vector3(0, 0, 0); // Reset acceleration after each update
    }
}