//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Statuses {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Statuses() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Statuses", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to Open.
        /// </summary>
        internal static string StatusOpen {
            get {
                return ResourceManager.GetString("StatusOpen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opgelost.
        /// </summary>
        internal static string StatusSolved {
            get {
                return ResourceManager.GetString("StatusSolved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Overgedragen.
        /// </summary>
        internal static string StatusTransferred {
            get {
                return ResourceManager.GetString("StatusTransferred", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nee.
        /// </summary>
        internal static string VisibleFalse {
            get {
                return ResourceManager.GetString("VisibleFalse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ja.
        /// </summary>
        internal static string VisibleTrue {
            get {
                return ResourceManager.GetString("VisibleTrue", resourceCulture);
            }
        }
    }
}
