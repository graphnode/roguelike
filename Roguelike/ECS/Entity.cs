using System.Collections;

namespace Roguelike.ECS;

public class Entity : IEnumerable<IComponent>
{
    private readonly Dictionary<Type, IComponent> components = new();
    
    public void Add(IComponent component)
    {
        if (components.ContainsKey(component.GetType()))
            return;
        
        components.Add(component.GetType(), component);
    }
    
    public T? Get<T>() where T : class, IComponent
    {
        if (components.TryGetValue(typeof(T), out var component))
            return component as T;

        return null;
    }

    public bool Has<T>() where T : IComponent
    {
        return components.ContainsKey(typeof(T));
    }

    public bool Remove<T>() where T : IComponent, new()
    {
        return components.Remove(typeof(T));
    }

    IEnumerator<IComponent> IEnumerable<IComponent>.GetEnumerator() => components.Values.GetEnumerator();
    public IEnumerator GetEnumerator() => components.Values.GetEnumerator();
}