using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace XafDemo.Module.BusinessObjects;

[DefaultClassOptions]
public class Direccion : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public Direccion(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    ApplicationUser usuarioOwner;
    string ciudad;
    string colonia;
    string calle;

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Calle
    {
        get => calle;
        set => SetPropertyValue(nameof(Calle), ref calle, value);
    }

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Colonia
    {
        get => colonia;
        set => SetPropertyValue(nameof(Colonia), ref colonia, value);
    }
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Ciudad
    {
        get => ciudad;
        set => SetPropertyValue(nameof(Ciudad), ref ciudad, value);
    }

    //xpo    
    public ApplicationUser UsuarioOwner
    {
        get => usuarioOwner;
        set => SetPropertyValue(nameof(UsuarioOwner), ref usuarioOwner, value);
    }

    protected override void OnSaved()
    {
        UsuarioOwner = Session.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
        base.OnSaving();
    }
}