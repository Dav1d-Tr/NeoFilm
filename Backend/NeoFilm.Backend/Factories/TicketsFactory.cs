using NeoFilm.Shared.Entities;
using NeoFilm.Shared.interfaces;

public class TicketsFactory : ProductFactory
{
 
    private readonly int _Function;
    private readonly int _Seat;
    private readonly decimal _Price;
    private readonly string _description;
    private readonly int _car;

    public TicketsFactory(int Function, int Seat, decimal Price, string Description )
    {
  
        _Function = Function;
        _Seat = Seat;
        _Price = Price;
        _description = Description;
        
    }

    public override IProducto CrearProducto()
    {
        return new Ticket
        {
         
            FunctionId = _Function,
            SeatId = _Seat,
            Price = _Price,
            Description= _description,
           

        };
        

        
    }
}