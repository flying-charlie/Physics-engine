using System.Numerics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Timers;

ConstantForce force = new(new Vector3(2f, 0, 0));
DynamicBody dynamicBody = new(1);
PhysicsObject object1 = new(Vector3.Zero, [force, dynamicBody]);

List<PhysicsObject> physicsObjects = [object1];

Engine engine = new(60, physicsObjects);

engine.Initialise();
engine.Start();

Thread.Sleep(4000);

physicsObjects[0].GetModule<DynamicBody>().ApplyImpulse(new Vector3(-10, 0, 0));

while(true)
{

}

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();

