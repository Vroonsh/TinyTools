﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinyTools.FirmwareFlashersTinyTool {
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
    internal class FirmwareFlashersResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FirmwareFlashersResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TinyTools.FirmwareFlashersTinyTool.FirmwareFlashersResources", typeof(FirmwareFlashersResources).Assembly);
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
        ///   Looks up a localized string similar to With this tool you can flash firmwares for both Teensy &amp; Wemos hardwares.
        ///These firmware are used with DirectOutput to trigger adressable leds effects.
        ///
        ///Thsi tool is using two CLI flashers for both Teensy &amp; Wemos.
        ///https://github.com/espressif/esptool
        ///https://github.com/PaulStoffregen/teensy_loader_cli
        ///.
        /// </summary>
        internal static string About_Description {
            get {
                return ResourceManager.GetString("About.Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WARNING ! Please check first if the latest R3++ is up to date with this version (if it&apos;s newer it&apos;s probably up to date), prefer the official version.
        ///
        ///Otherwize, copy this modified DirectOutput.DLL to your DirectOutput directory to match these Wemos firmwares.
        ///Don&apos;t do a copy of the previous one and redo a RegisterDirectOutputComObject.
        ///This DLL is based on the last version of Mrj R3++ unified version..
        /// </summary>
        internal static string DirectOutput_Message {
            get {
                return ResourceManager.GetString("DirectOutput.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modified DirectOutput.DLL.
        /// </summary>
        internal static string DirectOutput_Title {
            get {
                return ResourceManager.GetString("DirectOutput.Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something was wrong while flashing your card, please try again.
        /// </summary>
        internal static string FlashError_Message {
            get {
                return ResourceManager.GetString("FlashError.Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Card flash failed.
        /// </summary>
        internal static string FlashError_Title {
            get {
                return ResourceManager.GetString("FlashError.Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About.
        /// </summary>
        internal static string Menu_About {
            get {
                return ResourceManager.GetString("Menu.About", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a Teensy firmware file.
        /// </summary>
        internal static string OpenFile_TeensyFirmware {
            get {
                return ResourceManager.GetString("OpenFile.TeensyFirmware", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a Wemos firmware file.
        /// </summary>
        internal static string OpenFile_WemosFirmware {
            get {
                return ResourceManager.GetString("OpenFile.WemosFirmware", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Teensy32 {
            get {
                object obj = ResourceManager.GetObject("Teensy32", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Teensy40 {
            get {
                object obj = ResourceManager.GetObject("Teensy40", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Firmware flashers.
        /// </summary>
        internal static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Wemos {
            get {
                object obj = ResourceManager.GetObject("Wemos", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
