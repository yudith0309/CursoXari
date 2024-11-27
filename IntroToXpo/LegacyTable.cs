using DevExpress.Xpo;

namespace IntroToXpo;

[Persistent("Tly")]
public class LegacyTable : XPObject
{
    public LegacyTable(Session session) : base(session)
    {
    }

    //xps Enteros
    string nombre;
    bool activo;
    int miLlavePrimaria;

    [Key(false)]
    public int MiLlavePrimaria
    {
        get => miLlavePrimaria;
        set => SetPropertyValue(nameof(MiLlavePrimaria), ref miLlavePrimaria, value);
    }

    public bool Activo
    {
        get => activo;
        set => SetPropertyValue(nameof(Activo), ref activo, value);
    }

    [Persistent("Nbre")]
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Nombre
    {
        get => nombre;
        set => SetPropertyValue(nameof(Nombre), ref nombre, value);
    }
}
