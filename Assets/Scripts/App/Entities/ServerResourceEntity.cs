namespace App.Entities
{
    public class ServerResourceEntity : IServerEntity<ResourceEntity>
    {
        public string seq { get; set; }
        public string objectId { get; set; }
        public string position_x { get; set; }
        public string position_y { get; set; }
        public string position_z { get; set; }
        public string rotation_x { get; set; }
        public string rotation_y { get; set; }
        public string rotation_z { get; set; }
        public string scale_x { get; set; }
        public string scale_y { get; set; }
        public string scale_z { get; set; }

        public bool CompareWith(ResourceEntity other)
        {
            return true;
        }
    }
}