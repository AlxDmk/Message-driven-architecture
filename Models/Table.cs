namespace Restaurant.Booking.Models
{
    public class Table
    {
        public State State { get; private set; }
        public int SeatCount { get; }
        public int Id { get; }

        public Table(int id)
        {
            Id = id;
            State = State.Free;
            SeatCount = new Random().Next(2, 5);
        }

        public bool SetState(State state)
        {
            if (state == State)
                return false;
            State = state;
            return true;
        }
    }
}
