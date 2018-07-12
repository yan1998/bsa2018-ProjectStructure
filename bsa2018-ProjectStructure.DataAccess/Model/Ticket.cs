
namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Ticket:Entity
    {
        public float Cost { get; set; }

        public int IdFlight { get; set; }
        public Flight Flight { get; set; }
    }
}
