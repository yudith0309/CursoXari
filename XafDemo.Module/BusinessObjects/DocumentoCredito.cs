using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XafDemo.Module.Controllers;

namespace XafDemo.Module.BusinessObjects;

[DefaultClassOptions]
[RuleCriteria("Postear Documento credito","Postear","Total>0")]
public class DocumentoCredito : BaseObject, IPost

{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public DocumentoCredito(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    bool posteado;
    decimal total;

    public decimal Total
    {
        get => total;
        set => SetPropertyValue(nameof(Total), ref total, value);
    }
    [ModelDefault("AlowEdit", "False")]
    public bool Posteado
    {
        get => posteado;
        set => SetPropertyValue(nameof(Posteado), ref posteado, value);
    }

    public void Postear()
    {
        this.posteado = true;
    }
}