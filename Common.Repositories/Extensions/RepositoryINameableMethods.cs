using Common.Interfaces;
using Common.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Common.UoW.Extensions
{
    public static class RepositoryINameableMethods
    {
        public static IEnumerable<string> GetNames<T>(this IRepository<T> repository)
            where T : IEntity, INameable
        {
            return repository.GetAll().Select(e => e.Name);
        }

        public static T GetByName<T>(this IRepository<T> repository, string name)
            where T : IEntity, INameable
        {
            return repository.GetAll().FirstOrDefault(e => e.Name == name);
        }
    }
}
