using Common.Interfaces;

namespace WorldDivisionAreaWeb.Models {
    public class Macroregion : IEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Numeric { get; set; }
        public double? Area { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public Macroregion() {
            ParentName = "";
        }
    }
}