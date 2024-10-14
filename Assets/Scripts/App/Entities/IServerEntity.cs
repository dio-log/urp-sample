namespace App.Entities
{
    public interface IServerEntity<T> where T : IEntity
    {
        public bool CompareWith(T other);
    }
}