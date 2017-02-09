using System;

namespace World {
    public enum DynamicEntityTypes {
        Human,
        Dwarf,
        Elf,
        Kobold,
        Goblin,
        Cow
    }

    public interface IDynamicEntity {
        DynamicEntityTypes EntityType { get; }

        int X { get; }

        int Y { get; }

        int Z { get; }
    }
}

