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
    }
}