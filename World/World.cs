using System;
using World.Tile;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace World {
    public class World {
        public string Name { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Depth { get; private set; }
        public int SeaLevel { get; private set; }
        public int ShoreLine { get; private set; }

        [JsonIgnore]
        public ITile[,,] Tiles { get; private set; }

        public ITile[] SerializedTileArray {
            get {
                List<ITile> tArr = new List<ITile>();
                for (int x = 0; x < this.Width; x++) {
                    for (int y = 0; y < this.Height; y++) {
                        for (int z = 0; z < this.Depth; z++) {
                            if (this.Tiles[x, y, z] != null) {
                                ITile t = this.Tiles[x, y, z];
                                tArr.Add(this.Tiles[x, y, z]);
                            }
                        }
                    }
                }
                return tArr.ToArray();
            }
            set {
                foreach (ITile t in value) {
                    this.SetTileAtLocation(t, t.X, t.Y, t.Z);
                }
                this.FillNullTilesWithAir();
            }
        }

        public World(int width, int height, int depth, int seaLevel, int shoreLine, string name = "World", bool generate = true) {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Name = name;
            this.SeaLevel = seaLevel;
            this.ShoreLine = shoreLine;
            this.Tiles = new ITile[this.Width, this.Height, this.Depth];
            if (generate) this.GenerateTiles();
        }

        /// <summary>
        /// Generates a world without generating tiles by default.  Don't use this, this is just for the JSON serializer.
        /// </summary>
        [JsonConstructor]
        public World(int width, int height, int depth, int seaLevel, int shoreLine, string name)
            : this(width, height, depth, seaLevel, shoreLine, name, false) {
        }

        public World(int width, int height, int depth, string name = "World", bool generate = true)
            : this(width, height, depth, depth / 2, (depth / 2) + (depth / 8), name, generate) {
        }

        public ITile GetTileForDynamicEntity(IDynamicEntity ent) {
            return this.Tiles[ent.X, ent.Y, ent.Z];
        }

        public void SetTileAtLocation(ITile t, int x, int y, int z) {
            this.Tiles[x, y, z] = t;
        }

        public void Save(string outputDirectory) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try {
                MapSerializer.SerializeWorldMap(this, outputDirectory);
            } catch (Exception ex) {
                Console.WriteLine($"Error while serializing map object: {ex.Message}; {ex.StackTrace}");
                throw;
            }

            sw.Stop();
            Console.WriteLine("Serialization time: {0} ticks, {1} ms.", sw.ElapsedTicks, sw.ElapsedMilliseconds);
        }

        public static World LoadFromFile(string filename) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            World loaded;

            try {
                loaded = MapSerializer.DeserializeWorldMap(filename);
            } catch (Exception ex) {
                Console.WriteLine($"Error while deserializing map object: {ex.Message}; {ex.StackTrace}");
                throw;
            }

            sw.Stop();
            Console.WriteLine("Deserialization time: {0} ticks, {1} ms.", sw.ElapsedTicks, sw.ElapsedMilliseconds);

            return loaded;
        }

        internal int FillNullTilesWithAir() {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int count = 0;
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    for (int z = 0; z < this.Depth; z++) {
                        if (this.Tiles[x, y, z] == null) {
                            count++;
                            ITile t = new AirTile(x, y, z);
                            this.SetTileAtLocation(t, t.X, t.Y, t.Z);
                        }
                    }
                }
            }
            Console.WriteLine($"{count} null tiles replaced with air.");

            sw.Stop();
            Console.WriteLine("Air-fill time: {0} ticks, {1} ms.", sw.ElapsedTicks, sw.ElapsedMilliseconds);

            return count;
        }

        private void GenerateTiles() {
            Stopwatch sw = new Stopwatch();
            sw.Start();

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

            sw.Stop();
            Console.WriteLine("Landscape generation time: {0} ticks, {1} ms.", sw.ElapsedTicks, sw.ElapsedMilliseconds);
        }

        private double[,] GenerateLandscapePlane() {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double[,] landscapePlane = new double[this.Width, this.Height];
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    landscapePlane[x, y] = ((Math.Sin(x * 0.05) * Math.Sin(y * 0.05)) * (this.Depth / 2)) + (this.Depth / 2);
                }
            }

            sw.Stop();
            Console.WriteLine("Plane calculation time: {0} ticks, {1} ms.", sw.ElapsedTicks, sw.ElapsedMilliseconds);

            return landscapePlane;
        }

        private static JsonSerializerSettings GetJSONSettings() {
            return new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.None,
            };
        }
    }
}

