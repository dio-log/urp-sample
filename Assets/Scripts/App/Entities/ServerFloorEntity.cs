namespace App.Entities
{
    public class ServerFloorEntity : IServerEntity<FloorEntity>
    {
        public bool CompareWith(FloorEntity other)
        {
            return false;
        }
    }
}