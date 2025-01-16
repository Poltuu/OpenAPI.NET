﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Reader.ParseNodes;

namespace Microsoft.OpenApi.Reader.V3
{
    /// <summary>
    /// Class containing logic to deserialize Open API V3 document into
    /// runtime Open API object model.
    /// </summary>
    internal static partial class OpenApiV3Deserializer
    {
        private static readonly FixedFieldMap<OpenApiLicense> _licenseFixedFields = new()
        {
            {
                "name",
                (o, n, _) => o.Name = n.GetScalarValue()
            },
            {
                "url",
                (o, n, _) => o.Url = new(n.GetScalarValue(), UriKind.RelativeOrAbsolute)
            },
        };

        private static readonly PatternFieldMap<OpenApiLicense> _licensePatternFields = new()
        {
            {s => s.StartsWith("x-"), (o, p, n, _) => o.AddExtension(p, LoadExtension(p,n))}
        };

        internal static OpenApiLicense LoadLicense(ParseNode node, OpenApiDocument hostDocument)
        {
            var mapNode = node.CheckMapNode("License");

            var license = new OpenApiLicense();

            ParseMap(mapNode, license, _licenseFixedFields, _licensePatternFields, hostDocument);

            return license;
        }
    }
}
