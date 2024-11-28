using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace XafDemo.Module.BusinessObjects
{
    [DefaultClassOptions]

    [RuleCombinationOfPropertiesIsUnique("Nombre Apellidos unicos", DefaultContexts.Save, "Nombre, Apellidos", CustomMessageTemplate = "El nombre y los apellidos deben ser unicos")]
    public class Cliente : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Cliente(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        int edad;
        string apellidos;
        string nombre;
        bool activo;
        Direccion propertyName;

        [ExpandObjectMembers(ExpandObjectMembers.Always)]
        [DevExpress.Xpo.Aggregated()]
        [Persistent("DireccionObjeto")]
        public Direccion PropertyName
        {
            get => propertyName;
            set => SetPropertyValue(nameof(PropertyName), ref propertyName, value);
        }

        [RuleRequiredField("Rule.Requared.Field1", "Procesar", "El campo 'Nombre' es obligatorio.")]
        [RuleRequiredField("Rule.Requuared.Field2", DefaultContexts.Save, "El campo 'Nombre' es obligatorio.")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Apellidos
        {
            get => apellidos;
            set => SetPropertyValue(nameof(Apellidos), ref apellidos, value);
        }
        public bool Activo
        {
            get => activo;
            set => SetPropertyValue(nameof(Activo), ref activo, value);
        }

        [RuleRange("LastSevenDays_RuleRange", DefaultContexts.Save, 0, 115, CustomMessageTemplate = "La edad debe estar en el rango de 0 a 115")]
        public int Edad
        {
            get => edad;
            set => SetPropertyValue(nameof(Edad), ref edad, value);
        }
    }
}