﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de.hmmueller.PathGCodeAdjustZ {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages___Kopieren {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages___Kopieren() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PathGCodeAdjustZ.Messages - Kopieren", typeof(Messages___Kopieren).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
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
        ///   Sucht eine lokalisierte Zeichenfolge, die             Aufruf: PathGCodeAdjustZ [Parameter] [GCode-Dateien]
        ///
        ///            Parameter:
        ///                /h     Hilfe-Anzeige ähnelt.
        /// </summary>
        internal static string Options_Help {
            get {
                return ResourceManager.GetString("Options_Help", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die end of expression expected at column {0} ähnelt.
        /// </summary>
        internal static string Program_EndOfExprExpected_Pos {
            get {
                return ResourceManager.GetString("Program_EndOfExprExpected_Pos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Zeile hat nicht das Format &apos;(Kommentar) #...=Wert&apos; ähnelt.
        /// </summary>
        internal static string Program_InvalidLineFormat {
            get {
                return ResourceManager.GetString("Program_InvalidLineFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Wert &apos;{1}&apos; für {0} ist keine gültige Zahl ähnelt.
        /// </summary>
        internal static string Program_NaN_Name_Value {
            get {
                return ResourceManager.GetString("Program_NaN_Name_Value", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Keine G-Code-Dateien angegeben ähnelt.
        /// </summary>
        internal static string Program_NoGCodeFiles {
            get {
                return ResourceManager.GetString("Program_NoGCodeFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Einlesen von {0} ähnelt.
        /// </summary>
        internal static string Program_Reading_File {
            get {
                return ResourceManager.GetString("Program_Reading_File", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die &apos;)&apos; expected at column {0} ähnelt.
        /// </summary>
        internal static string Program_RParExpected_Pos {
            get {
                return ResourceManager.GetString("Program_RParExpected_Pos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Unexpected &apos;{0}&apos; at column {1} ähnelt.
        /// </summary>
        internal static string Program_Unexpected_Char_Pos {
            get {
                return ResourceManager.GetString("Program_Unexpected_Char_Pos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Schreiben von {0} ähnelt.
        /// </summary>
        internal static string Program_Writing_File {
            get {
                return ResourceManager.GetString("Program_Writing_File", resourceCulture);
            }
        }
    }
}
