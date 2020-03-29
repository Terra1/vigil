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
        private float _Angle = 0.0f;
        private float _Spin;
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
        public float GetAngle()
        {
            return _Angle;
        }
        internal void AddVelocity(Vector2 velocity)
        {
        }

        internal void UpdateMoves(Game1.ShipMovements shipMove)
        {
            _Velocity += shipMove.VelocityChange;
            _Spin += shipMove.SpinChange;
            _Angle += _Spin;
        }
    }
}
