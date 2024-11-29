using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace XafDemo.Module.BusinessObjects;

[DefaultClassOptions]

[RuleCombinationOfPropertiesIsUnique("Nombre Apellidos", DefaultContexts.Save, "Nombre, Apellidos", CustomMessageTemplate = "El nombre y los apellidos deben ser unicos")]

public class Cliente_Especial : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public Cliente_Especial(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    string telefono;
    string email;
    string apellidos;
    string nombre;

    [RuleRequiredField("NombreRequired", DefaultContexts.Save, CustomMessageTemplate = "El nombre es obligatorio.")]
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Nombre
    {
        get => nombre;
        set => SetPropertyValue(nameof(Nombre), ref nombre, value);
    }

    [RuleRequiredField("ApellidoRequired", DefaultContexts.Save, CustomMessageTemplate = "El apellido es obligatorio.")]
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Apellidos
    {
        get => apellidos;
        set => SetPropertyValue(nameof(Apellidos), ref apellidos, value);
    }

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Email
    {
        get => email;
        set => SetPropertyValue(nameof(Email), ref email, value);
    }
    
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    [RuleRange("TelefonoLongitud", DefaultContexts.Save, 10, 15, CustomMessageTemplate = "El teléfono debe tener entre 10 y 15 caracteres.")]
    public string Telefono
    {
        get => telefono;
        set => SetPropertyValue(nameof(Telefono), ref telefono, value);
    }
}