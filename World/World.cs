using System;
using World.Tile;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace World {
    public class World {
        public string Name { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public int SeaLevel { get; private set; }
        public int ShoreLine { get; private set; }
        public ITile[,,] Tiles { get; private set; }

        [JsonConstructor]
        public World(int width, int height, int depth, int seaLevel, int shoreLine, string name = "World") {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Name = name;
            this.SeaLevel = seaLevel;
            this.ShoreLine = shoreLine;
            this.GenerateTiles();
        }

        public World(int width, int height, int depth, string name = "World")
            : this(width, height, depth, depth / 2, (depth / 2) + (depth / 8), name) {
        }

        public ITile GetTileForDynamicEntity(IDynamicEntity ent) {
            return this.Tiles[ent.X, ent.Y, ent.Z];
        }

        public void Save(string outputDirectory) {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string filename = string.Format("{0}.json", this.Name);
            string path = Path.Combine(outputDirectory, filename);
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
            try {
                sw.Write(json);
            } catch (Exception ex) {
                throw ex;
            } finally {
                sw.Close();
            }
        }

        public static World LoadFromFile(string filePath) {
            StreamReader sr = new StreamReader(filePath, Encoding.UTF8);
            string json = "";
            try {
                json = sr.ReadToEnd();
            } catch (Exception ex) {
                throw ex;
            } finally {
                sr.Close();
            }
            return (World)JsonConvert.DeserializeObject(json, typeof(World));
        }

        private void GenerateTiles() {
            this.Tiles = new ITile[this.Width, this.Height, this.Depth];

            //generate a 2D plane representing the contours of the landscape
            double[,] landscapePlane = this.GenerateLandscapePlane();

            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    for (int z = 0; z < this.Depth; z++) {
                        double landscapeElevation = landscapePlane[x, y];
                        if (z > landscapeElevation) {

                            //if the current Z value falls above the surface of the landscape plane,
                            //  then consider it "sky" and create an air tile here.
                            if (z > this.SeaLevel) {
                                this.Tiles[x, y, z] = new AirTile(x, y, z);
                            } else {
                                this.Tiles[x, y, z] = new WaterTile(x, y, z);
                            }
                        } else {

                            //otherwise, we are "in" the landscape, so set tiles to either sand
                            //  (if at or below shoreline), or grass (if above shoreline)
                            if (z <= this.ShoreLine) {
                                this.Tiles[x, y, z] = new SandTile(x, y, z);
                            } else {
                                this.Tiles[x, y, z] = new GrassTile(x, y, z);
                            }
                        }
                    }
                }
            }
        }

        private double[,] GenerateLandscapePlane() {
            double[,] landscapePlane = new double[this.Width, this.Height];
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    landscapePlane[x, y] = (Math.Sin(x * 0.06) * Math.Sin(y * 0.06)) * this.Depth;
                }
            }
            return landscapePlane;
        }
    }
}

