using DevExpress.Xpo;

namespace IntroToXpo;

public class ClienteLocal : Cliente
{
    public ClienteLocal(Session session) : base(session)
    {
    }


    string noIdentificacionFiscal;

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string NoIdentificacionFiscal
    {
        get => NoIdentificacionFiscal;
        set => SetPropertyValue(nameof(NoIdentificacionFiscal), ref noIdentificacionFiscal, value);
    }
}

public class ClienteExtranjero : Cliente
{
    public ClienteExtranjero(Session session) : base(session)
    {
    }

    string pasaporte;

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Pasaporte
    {
        get => Pasaporte;
        set => SetPropertyValue(nameof(Pasaporte), ref pasaporte, value);
    }
}
