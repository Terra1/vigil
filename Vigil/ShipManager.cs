using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigil
{
    class ShipManager
    {
        List<Ship> _Ships = new List<Ship>();

        public Ship SpawnShip()
        {
            _Ships.Add(new Ship());
            return _Ships.Last();
        }
        public bool DestroyShip( Ship ship )
        {
            return _Ships.Remove(ship);
        }
    }
}
