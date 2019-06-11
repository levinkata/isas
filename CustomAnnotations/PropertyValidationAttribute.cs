using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Isas.CustomAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class PropertyValidationAttribute : ValidationAttribute
    {
        #region Fields
        private readonly string propertyName;
        private object value;
        #endregion

        #region Ctor

        protected PropertyValidationAttribute(string propertyName) : base()
        {
            if (String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException("propertyName");
            this.propertyName = propertyName;
        }

        #endregion

        #region Properties

        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        protected string PropertyName
        {
            get { return this.propertyName; }
        }

        #endregion

        #region Methods

        protected object GetValue(ValidationContext validationContext)
        {
            Type type = validationContext.ObjectType;
            PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

            if (property == null)
                throw new InvalidOperationException(String.Format("Type {0} does not contain public instance property {1}.", type.FullName, PropertyName));

            if (IsIndexerProperty(property))
                throw new NotSupportedException("Property with indexer parameters is not supported.");

            value = property.GetValue(validationContext.ObjectInstance);

            return value;
        }

        private bool IsIndexerProperty(PropertyInfo property)
        {
            var parameters = property.GetIndexParameters();

            return (parameters != null && parameters.Length > 0);
        }

        #endregion
    }
}
