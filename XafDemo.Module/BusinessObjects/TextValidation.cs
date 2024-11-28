using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.ComponentModel;

namespace XafDemo.Module.BusinessObjects
{
    [DefaultClassOptions]
    [RuleCriteria("Validar Text Object", DefaultContexts.Save, "Edad > 0 AND Activo = true","La regla validar objeto no se cumple", SkipNullOrEmptyValues = false)]
    public class TextValidation : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public TextValidation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        bool activo;
        bool estavalido;
        int edad;

        [RuleValueComparison("EdadMayorQueCero", DefaultContexts.Delete, ValueComparisonType.GreaterThan, 0,
                CustomMessageTemplate = "La edad debe ser mayor que 0.")]
        public int Edad
        {
            get => edad;
            set => SetPropertyValue(nameof(Edad), ref edad, value);
        }
        [RuleFromBoolProperty("Esta propiedad debe ser valida", DefaultContexts.Save, CustomMessageTemplate = "Contact with this Email already exists", InvertResult = true)]
        [Browsable(false)]
        public bool Estavalido
        {
            get
            {
                return true;
            }
        }        
        public bool Activo
        {
            get => activo;
            set => SetPropertyValue(nameof(Activo), ref activo, value);
        }
    }
}