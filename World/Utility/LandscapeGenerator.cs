using World.Tile;
using LibNoise.Primitive;
using LibNoise.Filter;
using LibNoise.Combiner;
using LibNoise.Transformer;

namespace World.Utility {
    internal class LandscapeGenerator {

        private World _world;

        public LandscapeGenerator(World world) {
            _world = world;
        }

        public ITile[,,] GenerateTiles() {
            //reinitialize array
            ITile[,,] output = new ITile[_world.Width, _world.Height, _world.Depth];

            //generate a 2D plane representing the contours of the landscape
            double[,] landscapePlane = this.BuildHeightMap();

            for (int x = 0; x < _world.Width; x++) {
                for (int y = 0; y < _world.Height; y++) { 
                    for (int z = 0; z < _world.Depth; z++) {
                        double landscapeElevation = landscapePlane[x, y];
                        if (z > landscapeElevation) {

                            //if the current Z value falls above the surface of the landscape plane,
                            //  then consider it "sky" and create an air tile here.
                            if (z > _world.SeaLevel) {
                                output[x, y, z] = new AirTile(x, y, z);
                            } else {
                                output[x, y, z] = new WaterTile(x, y, z);
                            }
                        } else {

                            //otherwise, we are "in" the landscape, so set tiles to either sand
                            //  (if at or below shoreline), or grass (if above shoreline)
                            if (z <= _world.ShoreLine) {
                                output[x, y, z] = new SandTile(x, y, z);
                            } else {
                                output[x, y, z] = new GrassTile(x, y, z);
                            }
                        }
                    }
                }
            }
            return output;
        }

        private double[,] BuildHeightMap() {
            double halfDepth = (_world.Depth / 2);
            ImprovedPerlin perlin = new ImprovedPerlin(_world.Seed, LibNoise.NoiseQuality.Standard);
            MultiFractal mf = new MultiFractal();
            mf.Primitive2D = perlin;
            mf.Primitive3D = perlin;

            TranslatePoint tp = new TranslatePoint(mf, _world.OffsetX, _world.OffsetY, 0.0f);
            
            double[,] landscapePlane = new double[_world.Width, _world.Height];

            for (int x = 0; x < _world.Width; x++) {
                for (int y = 0; y < _world.Height; y++) {
                    landscapePlane[x, y] = tp.GetValue((x + _world.OffsetX) / _world.ScaleX, (y + _world.OffsetY) / _world.ScaleY, 0.1f) * halfDepth;
                }
            }

            return landscapePlane;
        }
    }
}
