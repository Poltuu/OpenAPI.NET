﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System.Linq;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Models.References;
using Microsoft.OpenApi.Readers.ParseNodes;

namespace Microsoft.OpenApi.Readers.V3
{
    /// <summary>
    /// Class containing logic to deserialize Open API V3 document into
    /// runtime Open API object model.
    /// </summary>
    internal static partial class OpenApiV3Deserializer
    {
        private static readonly FixedFieldMap<OpenApiExample> _exampleFixedFields = new()
        {
            {
                "summary",
                (o, n) => o.Summary = n.GetScalarValue()
            },
            {
                "description",
                (o, n) => o.Description = n.GetScalarValue()
            },
            {
                "value",
                (o, n) => o.Value = n.CreateAny()
            },
            {
                "externalValue",
                (o, n) => o.ExternalValue = n.GetScalarValue()
            },
        };

        private static readonly PatternFieldMap<OpenApiExample> _examplePatternFields =
            new()
            {
                {s => s.StartsWith("x-"), (o, p, n) => o.AddExtension(p, LoadExtension(p,n))}
            };

        public static OpenApiExample LoadExample(ParseNode node, OpenApiDocument hostDocument = null)
        {
            var mapNode = node.CheckMapNode("example");

            var pointer = mapNode.GetReferencePointer();
            if (pointer != null)
            {
                var reference = GetReferenceIdAndExternalResource(pointer);
                return new OpenApiExampleReference(reference.Item1, hostDocument, reference.Item2);
            }

            var example = new OpenApiExample();
            foreach (var property in mapNode)
            {
                property.ParseField(example, _exampleFixedFields, _examplePatternFields);
            }

            return example;
        }
    }
}
