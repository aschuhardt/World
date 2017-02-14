using SharpNoise.Modules;
using System.Threading.Tasks;
using World.Tile;

namespace World.Utility {
    internal class LandscapeGenerator {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public int SeaLevel { get; private set; }
        public int ShoreLine { get; private set; }
        public double ScaleX { get; private set; }
        public double ScaleY { get; private set; }
        public int Seed { get; private set; }

        public LandscapeGenerator(int width, int height, int depth, 
            int seaLevel, int shoreLine, double scaleX, double scaleY, int seed) {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.SeaLevel = seaLevel;
            this.ShoreLine = shoreLine;
            this.ScaleX = scaleX;
            this.ScaleY = scaleY;
            this.Seed = seed;
        }

        public ITile[,,] GenerateTiles() {
            //reinitialize array
            ITile[,,] output = new ITile[this.Width, this.Height, this.Depth];

            //generate a 2D plane representing the contours of the landscape
            double[,] landscapePlane = this.BuildHeightMap();

            for (int x = 0; x < this.Width; x++) {
                Parallel.For(0, this.Height, (y) => {
                    for (int z = 0; z < this.Depth; z++) {
                        double landscapeElevation = landscapePlane[x, y];
                        if (z > landscapeElevation) {

                            //if the current Z value falls above the surface of the landscape plane,
                            //  then consider it "sky" and create an air tile here.
                            if (z > this.SeaLevel) {
                                output[x, y, z] = new AirTile(x, y, z);
                            } else {
                                output[x, y, z] = new WaterTile(x, y, z);
                            }
                        } else {

                            //otherwise, we are "in" the landscape, so set tiles to either sand
                            //  (if at or below shoreline), or grass (if above shoreline)
                            if (z <= this.ShoreLine) {
                                output[x, y, z] = new SandTile(x, y, z);
                            } else {
                                output[x, y, z] = new GrassTile(x, y, z);
                            }
                        }
                    }
                });
            }
            return output;
        }

        private double[,] BuildHeightMap() {
            double halfDepth = (this.Depth / 2);
            var c = new Cache() {
                Source0 = new Blend() {
                    Source0 = new Perlin() {
                        Seed = this.Seed
                    },
                    Source1 = new Perlin() {
                        Seed = -this.Seed
                    },
                    Control = new RidgedMulti() {
                        Seed = this.Seed
                    }
                }
            };

            double[,] landscapePlane = new double[this.Width, this.Height];
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    landscapePlane[x, y] = (c.GetValue(x * this.ScaleX, y * this.ScaleY, 0.1) * halfDepth) + halfDepth;
                }
            }
            return landscapePlane;
        }
    }
}
