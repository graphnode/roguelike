using Roguelike.Extensions;

namespace Roguelike.ECS;

public class World
{
    private readonly HashSet<ISystem> systems = new();
    private readonly HashSet<Entity> entities = new();

    public void AddSystems(params ISystem[] newSystems)
    {
        systems.AddRange(newSystems);
    }

    public void AddEntity(params Entity[] newEntities)
    {
        entities.AddRange(newEntities);
    }
    
    public Entity CreateAndAddEntity(params IComponent[] newComponents)
    {
        var entity = new Entity();
        
        foreach (var component in newComponents)
        {
            entity.Add(component);
            // TODO: Notify systems.
        }

        entities.Add(entity);
        
        return entity;
    }

    public void DeleteEntity(Entity entity)
    {
        entities.Remove(entity);
        // TODO: Notify systems.
    }

    public void Run()
    {
        foreach (var system in systems)
            system.ProcessEntities(entities);
    }
}