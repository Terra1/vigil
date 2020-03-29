using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigil
{
    public class Ship
    {
        private Vector2 _Velocity;
        private Vector2 _Angle;
        private Vector2 _Spin;
        private ShipType _Type;

        public Ship( ShipType type )
        {
            _Type = type;
        }
        public ShipType GetShipType()
        {
            return _Type;
        }
        public Vector2 GetVelocity()
        {
            return _Velocity;
        }
        internal void AddVelocity(Vector2 velocity)
        {
            _Velocity += velocity;
        }
    }
}
