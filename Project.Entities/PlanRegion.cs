namespace Project.Entities
{
    public class PlanRegion
    {
        public int Id { get; set; }
        public Plan Plan { get; set; }
        public Region Region { get; set; }
    }
}