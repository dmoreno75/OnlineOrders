﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrozenLand.OnlineOrders.Website.IntegrationTests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class OrderSamples {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OrderSamples() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FrozenLand.OnlineOrders.Website.IntegrationTests.OrderSamples", typeof(OrderSamples).Assembly);
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
        ///  &quot;Created&quot;: &quot;27/05/2020 10:48:00&quot;,
        ///  &quot;Number&quot;: &quot;TEST123456&quot;,
        ///  &quot;TotalPrice&quot;: &quot;50&quot;,
        ///  &quot;TotalDelivery&quot;: &quot;10&quot;,
        ///  &quot;TotalItemsCount&quot;: &quot;2&quot;,
        ///  &quot;Customer&quot;: {
        ///    &quot;FirstName&quot;: &quot;Joe&quot;,
        ///    &quot;LastName&quot;: &quot;Smith&quot;,
        ///    &quot;Email&quot;: &quot;dmoreno@uk.com&quot;,
        ///    &quot;PhoneNumber&quot;: &quot;0123456498&quot;,
        ///    &quot;Address&quot;: {
        ///		&quot;FullAddress&quot;: &quot;1, Waterside&quot;,
        ///		&quot;Town&quot;: &quot;Accrington&quot;,
        ///		&quot;Postcode&quot;: &quot;BB51NA&quot;
        ///    }
        ///  },
        ///  &quot;Lines&quot;: [
        ///    {
        ///      &quot;SkuVariant&quot;: &quot;TOASTER-v123456&quot;,
        ///      &quot;Sku&quot;: &quot;TOASTER&quot;,
        ///      &quot;Price&quot;: 50,
        ///      &quot;Discount [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FullValidOrder {
            get {
                return ResourceManager.GetString("FullValidOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;Created&quot;: &quot;27/05/2020 10:48:00&quot;,
        ///  &quot;Number&quot;: &quot;ABC123456&quot;,
        ///  &quot;TotalPrice&quot;: &quot;50&quot;,
        ///  &quot;TotalDelivery&quot;: &quot;10&quot;,
        ///  &quot;TotalItemsCount&quot;: &quot;2&quot;,
        ///  &quot;Lines&quot;: [
        ///    {
        ///      &quot;SkuVariant&quot;: &quot;TOASTER-v123456&quot;,
        ///      &quot;Sku&quot;: &quot;TOASTER&quot;,
        ///      &quot;Price&quot;: 50,
        ///      &quot;Discount&quot;: 10,
        ///      &quot;AppliedPromotion&quot;: &quot;VOUCHER10&quot;
        ///    }
        ///  ],
        ///  &quot;Payment&quot;: {
        ///	&quot;PaymentType&quot;: &quot;Card&quot;,
        ///	&quot;AmountAuthorized&quot;: &quot;50&quot;,
        ///	&quot;Details&quot;: {
        ///		&quot;ExpYear&quot;: 2022,
        ///		&quot;ExpMonth&quot;: 5,
        ///		&quot;CardHolder&quot;: &quot;Joe Smith&quot;,
        ///		&quot;CardNumber&quot;: &quot;############1234&quot;
        ///	 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OrderWithoutCustomer {
            get {
                return ResourceManager.GetString("OrderWithoutCustomer", resourceCulture);
            }
        }
    }
}
