using Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Common.Repositories {
    public class CountingRepository<T> 
        : Repository<T> where T : class, IEntity {

        private static int counter = 0;

        public CountingRepository(IList<T> collection)
            : base(collection) {
                CheckAndSetIds(collection);
        }

        private void CheckAndSetIds(IList<T> collection) {
            if (!collection.Any()) return;
            counter = collection.Select(e => e.Id).Max();
            for (int i = 0; i < collection.Count; i++) {
                if (collection[i].Id == 0) {
                    collection[i].Id = ++counter;
                }
            }
        }

        public override void Add(T item) {
            base.Add(item);
            counter++;
            if (item.Id == 0)
                item.Id = counter;
            else if (item.Id > counter)
                counter = item.Id;
        }
    }
}
