using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XafDemo.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class FacturaDetalle : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public FacturaDetalle(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //xpa
        decimal total;
        decimal precioUnitario;
        int cantidad;
        Producto producto;
        Factura factura;

        [Association("Factura-FacturaDetalles")]
        public Factura Factura
        {
            get => factura;
            set => SetPropertyValue(nameof(Factura), ref factura, value);
        }

        //xpo      
        public Producto Producto
        {
            get => producto;
            set => SetPropertyValue(nameof(Producto), ref producto, value);
        }
        //xpi        
        public int Cantidad
        {
            get => cantidad;
            set => SetPropertyValue(nameof(Cantidad), ref cantidad, value);
        }

        //xpde         
        public decimal PrecioUnitario
        {
            get => precioUnitario;
            set => SetPropertyValue(nameof(PrecioUnitario), ref precioUnitario, value);
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (propertyName == nameof(Factura))
            {
                if(this.producto == null)
                {
                    this.precioUnitario = 0;
                }
                else
                {
                    this.precioUnitario = Producto.PrecioUnitario;
                }               
            }
            if (propertyName == nameof(Cantidad) || propertyName == nameof(PrecioUnitario))
            {
                this.Total = Cantidad * PrecioUnitario;
            }
            base.OnChanged(propertyName, oldValue, newValue);
        }
        public decimal Total
        {
            get => total;
            set => SetPropertyValue(nameof(Total), ref total, value);
        }
    }
}