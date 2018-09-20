namespace Skight.Core.DI
{
    public static class ContainerHumanInterfaces
    {
        public static T get<T>(this Container container)
        {
            return (T) container.get(typeof(T));
        }
    }
}