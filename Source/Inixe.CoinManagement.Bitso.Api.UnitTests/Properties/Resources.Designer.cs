﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inixe.CoinManagement.Bitso.Api.UnitTests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Inixe.CoinManagement.Bitso.Api.UnitTests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;success&quot;: true,
        ///    &quot;payload&quot;: {
        ///        &quot;client_id&quot;: &quot;1234&quot;,
        ///        &quot;first_name&quot;: &quot;Claude&quot;,
        ///        &quot;last_name&quot;:  &quot;Shannon&quot;,
        ///        &quot;status&quot;: &quot;active&quot;,
        ///        &quot;daily_limit&quot;: &quot;5300.00&quot;,
        ///        &quot;monthly_limit&quot;: &quot;32000.00&quot;,
        ///        &quot;daily_remaining&quot;: &quot;3300.00&quot;,
        ///        &quot;monthly_remaining&quot;: &quot;31000.00&quot;,
        ///        &quot;cellphone_number&quot;: &quot;verified&quot;,
        ///        &quot;cellphone_number_stored&quot;:&quot;+525555555555&quot;,
        ///        &quot;email_stored&quot;:&quot;shannon@maxentro.py&quot;,
        ///        &quot;official_id&quot;: &quot;submitted&quot;,
        ///        &quot;pro [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AccountStatusResponse {
            get {
                return ResourceManager.GetString("AccountStatusResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;success&quot;: true,
        ///    &quot;payload&quot;:
        ///{
        ///        &quot;book&quot;: &quot;btc_mxn&quot;,
        ///        &quot;original_amount&quot;: &quot;0.01000000&quot;,
        ///        &quot;unfilled_amount&quot;: &quot;0.00500000&quot;,
        ///        &quot;original_value&quot;: &quot;56.0&quot;,
        ///        &quot;created_at&quot;: &quot;2016-04-08T17:52:31.000+00:00&quot;,
        ///        &quot;updated_at&quot;: &quot;2016-04-08T17:52:51.000+00:00&quot;,
        ///        &quot;price&quot;: &quot;5600.00&quot;,
        ///        &quot;oid&quot;: &quot;543cr2v32a1h68443&quot;,
        ///        &quot;side&quot;: &quot;buy&quot;,
        ///        &quot;status&quot;: &quot;partial-fill&quot;,
        ///        &quot;type&quot;: &quot;limit&quot;
        ///    }
        ///	}.
        /// </summary>
        internal static string PlaceOrderResponse {
            get {
                return ResourceManager.GetString("PlaceOrderResponse", resourceCulture);
            }
        }
    }
}