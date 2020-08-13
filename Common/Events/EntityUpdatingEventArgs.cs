using Common.Interfaces;

namespace Common.Events {
    public class EntityUpdateEventArgs {
        public IEntity EntityObject { get; set; }
        public readonly IEntity NewEntityObject;

        public EntityUpdateEventArgs(IEntity entityObject, IEntity newEntityObject) {
            EntityObject = entityObject;
            NewEntityObject = newEntityObject;
        }
    }
}
