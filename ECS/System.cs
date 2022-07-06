namespace Roguelike.ECS;

public abstract class System : ISystem
{
    public virtual void ProcessEntities(IEnumerable<Entity> entities)
    {
        // Do nothing by default.
    }
}

public abstract class System<T0> : ISystem where T0 : IComponent
{
    public virtual void ProcessEntities(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
            if (entity.Has<T0>())
                Process(entity);
    }
    
    public abstract void Process(Entity e);
}

public abstract class System<T0, T1> : ISystem 
    where T0 : IComponent
    where T1 : IComponent
{
    public virtual void ProcessEntities(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
            if (entity.Has<T0>() && entity.Has<T1>())
                Process(entity);
    }
    
    public abstract void Process(Entity e);
}

public abstract class System<T0, T1, T2> : ISystem 
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
{
    public virtual void ProcessEntities(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
            if (entity.Has<T0>() && entity.Has<T1>() && entity.Has<T2>())
                Process(entity);
    }
    
    public abstract void Process(Entity e);
}

public abstract class System<T0, T1, T2, T3> : ISystem 
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
{
    public virtual void ProcessEntities(IEnumerable<Entity> entities)
    {
        foreach (var entity in entities)
            if (entity.Has<T0>() && entity.Has<T1>() && entity.Has<T2>() && entity.Has<T3>())
                Process(entity);
    }
    
    public abstract void Process(Entity e);
}