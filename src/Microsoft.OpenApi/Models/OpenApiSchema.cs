﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Helpers;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models.Interfaces;
using Microsoft.OpenApi.Writers;

namespace Microsoft.OpenApi.Models
{
    /// <summary>
    /// The Schema Object allows the definition of input and output data types.
    /// </summary>
    public class OpenApiSchema : IOpenApiReferenceable, IOpenApiExtensible, IOpenApiSchema
    {
        /// <inheritdoc />
        public string Title { get; set; }

        /// <inheritdoc />
        public string Schema { get; set; }

        /// <inheritdoc />
        public string Id { get; set; }

        /// <inheritdoc />
        public string Comment { get; set; }

        /// <inheritdoc />
        public IDictionary<string, bool> Vocabulary { get; set; }

        /// <inheritdoc />
        public string DynamicRef { get; set; }

        /// <inheritdoc />
        public string DynamicAnchor { get; set; }

        /// <inheritdoc />
        public IDictionary<string, IOpenApiSchema> Definitions { get; set; }

        /// <inheritdoc />
        public decimal? V31ExclusiveMaximum { get; set; }

        /// <inheritdoc />
        public decimal? V31ExclusiveMinimum { get; set; }

        /// <inheritdoc />
        public bool UnEvaluatedProperties { get; set; }     

        /// <inheritdoc />
        public JsonSchemaType? Type { get; set; }

        /// <inheritdoc />
        public string Const { get; set; }

        /// <inheritdoc />
        public string Format { get; set; }

        /// <inheritdoc />
        public string Description { get; set; }

        /// <inheritdoc />
        public decimal? Maximum { get; set; }

        /// <inheritdoc />
        public bool? ExclusiveMaximum { get; set; }

        /// <inheritdoc />
        public decimal? Minimum { get; set; }

        /// <inheritdoc />
        public bool? ExclusiveMinimum { get; set; }

        /// <inheritdoc />
        public int? MaxLength { get; set; }

        /// <inheritdoc />
        public int? MinLength { get; set; }

        /// <inheritdoc />
        public string Pattern { get; set; }

        /// <inheritdoc />
        public decimal? MultipleOf { get; set; }

        /// <inheritdoc />
        public JsonNode Default { get; set; }

        /// <inheritdoc />
        public bool ReadOnly { get; set; }

        /// <inheritdoc />
        public bool WriteOnly { get; set; }

        /// <inheritdoc />
        public IList<IOpenApiSchema> AllOf { get; set; } = [];

        /// <inheritdoc />
        public IList<IOpenApiSchema> OneOf { get; set; } = [];

        /// <inheritdoc />
        public IList<IOpenApiSchema> AnyOf { get; set; } = [];

        /// <inheritdoc />
        public IOpenApiSchema Not { get; set; }

        /// <inheritdoc />
        public ISet<string> Required { get; set; } = new HashSet<string>();

        /// <inheritdoc />
        public IOpenApiSchema Items { get; set; }

        /// <inheritdoc />
        public int? MaxItems { get; set; }

        /// <inheritdoc />
        public int? MinItems { get; set; }

        /// <inheritdoc />
        public bool? UniqueItems { get; set; }

        /// <inheritdoc />
        public IDictionary<string, IOpenApiSchema> Properties { get; set; } = new Dictionary<string, IOpenApiSchema>(StringComparer.Ordinal);

        /// <inheritdoc />
        public IDictionary<string, IOpenApiSchema> PatternProperties { get; set; } = new Dictionary<string, IOpenApiSchema>(StringComparer.Ordinal);

        /// <inheritdoc />
        public int? MaxProperties { get; set; }

        /// <inheritdoc />
        public int? MinProperties { get; set; }

        /// <inheritdoc />
        public bool AdditionalPropertiesAllowed { get; set; } = true;

        /// <inheritdoc />
        public IOpenApiSchema AdditionalProperties { get; set; }

        /// <inheritdoc />
        public OpenApiDiscriminator Discriminator { get; set; }

        /// <inheritdoc />
        public JsonNode Example { get; set; }

        /// <inheritdoc />
        public IList<JsonNode> Examples { get; set; }

        /// <inheritdoc />
        public IList<JsonNode> Enum { get; set; } = new List<JsonNode>();

        /// <inheritdoc />
        public bool Nullable { get; set; }

        /// <inheritdoc />
        public bool UnevaluatedProperties { get; set;}

        /// <inheritdoc />
        public OpenApiExternalDocs ExternalDocs { get; set; }

        /// <inheritdoc />
        public bool Deprecated { get; set; }

        /// <inheritdoc />
        public OpenApiXml Xml { get; set; }

        /// <inheritdoc />
        public IDictionary<string, IOpenApiExtension> Extensions { get; set; } = new Dictionary<string, IOpenApiExtension>();

        /// <inheritdoc />
        public IDictionary<string, JsonNode> UnrecognizedKeywords { get; set; } = new Dictionary<string, JsonNode>();

        /// <inheritdoc />
        public IDictionary<string, object> Annotations { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public OpenApiSchema() { }

        /// <summary>
        /// Initializes a copy of <see cref="IOpenApiSchema"/> object
        /// </summary>
        /// <param name="schema">The schema object to copy from.</param>
        public OpenApiSchema(IOpenApiSchema schema)
        {
            Title = schema?.Title ?? Title;
            Id = schema?.Id ?? Id;
            Const = schema?.Const ?? Const;
            Schema = schema?.Schema ?? Schema;
            Comment = schema?.Comment ?? Comment;
            Vocabulary = schema?.Vocabulary != null ? new Dictionary<string, bool>(schema.Vocabulary) : null;
            DynamicAnchor = schema?.DynamicAnchor ?? DynamicAnchor;
            DynamicRef = schema?.DynamicRef ?? DynamicRef;
            Definitions = schema?.Definitions != null ? new Dictionary<string, IOpenApiSchema>(schema.Definitions) : null;
            UnevaluatedProperties = schema?.UnevaluatedProperties ?? UnevaluatedProperties;
            V31ExclusiveMaximum = schema?.V31ExclusiveMaximum ?? V31ExclusiveMaximum;
            V31ExclusiveMinimum = schema?.V31ExclusiveMinimum ?? V31ExclusiveMinimum;
            Type = schema?.Type ?? Type;
            Format = schema?.Format ?? Format;
            Description = schema?.Description ?? Description;
            Maximum = schema?.Maximum ?? Maximum;
            ExclusiveMaximum = schema?.ExclusiveMaximum ?? ExclusiveMaximum;
            Minimum = schema?.Minimum ?? Minimum;
            ExclusiveMinimum = schema?.ExclusiveMinimum ?? ExclusiveMinimum;
            MaxLength = schema?.MaxLength ?? MaxLength;
            MinLength = schema?.MinLength ?? MinLength;
            Pattern = schema?.Pattern ?? Pattern;
            MultipleOf = schema?.MultipleOf ?? MultipleOf;
            Default = schema?.Default != null ? JsonNodeCloneHelper.Clone(schema?.Default) : null;
            ReadOnly = schema?.ReadOnly ?? ReadOnly;
            WriteOnly = schema?.WriteOnly ?? WriteOnly;
            AllOf = schema?.AllOf != null ? new List<IOpenApiSchema>(schema.AllOf) : null;
            OneOf = schema?.OneOf != null ? new List<IOpenApiSchema>(schema.OneOf) : null;
            AnyOf = schema?.AnyOf != null ? new List<IOpenApiSchema>(schema.AnyOf) : null;
            Not = schema?.Not != null ? new OpenApiSchema(schema?.Not) : null;
            Required = schema?.Required != null ? new HashSet<string>(schema.Required) : null;
            Items = schema?.Items != null ? new OpenApiSchema(schema?.Items) : null;
            MaxItems = schema?.MaxItems ?? MaxItems;
            MinItems = schema?.MinItems ?? MinItems;
            UniqueItems = schema?.UniqueItems ?? UniqueItems;
            Properties = schema?.Properties != null ? new Dictionary<string, IOpenApiSchema>(schema.Properties) : null;
            PatternProperties = schema?.PatternProperties != null ? new Dictionary<string, IOpenApiSchema>(schema.PatternProperties) : null;
            MaxProperties = schema?.MaxProperties ?? MaxProperties;
            MinProperties = schema?.MinProperties ?? MinProperties;
            AdditionalPropertiesAllowed = schema?.AdditionalPropertiesAllowed ?? AdditionalPropertiesAllowed;
            AdditionalProperties = schema?.AdditionalProperties != null ? new OpenApiSchema(schema?.AdditionalProperties) : null;
            Discriminator = schema?.Discriminator != null ? new(schema?.Discriminator) : null; 
            Example = schema?.Example != null ? JsonNodeCloneHelper.Clone(schema?.Example) : null;
            Examples = schema?.Examples != null ? new List<JsonNode>(schema.Examples) : null;
            Enum = schema?.Enum != null ? new List<JsonNode>(schema.Enum) : null;
            Nullable = schema?.Nullable ?? Nullable;
            ExternalDocs = schema?.ExternalDocs != null ? new(schema?.ExternalDocs) : null;
            Deprecated = schema?.Deprecated ?? Deprecated;
            Xml = schema?.Xml != null ? new(schema?.Xml) : null;
            Extensions = schema?.Extensions != null ? new Dictionary<string, IOpenApiExtension>(schema.Extensions) : null;
            Annotations = schema?.Annotations != null ? new Dictionary<string, object>(schema?.Annotations) : null;
            UnrecognizedKeywords = schema?.UnrecognizedKeywords != null ? new Dictionary<string, JsonNode>(schema?.UnrecognizedKeywords) : null;
        }

        /// <inheritdoc />
        public void SerializeAsV31(IOpenApiWriter writer)
        {
            SerializeInternal(writer, OpenApiSpecVersion.OpenApi3_1, (writer, element) => element.SerializeAsV31(writer));
        }

        /// <inheritdoc />
        public void SerializeAsV3(IOpenApiWriter writer)
        {
            SerializeInternal(writer, OpenApiSpecVersion.OpenApi3_0, (writer, element) => element.SerializeAsV3(writer));
        }

        private void SerializeInternal(IOpenApiWriter writer, OpenApiSpecVersion version,
            Action<IOpenApiWriter, IOpenApiSerializable> callback)
        {
            writer.WriteStartObject();

            if (version == OpenApiSpecVersion.OpenApi3_1)
            {
                WriteJsonSchemaKeywords(writer);
            }

            // title
            writer.WriteProperty(OpenApiConstants.Title, Title);

            // multipleOf
            writer.WriteProperty(OpenApiConstants.MultipleOf, MultipleOf);

            // maximum
            writer.WriteProperty(OpenApiConstants.Maximum, Maximum);

            // exclusiveMaximum
            writer.WriteProperty(OpenApiConstants.ExclusiveMaximum, ExclusiveMaximum);

            // minimum
            writer.WriteProperty(OpenApiConstants.Minimum, Minimum);

            // exclusiveMinimum
            writer.WriteProperty(OpenApiConstants.ExclusiveMinimum, ExclusiveMinimum);

            // maxLength
            writer.WriteProperty(OpenApiConstants.MaxLength, MaxLength);

            // minLength
            writer.WriteProperty(OpenApiConstants.MinLength, MinLength);

            // pattern
            writer.WriteProperty(OpenApiConstants.Pattern, Pattern);

            // maxItems
            writer.WriteProperty(OpenApiConstants.MaxItems, MaxItems);

            // minItems
            writer.WriteProperty(OpenApiConstants.MinItems, MinItems);

            // uniqueItems
            writer.WriteProperty(OpenApiConstants.UniqueItems, UniqueItems);

            // maxProperties
            writer.WriteProperty(OpenApiConstants.MaxProperties, MaxProperties);

            // minProperties
            writer.WriteProperty(OpenApiConstants.MinProperties, MinProperties);

            // required
            writer.WriteOptionalCollection(OpenApiConstants.Required, Required, (w, s) => w.WriteValue(s));

            // enum
            writer.WriteOptionalCollection(OpenApiConstants.Enum, Enum, (nodeWriter, s) => nodeWriter.WriteAny(s));

            // type
            SerializeTypeProperty(Type, writer, version);

            // allOf
            writer.WriteOptionalCollection(OpenApiConstants.AllOf, AllOf, callback);

            // anyOf
            writer.WriteOptionalCollection(OpenApiConstants.AnyOf, AnyOf, callback);

            // oneOf
            writer.WriteOptionalCollection(OpenApiConstants.OneOf, OneOf, callback);

            // not
            writer.WriteOptionalObject(OpenApiConstants.Not, Not, callback);

            // items
            writer.WriteOptionalObject(OpenApiConstants.Items, Items, callback);

            // properties
            writer.WriteOptionalMap(OpenApiConstants.Properties, Properties, callback);

            // additionalProperties
            if (AdditionalPropertiesAllowed)
            {
                writer.WriteOptionalObject(
                    OpenApiConstants.AdditionalProperties,
                    AdditionalProperties,
                    callback);
            }
            else
            {
                writer.WriteProperty(OpenApiConstants.AdditionalProperties, AdditionalPropertiesAllowed);
            }

            // description
            writer.WriteProperty(OpenApiConstants.Description, Description);

            // format
            writer.WriteProperty(OpenApiConstants.Format, Format);

            // default
            writer.WriteOptionalObject(OpenApiConstants.Default, Default, (w, d) => w.WriteAny(d));

            // discriminator
            writer.WriteOptionalObject(OpenApiConstants.Discriminator, Discriminator, callback);

            // readOnly
            writer.WriteProperty(OpenApiConstants.ReadOnly, ReadOnly, false);

            // writeOnly
            writer.WriteProperty(OpenApiConstants.WriteOnly, WriteOnly, false);

            // xml
            writer.WriteOptionalObject(OpenApiConstants.Xml, Xml, (w, s) => s.SerializeAsV2(w));

            // externalDocs
            writer.WriteOptionalObject(OpenApiConstants.ExternalDocs, ExternalDocs, callback);

            // example
            writer.WriteOptionalObject(OpenApiConstants.Example, Example, (w, e) => w.WriteAny(e));

            // deprecated
            writer.WriteProperty(OpenApiConstants.Deprecated, Deprecated, false);

            // extensions
            writer.WriteExtensions(Extensions, version);

            // Unrecognized keywords
            if (UnrecognizedKeywords.Any())
            {
                writer.WriteOptionalMap(OpenApiConstants.UnrecognizedKeywords, UnrecognizedKeywords, (w,s) => w.WriteAny(s));
            }

            writer.WriteEndObject();
        }

        /// <inheritdoc />
        public void SerializeAsV2(IOpenApiWriter writer)
        {
            SerializeAsV2(writer: writer, parentRequiredProperties: new HashSet<string>(), propertyName: null);
        }

        internal void WriteJsonSchemaKeywords(IOpenApiWriter writer)
        {
            writer.WriteProperty(OpenApiConstants.Id, Id);
            writer.WriteProperty(OpenApiConstants.DollarSchema, Schema);
            writer.WriteProperty(OpenApiConstants.Comment, Comment);
            writer.WriteProperty(OpenApiConstants.Const, Const);
            writer.WriteOptionalMap(OpenApiConstants.Vocabulary, Vocabulary, (w, s) => w.WriteValue(s));
            writer.WriteOptionalMap(OpenApiConstants.Defs, Definitions, (w, s) => s.SerializeAsV31(w));
            writer.WriteProperty(OpenApiConstants.DynamicRef, DynamicRef);
            writer.WriteProperty(OpenApiConstants.DynamicAnchor, DynamicAnchor);
            writer.WriteProperty(OpenApiConstants.V31ExclusiveMaximum, V31ExclusiveMaximum);
            writer.WriteProperty(OpenApiConstants.V31ExclusiveMinimum, V31ExclusiveMinimum);            
            writer.WriteProperty(OpenApiConstants.UnevaluatedProperties, UnevaluatedProperties, false);
            writer.WriteOptionalCollection(OpenApiConstants.Examples, Examples, (nodeWriter, s) => nodeWriter.WriteAny(s));
            writer.WriteOptionalMap(OpenApiConstants.PatternProperties, PatternProperties, (w, s) => s.SerializeAsV31(w));
        }

        internal void WriteAsItemsProperties(IOpenApiWriter writer)
        {
            // type
            writer.WriteProperty(OpenApiConstants.Type, Type.ToIdentifier());

            // format
            WriteFormatProperty(writer);

            // items
            writer.WriteOptionalObject(OpenApiConstants.Items, Items, (w, s) => s.SerializeAsV2(w));

            // collectionFormat
            // We need information from style in parameter to populate this.
            // The best effort we can make is to pull this information from the first parameter
            // that leverages this schema. However, that in itself may not be as simple
            // as the schema directly under parameter might be referencing one in the Components,
            // so we will need to do a full scan of the object before we can write the value for
            // this property. This is not supported yet, so we will skip this property at the moment.

            // default
            writer.WriteOptionalObject(OpenApiConstants.Default, Default, (w, d) => w.WriteAny(d));

            // maximum
            writer.WriteProperty(OpenApiConstants.Maximum, Maximum);

            // exclusiveMaximum
            writer.WriteProperty(OpenApiConstants.ExclusiveMaximum, ExclusiveMaximum);

            // minimum
            writer.WriteProperty(OpenApiConstants.Minimum, Minimum);

            // exclusiveMinimum
            writer.WriteProperty(OpenApiConstants.ExclusiveMinimum, ExclusiveMinimum);

            // maxLength
            writer.WriteProperty(OpenApiConstants.MaxLength, MaxLength);

            // minLength
            writer.WriteProperty(OpenApiConstants.MinLength, MinLength);

            // pattern
            writer.WriteProperty(OpenApiConstants.Pattern, Pattern);

            // maxItems
            writer.WriteProperty(OpenApiConstants.MaxItems, MaxItems);

            // minItems
            writer.WriteProperty(OpenApiConstants.MinItems, MinItems);

            // enum
            writer.WriteOptionalCollection(OpenApiConstants.Enum, Enum, (w, s) => w.WriteAny(s));

            // multipleOf
            writer.WriteProperty(OpenApiConstants.MultipleOf, MultipleOf);

            // extensions
            writer.WriteExtensions(Extensions, OpenApiSpecVersion.OpenApi2_0);
        }

        private void WriteFormatProperty(IOpenApiWriter writer)
        {
            var formatToWrite = Format;
            if (string.IsNullOrEmpty(formatToWrite))
            {
                formatToWrite = AllOf?.FirstOrDefault(static x => !string.IsNullOrEmpty(x.Format))?.Format ??
                    AnyOf?.FirstOrDefault(static x => !string.IsNullOrEmpty(x.Format))?.Format ??
                    OneOf?.FirstOrDefault(static x => !string.IsNullOrEmpty(x.Format))?.Format;
            }

            writer.WriteProperty(OpenApiConstants.Format, formatToWrite);
        }

        /// <summary>
        /// Serialize <see cref="OpenApiSchema"/> to Open Api v2.0 and handles not marking the provided property
        /// as readonly if its included in the provided list of required properties of parent schema.
        /// </summary>
        /// <param name="writer">The open api writer.</param>
        /// <param name="parentRequiredProperties">The list of required properties in parent schema.</param>
        /// <param name="propertyName">The property name that will be serialized.</param>
        private void SerializeAsV2(
            IOpenApiWriter writer,
            ISet<string> parentRequiredProperties,
            string propertyName)
        {
            parentRequiredProperties ??= new HashSet<string>();

            writer.WriteStartObject();

            // type
            SerializeTypeProperty(Type, writer, OpenApiSpecVersion.OpenApi2_0);

            // description
            writer.WriteProperty(OpenApiConstants.Description, Description);

            // format
            WriteFormatProperty(writer);

            // title
            writer.WriteProperty(OpenApiConstants.Title, Title);

            // default
            writer.WriteOptionalObject(OpenApiConstants.Default, Default, (w, d) => w.WriteAny(d));

            // multipleOf
            writer.WriteProperty(OpenApiConstants.MultipleOf, MultipleOf);

            // maximum
            writer.WriteProperty(OpenApiConstants.Maximum, Maximum);

            // exclusiveMaximum
            writer.WriteProperty(OpenApiConstants.ExclusiveMaximum, ExclusiveMaximum);

            // minimum
            writer.WriteProperty(OpenApiConstants.Minimum, Minimum);

            // exclusiveMinimum
            writer.WriteProperty(OpenApiConstants.ExclusiveMinimum, ExclusiveMinimum);

            // maxLength
            writer.WriteProperty(OpenApiConstants.MaxLength, MaxLength);

            // minLength
            writer.WriteProperty(OpenApiConstants.MinLength, MinLength);

            // pattern
            writer.WriteProperty(OpenApiConstants.Pattern, Pattern);

            // maxItems
            writer.WriteProperty(OpenApiConstants.MaxItems, MaxItems);

            // minItems
            writer.WriteProperty(OpenApiConstants.MinItems, MinItems);

            // uniqueItems
            writer.WriteProperty(OpenApiConstants.UniqueItems, UniqueItems);

            // maxProperties
            writer.WriteProperty(OpenApiConstants.MaxProperties, MaxProperties);

            // minProperties
            writer.WriteProperty(OpenApiConstants.MinProperties, MinProperties);

            // required
            writer.WriteOptionalCollection(OpenApiConstants.Required, Required, (w, s) => w.WriteValue(s));

            // enum
            writer.WriteOptionalCollection(OpenApiConstants.Enum, Enum, (w, s) => w.WriteAny(s));

            // items
            writer.WriteOptionalObject(OpenApiConstants.Items, Items, (w, s) => s.SerializeAsV2(w));

            // allOf
            writer.WriteOptionalCollection(OpenApiConstants.AllOf, AllOf, (w, s) => s.SerializeAsV2(w));

            // If there isn't already an allOf, and the schema contains a oneOf or anyOf write an allOf with the first
            // schema in the list as an attempt to guess at a graceful downgrade situation.
            if (AllOf == null || AllOf.Count == 0)
            {
                // anyOf (Not Supported in V2)  - Write the first schema only as an allOf.
                writer.WriteOptionalCollection(OpenApiConstants.AllOf, AnyOf?.Take(1), (w, s) => s.SerializeAsV2(w));

                if (AnyOf == null || AnyOf.Count == 0)
                {
                    // oneOf (Not Supported in V2) - Write the first schema only as an allOf.
                    writer.WriteOptionalCollection(OpenApiConstants.AllOf, OneOf?.Take(1), (w, s) => s.SerializeAsV2(w));
                }
            }

            // properties
            writer.WriteOptionalMap(OpenApiConstants.Properties, Properties, (w, key, s) =>
            {
                if (s is OpenApiSchema oais)
                    oais.SerializeAsV2(w, Required, key);
                else
                    s.SerializeAsV2(w);
            });

            // additionalProperties
            if (AdditionalPropertiesAllowed)
            {
                writer.WriteOptionalObject(
                    OpenApiConstants.AdditionalProperties,
                    AdditionalProperties,
                    (w, s) => s.SerializeAsV2(w));
            }
            else
            {
                writer.WriteProperty(OpenApiConstants.AdditionalProperties, AdditionalPropertiesAllowed);
            }

            // discriminator
            writer.WriteProperty(OpenApiConstants.Discriminator, Discriminator?.PropertyName);

            // readOnly
            // In V2 schema if a property is part of required properties of parent schema,
            // it cannot be marked as readonly.
            if (!parentRequiredProperties.Contains(propertyName))
            {
                writer.WriteProperty(name: OpenApiConstants.ReadOnly, value: ReadOnly, defaultValue: false);
            }

            // xml
            writer.WriteOptionalObject(OpenApiConstants.Xml, Xml, (w, s) => s.SerializeAsV2(w));

            // externalDocs
            writer.WriteOptionalObject(OpenApiConstants.ExternalDocs, ExternalDocs, (w, s) => s.SerializeAsV2(w));

            // example
            writer.WriteOptionalObject(OpenApiConstants.Example, Example, (w, e) => w.WriteAny(e));

            // extensions
            writer.WriteExtensions(Extensions, OpenApiSpecVersion.OpenApi2_0);

            writer.WriteEndObject();
        }

        private void SerializeTypeProperty(JsonSchemaType? type, IOpenApiWriter writer, OpenApiSpecVersion version)
        {
            // check whether nullable is true for upcasting purposes
            var isNullable = Nullable ||
                            Type is JsonSchemaType.Null ||
                                Extensions is not null &&
                                Extensions.TryGetValue(OpenApiConstants.NullableExtension, out var nullExtRawValue) && 
                                nullExtRawValue is OpenApiAny { Node: JsonNode jsonNode} &&
                                jsonNode.GetValueKind() is JsonValueKind.True;
            if (type is null)
            {
                if (version is OpenApiSpecVersion.OpenApi3_0 && isNullable)
                {
                    writer.WriteProperty(OpenApiConstants.Nullable, true);
                }
            }
            else if (!HasMultipleTypes(type.Value))
            {
                
                switch (version)
                {
                    case OpenApiSpecVersion.OpenApi3_1 when isNullable:
                        UpCastSchemaTypeToV31(type.Value, writer);
                        break;
                    case OpenApiSpecVersion.OpenApi3_0 when isNullable && type.Value == JsonSchemaType.Null:
                        writer.WriteProperty(OpenApiConstants.Nullable, true);
                        writer.WriteProperty(OpenApiConstants.Type, JsonSchemaType.Object.ToIdentifier());
                        break;
                    case OpenApiSpecVersion.OpenApi3_0 when isNullable && type.Value != JsonSchemaType.Null:
                        writer.WriteProperty(OpenApiConstants.Nullable, true);
                        writer.WriteProperty(OpenApiConstants.Type, type.Value.ToIdentifier());
                        break;
                    default:
                        writer.WriteProperty(OpenApiConstants.Type, type.Value.ToIdentifier());
                        break;
                }
            }
            else
            {
                // type
                if (version is OpenApiSpecVersion.OpenApi2_0 || version is OpenApiSpecVersion.OpenApi3_0)
                {
                    DowncastTypeArrayToV2OrV3(type.Value, writer, version);
                }
                else
                {
                    var list = (from JsonSchemaType flag in jsonSchemaTypeValues
                                where type.Value.HasFlag(flag)
                                select flag).ToList();
                    if (Nullable && !list.Contains(JsonSchemaType.Null))
                    {
                        list.Add(JsonSchemaType.Null);
                    }
                    writer.WriteOptionalCollection(OpenApiConstants.Type, list, (w, s) => w.WriteValue(s.ToIdentifier()));
                }
            } 
        }

        private static bool IsPowerOfTwo(int x)
        {
            return x != 0 && (x & (x - 1)) == 0;
        }

        private static bool HasMultipleTypes(JsonSchemaType schemaType)
        {
            var schemaTypeNumeric = (int)schemaType;
            return !IsPowerOfTwo(schemaTypeNumeric) && // Boolean, Integer, Number, String, Array, Object
                    schemaTypeNumeric != (int)JsonSchemaType.Null;
        }

        private void UpCastSchemaTypeToV31(JsonSchemaType type, IOpenApiWriter writer)
        {
            // create a new array and insert the type and "null" as values
            var temporaryType = type | JsonSchemaType.Null;
            var list = (from JsonSchemaType? flag in jsonSchemaTypeValues// Check if the flag is set in 'type' using a bitwise AND operation
                        where temporaryType.HasFlag(flag)
                        select flag.ToIdentifier()).ToList();
            if (list.Count > 1)
            {
                writer.WriteOptionalCollection(OpenApiConstants.Type, list, (w, s) => w.WriteValue(s));
            }
            else
            {
                writer.WriteProperty(OpenApiConstants.Type, list[0]);
            }
        }

#if NET5_0_OR_GREATER
        private static readonly Array jsonSchemaTypeValues = System.Enum.GetValues<JsonSchemaType>();
#else
        private static readonly Array jsonSchemaTypeValues = System.Enum.GetValues(typeof(JsonSchemaType));
#endif

        private void DowncastTypeArrayToV2OrV3(JsonSchemaType schemaType, IOpenApiWriter writer, OpenApiSpecVersion version)
        {
            /* If the array has one non-null value, emit Type as string
            * If the array has one null value, emit x-nullable as true
            * If the array has two values, one null and one non-null, emit Type as string and x-nullable as true
            * If the array has more than two values or two non-null values, do not emit type
            * */

            var nullableProp = version.Equals(OpenApiSpecVersion.OpenApi2_0)
                ? OpenApiConstants.NullableExtension
                : OpenApiConstants.Nullable;

            if (!HasMultipleTypes(schemaType ^ JsonSchemaType.Null) && (schemaType & JsonSchemaType.Null) == JsonSchemaType.Null) // checks for two values and one is null
            {
                foreach (JsonSchemaType? flag in jsonSchemaTypeValues)
                {
                    // Skip if the flag is not set or if it's the Null flag
                    if (schemaType.HasFlag(flag) && flag != JsonSchemaType.Null)
                    {
                        // Write the non-null flag value to the writer
                        writer.WriteProperty(OpenApiConstants.Type, flag.ToIdentifier());
                    }
                }
                if (!Nullable)
                {
                    writer.WriteProperty(nullableProp, true);
                }
            }
            else if (!HasMultipleTypes(schemaType))
            {
                if (schemaType is JsonSchemaType.Null)
                {
                    writer.WriteProperty(nullableProp, true);
                }
                else
                {
                    writer.WriteProperty(OpenApiConstants.Type, schemaType.ToIdentifier());
                }
            }
        }
    }
}
