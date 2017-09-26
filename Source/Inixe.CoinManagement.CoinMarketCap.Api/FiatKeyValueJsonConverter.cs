// <copyright file="FiatKeyValueJsonConverter.cs" company="Inixe">
// Copyright (c) Inixe 2017. All rights reserved.
// </copyright>

namespace Inixe.CoinManagement.CoinMarketCap.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using RestSharp;
    using RestSharp.Deserializers;

    /// <summary>
    /// Class FiatKeyValueJsonConverter
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    /// <remarks>This converter merges currency suffixed properties into a single property</remarks>
    internal sealed class FiatKeyValueJsonConverter : JsonConverter
    {
        private static Regex rx;
        private static IDictionary<string, FiatCurrency> items;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            var targetType = typeof(IDictionary<FiatCurrency, decimal>);
            return objectType.Equals(targetType) || targetType.IsAssignableFrom(objectType);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var key = GetFiatCurrency(reader.Path);

            if (key == FiatCurrency.None)
            {
                return null;
            }

            var tmp = existingValue ?? new Dictionary<FiatCurrency, decimal>();
            var instance = tmp as Dictionary<FiatCurrency, decimal>;

            if (!instance.ContainsKey(key))
            {
                instance.Add(key, 0);
            }

            instance[key] = Convert.ToDecimal(reader.Value);

            return instance;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private static FiatCurrency GetFiatCurrency(string candidateName)
        {
            FiatCurrency retval = FiatCurrency.None;

            if (items == null)
            {
                items = LoadNames();
            }

            if (rx == null)
            {
                rx = new Regex(@"(?<Name>.+)_(?<Suffix>\w{3})$");
            }

            var res = rx.Match(candidateName);
            if (res.Success)
            {
                var currencyName = res.Groups["Suffix"].Value;
                var isValid = items.ContainsKey(currencyName);
                return !isValid ? FiatCurrency.None : items[currencyName];
            }

            return retval;
        }

        private static IDictionary<string, FiatCurrency> LoadNames()
        {
            var retval = new Dictionary<string, FiatCurrency>(StringComparer.OrdinalIgnoreCase);

            var names = Enum.GetNames(typeof(FiatCurrency));
            var pairs = names.Select(x => new KeyValuePair<string, FiatCurrency>(x, (FiatCurrency)Enum.Parse(typeof(FiatCurrency), x)));

            var col = retval as ICollection<KeyValuePair<string, FiatCurrency>>;

            foreach (var p in pairs)
            {
                col.Add(p);
            }

            return retval;
        }
    }
}
