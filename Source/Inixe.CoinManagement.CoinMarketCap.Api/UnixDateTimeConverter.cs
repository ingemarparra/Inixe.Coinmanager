// <copyright file="UnixDateTimeConverter.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Class UnixDateTimeConverter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    /// <remarks>None</remarks>
    internal sealed class UnixDateTimeConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            if (objectType == null)
            {
                return false;
            }

            return objectType.Equals(typeof(DateTime));
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long ticks = Convert.ToInt64(reader.Value);

            return new DateTime(ticks);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
