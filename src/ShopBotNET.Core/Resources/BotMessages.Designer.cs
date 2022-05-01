﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBotNET.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class BotMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BotMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ShopBotNET.Core.Resources.BotMessages", typeof(BotMessages).Assembly);
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
        ///   Looks up a localized string similar to Select the options for your demo invoice. You&apos;ll need to supply all the requested data to &quot;pay&quot; for your &quot;purchase&quot;.
        ///
        ///&lt;b&gt;Real cards won&apos;t work with me&lt;/b&gt;, no money will be debited from your account. Use this test card number to pay for your Time Machine: &lt;code&gt;4242 4242 4242 4242&lt;/code&gt;.
        /// </summary>
        internal static string DemoInvoiceConfig {
            get {
                return ResourceManager.GetString("DemoInvoiceConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;b&gt;Real cards won&apos;t work with me&lt;/b&gt;, no money will be debited from your account. Use this test card number to pay for your Time Machine: &lt;code&gt;4242 4242 4242 4242&lt;/code&gt;
        ///
        ///This is your demo invoice:.
        /// </summary>
        internal static string DemoInvoiceResult {
            get {
                return ResourceManager.GetString("DemoInvoiceResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email.
        /// </summary>
        internal static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello, I&apos;m the demo merchant bot. I can sell you various mythical goods and services. 
        ///
        ///Use the /invoice command to create an invoice for a Time Machine. You can also use me to send invoices to any chat – simply start a message with &apos;@{0} &apos; (the space is important). For an example see the @TestStore.
        ///
        ///You can also send /terms for Terms and Conditions, and /support to leave feedback..
        /// </summary>
        internal static string Help {
            get {
                return ResourceManager.GetString("Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        internal static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phone.
        /// </summary>
        internal static string Phone {
            get {
                return ResourceManager.GetString("Phone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Photo.
        /// </summary>
        internal static string Photo {
            get {
                return ResourceManager.GetString("Photo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🛍Send Invoice.
        /// </summary>
        internal static string SendInvoiceButton {
            get {
                return ResourceManager.GetString("SendInvoiceButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Couldn&apos;t send invoice. Error from Bot API: 
        ///&lt;pre&gt;{0}&lt;/pre&gt;.
        /// </summary>
        internal static string SendInvoiceError {
            get {
                return ResourceManager.GetString("SendInvoiceError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shipping.
        /// </summary>
        internal static string Shipping {
            get {
                return ResourceManager.GetString("Shipping", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you for your &apos;payment&apos;! Don&apos;t worry, your imaginary credit card was not charged.
        ///
        ///At this step, the user should receive a confirmation message with information about the delivery or any further steps for obtaining the services they paid for..
        /// </summary>
        internal static string SuccessfulPayment {
            get {
                return ResourceManager.GetString("SuccessfulPayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please tell us about your problem with our bot..
        /// </summary>
        internal static string Support {
            get {
                return ResourceManager.GetString("Support", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, we need a more substantial text message from you. Please describe your problem in a little more detail..
        /// </summary>
        internal static string SupportInvalid {
            get {
                return ResourceManager.GetString("SupportInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thanks for reaching out to us. We&apos;ll get back to you with response as soon as we can. Please note that it may take some time..
        /// </summary>
        internal static string SupportResult {
            get {
                return ResourceManager.GetString("SupportResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you for shopping with our demo bot. We hope you like your new time machine and other goods!
        ///
        ///1. If your time machine was not delivered on time, please rethink your concept of time and try again.
        ///2. If you find that your time machine is not working, kindly contact our future service workshops on Trappist-1e. They will be accessible anywhere between May 2075 and November 4000 C.E.
        ///3. If you would like a refund, kindly apply for one yesterday and we will have sent it to you immediately..
        /// </summary>
        internal static string Terms {
            get {
                return ResourceManager.GetString("Terms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unrecognized command. Say what?.
        /// </summary>
        internal static string UnknownCommand {
            get {
                return ResourceManager.GetString("UnknownCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WebView.
        /// </summary>
        internal static string WebView {
            get {
                return ResourceManager.GetString("WebView", resourceCulture);
            }
        }
    }
}
