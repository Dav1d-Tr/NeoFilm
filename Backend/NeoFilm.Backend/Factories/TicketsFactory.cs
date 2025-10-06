using NeoFilm.Shared.Entities;
using NeoFilm.Shared.interfaces;

public class TicketsFactory : ProductFactory
{
    private readonly int _Bill;
    private readonly int _Function;
    private readonly int _Seat;
    private readonly decimal _Price;
    private readonly string _description;

    public TicketsFactory(int Bill, int Function, int Seat, decimal Price, string Description )
    {
        _Bill = Bill;
        _Function = Function;
        _Seat = Seat;
        _Price = Price;
        _description = Description;
    }

    public override IProducto CrearProducto()
    {
        return new Ticket
        {
            BillId = _Bill,
            FunctionId = _Function,
            SeatId = _Seat,
            Price = _Price,
            Description= _description

        };
        

        
    }
}