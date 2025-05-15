using System.Numerics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Timers;

PhysicsObject object1 = new(new Vector3(0, 0, 0), 1, new Vector3(-1, 0, 0));
ConstantForce force1 = new(object1, new Vector3(2f, 0, 0));

List<PhysicsElement> physicsObjects = [object1, force1];

Engine engine = new(60, physicsObjects);

engine.Start();

Thread.Sleep(4000);

((PhysicsObject) physicsObjects[0]).ApplyImpulse(new Vector3(-10, 0, 0));

while(true)
{

}

// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();

