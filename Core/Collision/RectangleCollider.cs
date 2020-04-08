using System;

namespace bdv
{
    public class RectangleCollider
    {
        private Entity a;
        private Entity b;
        private Point<float> positionA;
        private Point<float> positionB;
        public RectangleCollider(Entity a, Entity b)
        {
            this.a = a;
            this.b = b;
            this.positionA = a.position;
            this.positionB = b.position;

            if (this.positionA.x < this.positionB.x + this.b.dimension.Width &&
                this.positionA.x + this.a.dimension.Width > this.positionB.x &&
                this.positionA.y < this.positionB.y + b.dimension.Height &&
                this.positionA.y + this.a.dimension.Height > this.positionB.y)
            {

                var angle = (Math.Atan2(this.b.middle.y - this.a.middle.y,
                 this.b.middle.x - this.a.middle.x)) * (180 / Math.PI);

                if ((angle > -180 && angle < -135) || (angle > 135 && angle <= 180))
                {
                    this.positionA.x += this.a.speed.x;
                }
                if (angle > 45 && angle <= 135)
                {
                    this.positionA.y += -this.a.speed.y;
                }
                if ((angle >= 0 && angle < 45) || (angle <= 0 && angle > -45))
                {
                    this.positionA.x += -this.a.speed.y;
                }
                if (angle < -45 && angle > -135)
                {
                    this.positionA.y += this.a.speed.y;
                }
            }

        }

    }
}