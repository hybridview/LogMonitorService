//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// Note
    /// </summary>
    public partial class LoggerServiceSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the LoggerServiceSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string LoggerServiceSectionSectionName = "loggerServiceSection";
        
        /// <summary>
        /// Gets the LoggerServiceSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public static global::SimpleLogClient.Core.Configuration.LoggerServiceSection Instance
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LoggerServiceSection)(global::System.Configuration.ConfigurationManager.GetSection(global::SimpleLogClient.Core.Configuration.LoggerServiceSection.LoggerServiceSectionSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerServiceSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.LoggerServiceSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Loggers Property
        /// <summary>
        /// The XML name of the <see cref="Loggers"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string LoggersPropertyName = "loggers";
        
        /// <summary>
        /// Gets or sets the Loggers.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Loggers.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerServiceSection.LoggersPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::SimpleLogClient.Core.Configuration.LoggersCollection Loggers
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LoggersCollection)(base[global::SimpleLogClient.Core.Configuration.LoggerServiceSection.LoggersPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerServiceSection.LoggersPropertyName] = value;
            }
        }
        #endregion
        
        #region DefaultLogger Property
        /// <summary>
        /// The XML name of the <see cref="DefaultLogger"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string DefaultLoggerPropertyName = "defaultLogger";
        
        /// <summary>
        /// Gets or sets the DefaultLogger.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The DefaultLogger.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerServiceSection.DefaultLoggerPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::SimpleLogClient.Core.Configuration.DefaultLoggerElement DefaultLogger
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.DefaultLoggerElement)(base[global::SimpleLogClient.Core.Configuration.LoggerServiceSection.DefaultLoggerPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerServiceSection.DefaultLoggerPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// The LoggerElement Configuration Element.
    /// </summary>
    public partial class LoggerElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region name Property
        /// <summary>
        /// The XML name of the <see cref="name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string namePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerElement.namePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public string name
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.LoggerElement.namePropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerElement.namePropertyName] = value;
            }
        }
        #endregion
        
        #region description Property
        /// <summary>
        /// The XML name of the <see cref="description"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string descriptionPropertyName = "description";
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The description.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerElement.descriptionPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string description
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.LoggerElement.descriptionPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerElement.descriptionPropertyName] = value;
            }
        }
        #endregion
        
        #region tracelevel Property
        /// <summary>
        /// The XML name of the <see cref="tracelevel"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string tracelevelPropertyName = "tracelevel";
        
        /// <summary>
        /// Gets or sets the tracelevel.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The tracelevel.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerElement.tracelevelPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::SimpleLogClient.Core.Configuration.TraceLevelElement tracelevel
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.TraceLevelElement)(base[global::SimpleLogClient.Core.Configuration.LoggerElement.tracelevelPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerElement.tracelevelPropertyName] = value;
            }
        }
        #endregion
        
        #region logfilenameprefix Property
        /// <summary>
        /// The XML name of the <see cref="logfilenameprefix"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string logfilenameprefixPropertyName = "logfilenameprefix";
        
        /// <summary>
        /// Gets or sets the logfilenameprefix.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The logfilenameprefix.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerElement.logfilenameprefixPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::SimpleLogClient.Core.Configuration.LogFileNamePrefixElement logfilenameprefix
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LogFileNamePrefixElement)(base[global::SimpleLogClient.Core.Configuration.LoggerElement.logfilenameprefixPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerElement.logfilenameprefixPropertyName] = value;
            }
        }
        #endregion
        
        #region logfilelocation Property
        /// <summary>
        /// The XML name of the <see cref="logfilelocation"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string logfilelocationPropertyName = "logfilelocation";
        
        /// <summary>
        /// Gets or sets the logfilelocation.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The logfilelocation.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LoggerElement.logfilelocationPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public global::SimpleLogClient.Core.Configuration.LogFileLocationElement logfilelocation
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LogFileLocationElement)(base[global::SimpleLogClient.Core.Configuration.LoggerElement.logfilelocationPropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LoggerElement.logfilelocationPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// A collection of LoggerElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::SimpleLogClient.Core.Configuration.LoggerElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::SimpleLogClient.Core.Configuration.LoggersCollection.LoggerElementPropertyName)]
    public partial class LoggersCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string LoggerElementPropertyName = "logger";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override string ElementName
        {
            get
            {
                return global::SimpleLogClient.Core.Configuration.LoggersCollection.LoggerElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::SimpleLogClient.Core.Configuration.LoggersCollection.LoggerElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::SimpleLogClient.Core.Configuration.LoggerElement)(element)).name;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::SimpleLogClient.Core.Configuration.LoggerElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::SimpleLogClient.Core.Configuration.LoggerElement this[int index]
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LoggerElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::SimpleLogClient.Core.Configuration.LoggerElement this[object name]
        {
            get
            {
                return ((global::SimpleLogClient.Core.Configuration.LoggerElement)(base.BaseGet(name)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="logger">The <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Add(global::SimpleLogClient.Core.Configuration.LoggerElement logger)
        {
            base.BaseAdd(logger);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="logger">The <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public void Remove(global::SimpleLogClient.Core.Configuration.LoggerElement logger)
        {
            base.BaseRemove(this.GetElementKey(logger));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::SimpleLogClient.Core.Configuration.LoggerElement GetItemAt(int index)
        {
            return ((global::SimpleLogClient.Core.Configuration.LoggerElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> with the specified key.
        /// </summary>
        /// <param name="name">The key of the <see cref="global::SimpleLogClient.Core.Configuration.LoggerElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public global::SimpleLogClient.Core.Configuration.LoggerElement GetItemByKey(string name)
        {
            return ((global::SimpleLogClient.Core.Configuration.LoggerElement)(base.BaseGet(((object)(name)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// The TraceLevelElement Configuration Element.
    /// </summary>
    public partial class TraceLevelElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region value Property
        /// <summary>
        /// The XML name of the <see cref="value"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string valuePropertyName = "value";
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The value.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.TraceLevelElement.valuePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue=1)]
        public int value
        {
            get
            {
                return ((int)(base[global::SimpleLogClient.Core.Configuration.TraceLevelElement.valuePropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.TraceLevelElement.valuePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// The LogFileLocationElement Configuration Element.
    /// </summary>
    public partial class LogFileLocationElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region value Property
        /// <summary>
        /// The XML name of the <see cref="value"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string valuePropertyName = "value";
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The value.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LogFileLocationElement.valuePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string value
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.LogFileLocationElement.valuePropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LogFileLocationElement.valuePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// The LogFileNamePrefixElement Configuration Element.
    /// </summary>
    public partial class LogFileNamePrefixElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region value Property
        /// <summary>
        /// The XML name of the <see cref="value"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string valuePropertyName = "value";
        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The value.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.LogFileNamePrefixElement.valuePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string value
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.LogFileNamePrefixElement.valuePropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.LogFileNamePrefixElement.valuePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace SimpleLogClient.Core.Configuration
{
    
    
    /// <summary>
    /// The DefaultLoggerElement Configuration Element.
    /// </summary>
    public partial class DefaultLoggerElement : global::SimpleLogClient.Core.Configuration.LoggerElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region name Property
        /// <summary>
        /// The XML name of the <see cref="name"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        internal const string namePropertyName = "name";
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.0.0")]
        [global::System.ComponentModel.DescriptionAttribute("The name.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::SimpleLogClient.Core.Configuration.DefaultLoggerElement.namePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false, DefaultValue="DEFAULT")]
        public string name
        {
            get
            {
                return ((string)(base[global::SimpleLogClient.Core.Configuration.DefaultLoggerElement.namePropertyName]));
            }
            set
            {
                base[global::SimpleLogClient.Core.Configuration.DefaultLoggerElement.namePropertyName] = value;
            }
        }
        #endregion
    }
}
