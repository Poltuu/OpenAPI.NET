﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. 

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.OpenApi.Reader;

namespace Microsoft.OpenApi.Interfaces
{
    /// <summary>
    /// Interface for Open API readers.
    /// </summary>
    public interface IOpenApiReader
    {
        /// <summary>
        /// Async method to reads the stream and parse it into an Open API document.
        /// </summary>
        /// <param name="input">The stream input.</param>
        /// <param name="settings"> The OpenApi reader settings.</param>
        /// <param name="cancellationToken">Propagates notification that an operation should be cancelled.</param>
        /// <returns></returns>
        Task<ReadResult> ReadAsync(Stream input, OpenApiReaderSettings settings, CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides a synchronous method to read the input memory stream and parse it into an Open API document.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        ReadResult Read(MemoryStream input, OpenApiReaderSettings settings);

        /// <summary>
        /// Reads the MemoryStream and parses the fragment of an OpenAPI description into an Open API Element.
        /// </summary>
        /// <param name="input">Memory stream containing OpenAPI description to parse.</param>
        /// <param name="version">Version of the OpenAPI specification that the fragment conforms to.</param>
        /// <param name="diagnostic">Returns diagnostic object containing errors detected during parsing.</param>
        /// <param name="settings">The OpenApiReader settings.</param>
        /// <returns>Instance of newly created IOpenApiElement.</returns>
        T ReadFragment<T>(MemoryStream input, OpenApiSpecVersion version, out OpenApiDiagnostic diagnostic, OpenApiReaderSettings settings = null) where T : IOpenApiElement;
    }
}
