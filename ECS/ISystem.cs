namespace Roguelike.ECS;

public interface ISystem
{
    public void Process(Entity e);
}