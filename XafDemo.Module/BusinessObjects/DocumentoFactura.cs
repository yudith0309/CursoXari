using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XafDemo.Module.Controllers;

namespace XafDemo.Module.BusinessObjects;

[DefaultClassOptions]
[RuleCriteria("Postear Documento Factura", "Postear", "Total>0")]
[Appearance("Docuemnto factura posteado", "Posteado = true", Enabled = false, TargetItems = "*")]
[Appearance("Docuemnto factura posteado Negativo", "Total <0 ", BackColor = "Red", TargetItems = "Total")]
[Appearance("Docuemnto factura posteado positivo", "Total >0 ", FontColor = "Green", TargetItems = "Total")]
[Appearance("DocumentoFactura Total Posteado no borrar", "Posteado = true", AppearanceItemType = "Action", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.ShowEmptySpace)]

public class DocumentoFactura : BaseObject, IPost
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public DocumentoFactura(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    DateTime fecha;
    string diceccion;
    string nombre;
    bool posteado;
    decimal total;

    public decimal Total
    {
        get => total;
        set => SetPropertyValue(nameof(Total), ref total, value);
    }

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Nombre
    {
        get => nombre;
        set => SetPropertyValue(nameof(Nombre), ref nombre, value);
    }

    [Size(SizeAttribute.Unlimited)]
    public string Diceccion
    {
        get => diceccion;
        set => SetPropertyValue(nameof(Diceccion), ref diceccion, value);
    }

    public DateTime Fecha
    {
        get => fecha;
        set => SetPropertyValue(nameof(Fecha), ref fecha, value);
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