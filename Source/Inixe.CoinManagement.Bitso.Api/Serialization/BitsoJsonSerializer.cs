// -----------------------------------------------------------------------
// <copyright file="BitsoJsonSerializer.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    public class BitsoJsonSerializer : IDeserializer, ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BitsoJsonSerializer"/> class.
        /// </summary>
        /// <remarks>None</remarks>
        public BitsoJsonSerializer()
        {
            this.ContentType = "application/json";
            this.serializer = new Newtonsoft.Json.JsonSerializer();

            this.serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            this.serializer.NullValueHandling = NullValueHandling.Include;
            this.serializer.DefaultValueHandling = DefaultValueHandling.Include;
            this.serializer.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
            this.serializer.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            this.serializer.ContractResolver = new BitsoContractResolver();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BitsoJsonSerializer" /> class.
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        /// <param name="serializer">The selected serializer</param>
        /// <remarks>None</remarks>
        public BitsoJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            if (this.serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            this.ContentType = "application/json";
            this.serializer = serializer;
        }

        /// <summary>Gets or sets a value indicating whether diagnostics information are enabled.</summary>
        /// <value><c>true</c> if diagnostics enabled is <c>True</c> serialization operations will be traced; otherwise, if is <c>false</c> no tracing takes place.</value>
        public bool DiagnosticsEnabled
        {
            get
            {
                return this.serializer.TraceWriter != null;
            }

            set
            {
                var currentValue = this.DiagnosticsEnabled;
                if (currentValue != value)
                {
                    this.serializer.TraceWriter = value ? new MemoryTraceWriter() : null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Gets or sets the Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>Deserializes the specified content.</summary>
        /// <typeparam name="T">The output Type</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>An instance of T</returns>
        public T Deserialize<T>(string content)
        {
            using (var reader = new StringReader(content))
            {
                using (var contentReader = new JsonTextReader(reader))
                {
                    return this.serializer.Deserialize<T>(contentReader);
                }
            }
        }

        /// <summary>Deserializes the specified response.</summary>
        /// <typeparam name="T">The output Type</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>An instance of T</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            return this.Deserialize<T>(response.Content);
        }

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        /// <remarks>None</remarks>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    this.serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        /// <summary>Dumps the diagnostics.</summary>
        /// <returns>A log with the serialization process data</returns>
        public string DumpDiagnostics()
        {
            return this.DiagnosticsEnabled ? this.serializer.TraceWriter.ToString() : string.Empty;
        }
    }
}
