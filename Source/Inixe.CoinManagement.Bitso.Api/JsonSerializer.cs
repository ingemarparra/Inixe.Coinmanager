// -----------------------------------------------------------------------
// <copyright file="JsonSerializer.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    public class JsonSerializer : IDeserializer, ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializer"/> class.
        /// </summary>
        /// <remarks>None</remarks>
        public JsonSerializer()
        {
            this.ContentType = "application/json";
            this.serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializer"/> class.
        /// Default serializer with overload for allowing custom Json.NET settings
        /// </summary>
        /// <param name="serializer">The selected serializer</param>
        /// <remarks>None</remarks>
        public JsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.ContentType = "application/json";
            this.serializer = serializer;
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
            return JsonConvert.DeserializeObject<T>(content);
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
    }
}
