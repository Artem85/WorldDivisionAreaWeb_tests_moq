using Common.Interfaces;
using Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Events;

namespace Common.Repositories {
    public class Repository<T> : IRepository<T> where T : class, IEntity {

        private readonly IList<T> _collection;

        public event EventHandler<EntityUpdateEventArgs> ItemUpdate;

        protected void OnItemUpdating(EntityUpdateEventArgs args) {
            if(ItemUpdate != null) {
                ItemUpdate(this, args);
            }
        }

        public Repository(IList<T> collection) {
            if (collection == null) {
                throw new ArgumentNullException(
                    string.Format(
                    "Repository<{0}>: collection == null",
                    typeof(T).Name));
            }
            this._collection = collection;
        }

        //public IEnumerable<T> GetAll() {
        public virtual IEnumerable<T> GetAll() {
            return _collection;
        }

        public T GetById(int id) {
            return _collection.First(e => e.Id == id);
        }

        public virtual void Add(T item) {
            if (item == null || _collection.Contains(item))
                return;
            if (_collection.Any(e => e.Id == item.Id)) {
                throw new InvalidOperationException(
                    "Спроба повторно додати у сховище об'єкт "
                    + "сутності з ідентифікатором " + item.Id);
            }
            _collection.Add(item);
        }

        public virtual void Update(T item) {
            //throw new NotImplementedException();
            T obj = GetById(item.Id);
            OnItemUpdating(new EntityUpdateEventArgs(obj, item));
            //int index = _collection.IndexOf(obj);
            //_collection[index] = item;
        }

        public virtual void Delete(T item) {
            if (item != null && _collection.Contains(item))
                _collection.Remove(item);
        }

        public void Save() {
            //throw new NotImplementedException();
            if (DataSave != null)
                DataSave(this, new EventArgs());
        }

        public void Load() {
            //throw new NotImplementedException();
            if (DataLoad != null)
                DataLoad(this, new EventArgs());
        }

        public event EventHandler<EventArgs> DataSave;
        public event EventHandler<EventArgs> DataLoad;
    }
}
