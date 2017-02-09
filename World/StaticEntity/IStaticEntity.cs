using System;

namespace World.StaticEntity {
    /// <summary>
    /// Static entity types.
    /// TODO: Consider making this configurable at runtime so this enum doesn't get enormous.
    /// </summary>
    public enum StaticEntityTypes {
        Crate,
        Branch,
        Pebble
    }

    public interface IStaticEntity {
        StaticEntityTypes EntityType { get; }

        int X { get; }

        int Y { get; }

        int Z { get; }
    }
}

