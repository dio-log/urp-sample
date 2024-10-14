using App.Entities;

namespace App.Component3D
{
    public class Floor : Object3D<FloorEntity>
    {
        //어떤 서버 엔티티가 와도 비교가능해야됨


        protected override FloorEntity OriginEntity { get; set; }

        public override void Init(FloorEntity entity)
        {
            OriginEntity = entity;
            
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