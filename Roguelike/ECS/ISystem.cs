namespace Roguelike.ECS;

public interface ISystem
{
    public void ProcessEntities(IEnumerable<Entity> entities);
}
