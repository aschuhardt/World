using System;
using System.Collections.Generic;
using System.Text;
using World.StaticEntity;

namespace World.Tile {
    public abstract class TileBase : ITile {
        private TileTypes _tileType;
        private int _x;
        private int _y;
        private int _z;
        private bool _shouldLoad;

        #region ITile implementation
        public TileTypes TileType {
            get {
                return _tileType;
            }
        }

        public int X {
            get {
                return _x;
            }
            set {
                _x = value;
            }
        }

        public int Y {
            get {
                return _y;
            }
            set {
                _y = value;
            }
        }

        public int Z {
            get {
                return _z;
            }
            set {
                _z = value;
            }
        }

        public virtual string Serialized {
            get {
                var sb = new StringBuilder();
                sb.Append("{ ");
                sb.AppendFormat("\"TileType\": {0},", (int)this.TileType);
                sb.AppendFormat("\"X\": {0},", (int)this.X);
                sb.AppendFormat("\"Y\": {0},", (int)this.Y);
                sb.AppendFormat("\"Z\": {0}", (int)this.Z);
                sb.Append(" }");
                return sb.ToString();
            }
        }

        public bool ShouldLoad {
            get {
                return _shouldLoad;
            }

            set {
                _shouldLoad = value;
            }
        }
        #endregion

        public TileBase(int x, int y, int z, TileTypes tileType = TileTypes.Air) {
            _x = x;
            _y = y;
            _z = z;
            _tileType = tileType;
            _shouldLoad = false;
        }

        public TileBase(TileTypes t) : this(0, 0, 0, TileTypes.Air) {
            
        }
    }
}

