﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StateManagement {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("StateManagement.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Cannot add an UndoService which has existing states recorded. Add it before its RecordState() method has been invoked or call its ClearStacks() method before adding it..
        /// </summary>
        internal static string AddingPopulatedSubserviceExceptionMessage {
            get {
                return ResourceManager.GetString("AddingPopulatedSubserviceExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cannot add an UndoService to an Aggregate if the service&apos;s ChangeCount is not zero. If.
        /// </summary>
        internal static string AddUndoServiceWithChanges {
            get {
                return ResourceManager.GetString("AddUndoServiceWithChanges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A clear stack method was invoked directly on an UndoService that is part of an UndoServiceAggregate. Invoke the clear stack methods on the UndoServiceAggregate instead..
        /// </summary>
        internal static string ClearStackDirectlyOnSubservice {
            get {
                return ResourceManager.GetString("ClearStackDirectlyOnSubservice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nothing to redo. Check that CanRedo is true before invoking Redo()..
        /// </summary>
        internal static string RedoWithoutCanRedo {
            get {
                return ResourceManager.GetString("RedoWithoutCanRedo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redo failed in subservice when aggregate expected it to succeed..
        /// </summary>
        internal static string SubServiceRedoFailure {
            get {
                return ResourceManager.GetString("SubServiceRedoFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Undo failed in subservice when aggregate expected it to succeed. .
        /// </summary>
        internal static string SubServiceUndoFailure {
            get {
                return ResourceManager.GetString("SubServiceUndoFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nothing to undo. Check that CanUndo is true before invoking Undo()..
        /// </summary>
        internal static string UndoWithoutCanUndo {
            get {
                return ResourceManager.GetString("UndoWithoutCanUndo", resourceCulture);
            }
        }
    }
}
