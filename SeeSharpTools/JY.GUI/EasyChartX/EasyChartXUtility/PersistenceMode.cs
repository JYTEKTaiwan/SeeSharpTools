using System;

namespace SeeSharpTools.JY.GUI
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class PersistenceModeAttribute : Attribute
    {
        //
        // Summary:
        //     Specifies that the property or event persists in the opening tag of the server
        //     control as an attribute. This field is read-only.
        public static readonly PersistenceModeAttribute Attribute = new PersistenceModeAttribute(PersistenceMode.Attribute);

        //
        // Summary:
        //     Specifies that the property persists as a nested tag within the opening and closing
        //     tags of the server control. This field is read-only.
        public static readonly PersistenceModeAttribute InnerProperty = new PersistenceModeAttribute(PersistenceMode.InnerProperty);

        //
        // Summary:
        //     Specifies that a property persists as the only inner content of the ASP.NET server
        //     control. This field is read-only.
        public static readonly PersistenceModeAttribute InnerDefaultProperty = new PersistenceModeAttribute(PersistenceMode.InnerDefaultProperty);

        //
        // Summary:
        //     Specifies that a property is HTML-encoded and persists as the only inner content
        //     of the ASP.NET server control. This field is read-only.
        public static readonly PersistenceModeAttribute EncodedInnerDefaultProperty = new PersistenceModeAttribute(PersistenceMode.EncodedInnerDefaultProperty);

        //
        // Summary:
        //     Specifies the default type for the System.Web.UI.PersistenceModeAttribute class.
        //     The default is PersistenceMode.Attribute. This field is read-only.
        public static readonly PersistenceModeAttribute Default = Attribute;

        private PersistenceMode mode;

        //
        // Summary:
        //     Gets the current value of the System.Web.UI.PersistenceMode enumeration.
        //
        // Returns:
        //     A System.Web.UI.PersistenceMode that represents the current value of the enumeration.
        //     This value can be Attribute, InnerProperty, InnerDefaultProperty, or EncodedInnerDefaultProperty.
        //     The default is Attribute.
        public PersistenceMode Mode => mode;

        //
        // Summary:
        //     Initializes a new instance of the System.Web.UI.PersistenceModeAttribute class.
        //
        // Parameters:
        //   mode:
        //     The System.Web.UI.PersistenceMode value to assign to System.Web.UI.PersistenceModeAttribute.Mode.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     mode is not one of the System.Web.UI.PersistenceMode values.
        public PersistenceModeAttribute(PersistenceMode mode)
        {
            if (mode < PersistenceMode.Attribute || mode > PersistenceMode.EncodedInnerDefaultProperty)
            {
                throw new ArgumentOutOfRangeException("mode");
            }

            this.mode = mode;
        }

        //
        // Summary:
        //     Provides a hash value for a System.Web.UI.PersistenceModeAttribute attribute.
        //
        // Returns:
        //     The hash value to be assigned to the System.Web.UI.PersistenceModeAttribute.
        public override int GetHashCode()
        {
            return Mode.GetHashCode();
        }

        //
        // Summary:
        //     Compares the System.Web.UI.PersistenceModeAttribute object against another object.
        //
        // Parameters:
        //   obj:
        //     The object to compare to.
        //
        // Returns:
        //     true if the objects are considered equal; otherwise, false.
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj != null && obj is PersistenceModeAttribute)
            {
                return ((PersistenceModeAttribute)obj).Mode == mode;
            }

            return false;
        }

        //
        // Summary:
        //     Indicates whether the System.Web.UI.PersistenceModeAttribute object is of the
        //     default type.
        //
        // Returns:
        //     true if the System.Web.UI.PersistenceModeAttribute is of the default type; otherwise,
        //     false.
        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
    //
    // Summary:
    //     Specifies how an ASP.NET server control property or event is persisted declaratively
    //     in an .aspx or .ascx file.
    public enum PersistenceMode
    {
        //
        // Summary:
        //     Specifies that the property or event persists as an attribute.
        Attribute,
        //
        // Summary:
        //     Specifies that the property persists in the ASP.NET server control as a nested
        //     tag. This is commonly used for complex objects, those that have persistable properties
        //     of their own.
        InnerProperty,
        //
        // Summary:
        //     Specifies that the property persists in the ASP.NET server control as inner text.
        //     Also indicates that this property is defined as the element's default property.
        //     Only one property can be designated the default property.
        InnerDefaultProperty,
        //
        // Summary:
        //     Specifies that the property persists as the only inner text of the ASP.NET server
        //     control. The property value is HTML encoded. Only a string can be given this
        //     designation.
        EncodedInnerDefaultProperty
    }

}
