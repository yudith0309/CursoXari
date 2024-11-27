using DevExpress.Xpo;

namespace IntroToXpo;

//xc Clase persistente
public class Factura : XPObject
{
    public Factura(Session session) : base(session)
    { }

    //Inicialización personalizada: Permite realizar configuraciones o ajustes adicionales que no se puedan hacer en el constructor.
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        this.fecha = DateTime.Now;
    }

    string cliente;
    DateTime fecha;

    public DateTime Fecha
    {
        get => fecha;
        set => SetPropertyValue(nameof(Fecha), ref fecha, value);
    }


    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Cliente
    {
        get => cliente;
        set => SetPropertyValue(nameof(Cliente), ref cliente, value);
    }

    //xpcl Relacion de Factura con Factura Detalles 

    [Association("Factura-Detalles"), DevExpress.Xpo.Aggregated()] //Los registros hijos no existen sin los registros padres
    public XPCollection<FacturaDetalle> Detalles
    {
        get
        {
            return GetCollection<FacturaDetalle>(nameof(Detalles));
        }
    }
}

public class FacturaDetalle : XPObject
{
    public FacturaDetalle(Session session) : base(session)
    { }


    //xpa Relacion a Factura
    string productName;
    Factura factura;

    [Association("Factura-Detalles")]
    public Factura Factura
    {
        get => factura;
        set => SetPropertyValue(nameof(Factura), ref factura, value);
    }

    
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string ProductName
    {
        get => productName;
        set => SetPropertyValue(nameof(ProductName), ref productName, value);
    }
}
