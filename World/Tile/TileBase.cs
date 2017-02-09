using System;
using System.Collections.Generic;
using World.StaticEntity;

namespace World.Tile {
    public class TileBase : ITile {
        private TileTypes _tileType;
        private IList<IStaticEntity> _staticEntities;
        private int _x;
        private int _y;
        private int _z;
        #region ITile implementation
        public TileTypes TileType {
            get {
                return _tileType;
            }
        }

        public System.Collections.Generic.IList<global::World.StaticEntity.IStaticEntity> StaticEntities {
            get {
                return _staticEntities;
            }
        }

        public int X {
            get {
                return _x;
            }
        }

        public int Y {
            get {
                return _y;
            }
        }

        public int Z {
            get {
                return _z;
            }
        }
        #endregion
        public TileBase(int x, int y, int z, TileTypes tileType = TileTypes.Air) {
            _x = x;
            _y = y;
            _z = z;
            _tileType = tileType;
            _staticEntities = new List<IStaticEntity>();
        }
    }
}

