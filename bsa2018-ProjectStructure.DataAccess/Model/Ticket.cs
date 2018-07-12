
namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public float Cost { get; set; }

        public int FlightNumber { get; set; }
        public Flight Flight { get; set; }
    }
}
