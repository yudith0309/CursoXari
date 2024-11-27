using DevExpress.Xpo;

namespace IntroToXpo;

public class Cliente : XPObject
{
    public Cliente(Session session) : base(session)
    {
    }

    decimal credito;
    decimal creditoMaximo;
    string direccion;
    string nombre;
    DateTime fecha;
    object activo;

    //Xpd 
    public object Activo
    {
        get => activo;
        set => SetPropertyValue(nameof(Activo), ref activo, value);
    }

    //Xpd8 fecha

    public DateTime Fecha
    {
        get => Fecha;
        set => SetPropertyValue(nameof(Fecha), ref fecha, value);
    }

    //xps string 

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Nombre
    {
        get => Nombre;
        set => SetPropertyValue(nameof(Nombre), ref nombre, value);
    }

    [Size(SizeAttribute.Unlimited)] //String Limitado
    public string Direccion
    {
        get => Direccion;
        set => SetPropertyValue(nameof(Direccion), ref direccion, value);
    }

    //xpd Decimales 

    public decimal CreditoMaximo
    {
        get => CreditoMaximo;
        set => SetPropertyValue(nameof(CreditoMaximo), ref creditoMaximo, value);
    }

    public decimal Credito
    {
        get => Credito;
        set => SetPropertyValue(nameof(Credito), ref credito, value);
    }
}


