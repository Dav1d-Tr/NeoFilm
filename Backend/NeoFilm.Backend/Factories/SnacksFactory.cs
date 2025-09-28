using NeoFilm.Shared.Entities;
using NeoFilm.Shared.interfaces;

public class SnackFactory : ProductFactory
{
    private readonly string _name;
    private readonly decimal _UnitValue;
    private readonly string _Description;
    private readonly bool _state;
    private readonly string _imageUrl;

    public SnackFactory(string name, decimal UnitValue, String Description, bool state, string imageUrl)
    {
        _name= name;
        _UnitValue= UnitValue;  
        _Description= Description;  
        _state= state;
        _imageUrl= imageUrl;
    }

    public override IProducto CrearProducto()
    {
        return new Snacks { Name=_name, UnitValue=_UnitValue, Description=_Description, State=_state, imageUrl=_imageUrl };
    }
}