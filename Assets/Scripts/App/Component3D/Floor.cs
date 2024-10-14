using App.Entities;

namespace App.Component3D
{
    public class Floor : Object3D<FloorEntity>
    {
        public override void Init(FloorEntity entity)
        {
        }

        public override FloorEntity GetEntity()
        {
            return new FloorEntity()
            {
                ID = ID,
                Label = Label,
                Position = transform.localPosition,
                Rotation = transform.localRotation.eulerAngles,
                Scale = transform.localScale
            };
        }

        public override bool TryGetEntityIfChanged(out FloorEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}