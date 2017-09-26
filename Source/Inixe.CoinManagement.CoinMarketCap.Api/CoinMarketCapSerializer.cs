// <copyright file="CoinMarketCapSerializer.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
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

    /// <summary>
    /// Class CoinMarketCapSerializer
    /// </summary>
    /// <seealso cref="RestSharp.Deserializers.IDeserializer" />
    internal class CoinMarketCapSerializer : IDeserializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;

        /// <summary>Initializes a new instance of the <see cref="CoinMarketCapSerializer"/> class.</summary>
        public CoinMarketCapSerializer()
        {
            this.ContentType = "application/json";
            this.serializer = new Newtonsoft.Json.JsonSerializer();

            this.serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            this.serializer.NullValueHandling = NullValueHandling.Include;
            this.serializer.DefaultValueHandling = DefaultValueHandling.Include;
            this.serializer.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
            this.serializer.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            this.serializer.ContractResolver = new FiatKeyValueContractResolver();
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
        /// <param name="response">The response.</param>
        /// <returns>An instance of T</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            using (var reader = new StringReader(response.Content))
            {
                using (var contentReader = new JsonTextReader(reader))
                {
                    return this.serializer.Deserialize<T>(contentReader);
                }
            }
        }
    }
}
