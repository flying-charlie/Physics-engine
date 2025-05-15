using System.Numerics;

class PhysicsObject : PhysicsElement, IUpdatePosition
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float mass;

    public PhysicsObject(Vector3 position, float mass)
    {
        this.position = position;
        this.velocity = Vector3.Zero;
        this.mass = mass;
        this.acceleration = Vector3.Zero;
    }

    public PhysicsObject(Vector3 position, float mass, Vector3 velocity)
    {
        this.position = position;
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
        position += velocity * deltaTime;
        acceleration = new Vector3(0, 0, 0); // Reset acceleration after each update
    }
}