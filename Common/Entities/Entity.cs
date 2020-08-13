using Common.Interfaces;
using System;

namespace Common.Entities {

    [Serializable]
    public abstract class Entity : IEntity {
        public int Id { get; set; }
    }
}
