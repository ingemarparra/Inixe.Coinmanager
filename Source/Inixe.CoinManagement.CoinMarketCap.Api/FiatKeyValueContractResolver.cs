// <copyright file="FiatKeyValueContractResolver.cs" company="Inixe">
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
    /// Class FiatKeyValueContractResolver
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    /// <remarks>Requiered by <see cref="FiatKeyValueJsonConverter"/></remarks>
    internal sealed class FiatKeyValueContractResolver : DefaultContractResolver
    {
        /// <inheritdoc/>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = base.CreateProperties(type, memberSerialization);
            var fixedProperties = props.Where(x => !IsFiatConvertibleProperty(x));

            var suffixProperties = props.Except(fixedProperties);
            var retval = fixedProperties.ToList();

            var fiatNames = Enum.GetNames(typeof(FiatCurrency)).Where(x => x != "None");

            foreach (var prop in suffixProperties)
            {
                foreach (var fiatSuffix in fiatNames)
                {
                    var suffixed = new JsonProperty();

                    suffixed.AttributeProvider = prop.AttributeProvider;
                    suffixed.Converter = prop.Converter;
                    suffixed.DeclaringType = prop.DeclaringType;
                    suffixed.DefaultValue = prop.DefaultValue;
                    suffixed.DefaultValueHandling = prop.DefaultValueHandling;
                    suffixed.GetIsSpecified = prop.GetIsSpecified;
                    suffixed.HasMemberAttribute = prop.HasMemberAttribute;
                    suffixed.Ignored = prop.Ignored;
                    suffixed.IsReference = prop.IsReference;
                    suffixed.ItemConverter = prop.ItemConverter;
                    suffixed.ItemIsReference = prop.ItemIsReference;
                    suffixed.ItemReferenceLoopHandling = prop.ItemReferenceLoopHandling;
                    suffixed.ItemTypeNameHandling = prop.ItemTypeNameHandling;
                    suffixed.MemberConverter = prop.MemberConverter;
                    suffixed.NullValueHandling = prop.NullValueHandling;
                    suffixed.ObjectCreationHandling = prop.ObjectCreationHandling;
                    suffixed.Order = null;
                    suffixed.PropertyType = prop.PropertyType;
                    suffixed.Readable = prop.Readable;
                    suffixed.ReferenceLoopHandling = prop.ReferenceLoopHandling;
                    suffixed.Required = prop.Required;
                    suffixed.SetIsSpecified = prop.SetIsSpecified;
                    suffixed.ShouldDeserialize = prop.ShouldDeserialize;
                    suffixed.ShouldSerialize = prop.ShouldSerialize;
                    suffixed.TypeNameHandling = prop.TypeNameHandling;
                    suffixed.ValueProvider = prop.ValueProvider;
                    suffixed.Writable = prop.Writable;
                    suffixed.UnderlyingName = prop.UnderlyingName;

                    suffixed.PropertyName = string.Format("{0}_{1}", prop.PropertyName, fiatSuffix.ToLowerInvariant());

                    retval.Add(suffixed);
                }
            }

            return retval;
        }

        private static bool IsFiatConvertibleProperty(JsonProperty prop)
        {
            if (prop.Converter == null)
            {
                return false;
            }
            else
            {
                return prop.Converter.GetType().Equals(typeof(FiatKeyValueJsonConverter));
            }
        }
    }
}
