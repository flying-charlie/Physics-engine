
using System.Numerics;
using System.Reflection;

class PhysicsObject
{
    public List<Module> modules;
    public Vector3 position;

    public PhysicsObject(Vector3 position, List<Module> modules)
    {
        this.position = position;
        this.modules = modules;
    }

    public PhysicsObject(Vector3 position)
    {
        this.position = position;
        this.modules = [];
    }

    public PhysicsObject()
    {
        this.position = Vector3.Zero;
        this.modules = [];
    }

    public void Initialise()
    {
        foreach (Module module in modules)
        {
            module.Initialise(this);
        }
    }

    public T? GetModule<T>() where T : Module
    {
        return (T?) modules.Find(module => module is T);
    }

    public void AddModule(Module module)
    {
        modules.Add(module);
    }
}