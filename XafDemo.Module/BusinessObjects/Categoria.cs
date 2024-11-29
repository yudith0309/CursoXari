using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace XafDemo.Module.BusinessObjects;

[DefaultClassOptions]

public class Categoria : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public Categoria(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    //xpcl

    [Association("Categoria-Productos")]
    public XPCollection<Producto> Productos
    {
        get
        {
            return GetCollection<Producto>(nameof(Productos));
        }
    }

    [Association("Categoria-ProductosEspecials")]
    public XPCollection<ProductosEspecial> ProductosEspecials
    {
        get
        {
            return GetCollection<ProductosEspecial>(nameof(ProductosEspecials));
        }
    }
}