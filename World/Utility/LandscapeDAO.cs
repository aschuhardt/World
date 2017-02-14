using System.IO;

namespace World.Utility {
    internal class LandscapeDAO {
        
        public World Load(string path) {
            World output;
            using (Stream stream = File.Open(path, FileMode.Open)) {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                output = (World)binaryFormatter.Deserialize(stream);
            }
            return output;
        }

        public void Save(World w, string path) {
            w.ClearTiles();
            string filename = Path.Combine(path, w.Name);
            using (Stream stream = File.Create(filename)) {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, w);
                stream.Close();
            }
        }

    }
}
