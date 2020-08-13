
namespace Common.Interfaces {
    public interface IDataIOController<D> where D : class, IEntitiesDataSet {
        string FileExtension { get; }
        string FileTypeCaption { get; }

        D Load(string fileName);
        void Save(D dataSet, string fileName);
    }
}
