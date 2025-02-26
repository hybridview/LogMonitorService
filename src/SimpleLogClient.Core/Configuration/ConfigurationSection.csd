<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="SimpleLogClient.Core.Configuration" xmlSchemaNamespace="urn:LoggingConfig" assemblyName="SimpleLogClient.Core" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="LoggerServiceSection" documentation="Note" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="loggerServiceSection">
      <elementProperties>
        <elementProperty name="Loggers" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="loggers" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LoggersCollection" />
          </type>
        </elementProperty>
        <elementProperty name="DefaultLogger" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultLogger" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DefaultLoggerElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="LoggerElement">
      <attributeProperties>
        <attributeProperty name="name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="description" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="description" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="tracelevel" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="tracelevel" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TraceLevelElement" />
          </type>
        </elementProperty>
        <elementProperty name="logfilenameprefix" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logfilenameprefix" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LogFileNamePrefixElement" />
          </type>
        </elementProperty>
        <elementProperty name="logfilelocation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="logfilelocation" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LogFileLocationElement" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="LoggersCollection" xmlItemName="logger" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LoggerElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="TraceLevelElement">
      <attributeProperties>
        <attributeProperty name="value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false" defaultValue="1">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="LogFileLocationElement">
      <attributeProperties>
        <attributeProperty name="value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="LogFileNamePrefixElement">
      <attributeProperties>
        <attributeProperty name="value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="DefaultLoggerElement">
      <baseClass>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LoggerElement" />
      </baseClass>
      <attributeProperties>
        <attributeProperty name="name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false" defaultValue="&quot;DEFAULT&quot;">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
  <comments>
    <configurationSectionModelHasComments Id="6b60c58e-d5e8-482b-ab1e-9619cb4b3e3f">
      <comment Id="c87c3b85-8c00-47f1-af0e-0104b119b7fd" text="These values are the defaults for all loggers.">
        <subjects>
          <commentsReferenceConfigurationItems Id="0956d5fb-4afd-451c-8bf0-a5d168b79f80">
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/DefaultLoggerElement" />
          </commentsReferenceConfigurationItems>
        </subjects>
      </comment>
    </configurationSectionModelHasComments>
    <configurationSectionModelHasComments Id="8f976cd2-9d1a-478f-afa9-fe2af3799344">
      <comment Id="647f329c-a595-4dd9-bc9b-58088e9b162f" text="Represents settings for a single logger.">
        <subjects>
          <commentsReferenceConfigurationItems Id="0358eae3-924e-4af1-8712-6ee5d471332b">
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/LoggerElement" />
          </commentsReferenceConfigurationItems>
        </subjects>
      </comment>
    </configurationSectionModelHasComments>
  </comments>
</configurationSectionModel>