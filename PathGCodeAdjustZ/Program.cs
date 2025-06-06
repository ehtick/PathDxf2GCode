﻿namespace de.hmmueller.PathGCodeAdjustZ;

using de.hmmueller.PathGCodeLibrary;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.FormattableString;

public class Program {
    private const string VERSION = "2025-06-02";

    private static int Main(string[] args) {
        MessageHandler messages = new(Console.Error);

        messages.WriteLine(MessageHandler.InfoPrefix + $"PathGCodeAdjustZ (c) HMMüller 2024-2025 V.{VERSION}");

        Options? options = Options.Create(args, messages);

        if (options == null) {
            messages.WriteErrors();
            messages.WriteLine();
            Options.Usage(messages);
            return 2;
        } else if (!options.GCodeFilePaths.Any()) {
            messages.AddError("Options", Messages.Program_NoGCodeFiles);
            return 3;
        } else {
            foreach (var f in options.GCodeFilePaths) {
                Process(f, messages, options.MaxCorrection_mm, options.OutputPattern);
            }
            return messages.WriteErrors() ? 1 : 0;
        }
    }

    private static void Process(string f, MessageHandler messages, double maxCorrection_mm, string? outputPattern) {
        string basePath =
            f.EndsWith(".dxf", StringComparison.InvariantCultureIgnoreCase) ? f[..^4] :
            f.EndsWith("_Clean.gcode", StringComparison.InvariantCultureIgnoreCase) ? f[..^12] :
            f.EndsWith("_Z.txt", StringComparison.InvariantCultureIgnoreCase) ? f[..^6] :
            f.EndsWith(".gcode", StringComparison.InvariantCultureIgnoreCase) ? f[..^6] : f;
        var vars = new Dictionary<string, double>();
        string zFile = basePath + "_Z.txt";
        messages.WriteLine(MessageHandler.InfoPrefix + Messages.Program_Reading_File, zFile);
        using (var sr = new StreamReader(zFile)) {
            int lineNo = 1;
            for (string? line = null; (line = sr.ReadLine()) != null; lineNo++) {
                // Line example:
                // ([77.038 191.859]/L:ZA/T=5.000) #51=5.432
                // <        0             > <  1  > <> < 3 >
                string[] fields = line.Split([ '#', '=' ], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (fields.Length == 0) {
                    // ignore - Leerzeile
                } else if (fields.Length < 4) {
                    messages.AddError(zFile + ":" + lineNo, Messages.Program_InvalidLineFormat);
                } else {
                    string tValue = fields[1].TrimEnd(')', ' ');
                    string varName = "#" + fields[2];
                    string value = fields[3];
                    try {
                        double origT = double.Parse(tValue.Replace(',', '.'), CultureInfo.InvariantCulture);
                        double newT = double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
                        if (Math.Abs(origT - newT) > maxCorrection_mm) {
                            messages.AddError(zFile + ":" + lineNo, Messages.Program_TDiffersTooMuch_Name_Orig_New_MaxDelta, varName, tValue, value, maxCorrection_mm);
                        } else { 
                            vars.Add(varName, newT); 
                        }
                    } catch (FormatException) {
                        messages.AddError(zFile + ":" + lineNo, Messages.Program_NaN_Name_Value, varName, value);
                    }
                }
            }
        }

        if (!messages.Errors.Any()) {
            string cleanFile = basePath + "_Clean.gcode";
            messages.WriteLine(MessageHandler.InfoPrefix + Messages.Program_Reading_File, cleanFile);
            using (var sr = new StreamReader(cleanFile)) {
                string millingFile = basePath + "_Milling.gcode";
                messages.WriteLine(MessageHandler.InfoPrefix + Messages.Program_Writing_File, millingFile);
                using (var sw = new StreamWriter(millingFile)) {
                    int lineNo = 1;
                    for (string? line = null; (line = sr.ReadLine()) != null; lineNo++) {
                        Match m = Regex.Match(line, GCodeConstants.ZAdjustmentExpressionRegex);
                        if (m.Success) {
                            string expr = m.Groups[1].Value;
                            string replacement = Invariant($"{new ExprEval(vars, expr).Value:F3}(=={expr})");
                            sw.WriteLine(line[0..m.Index] + replacement + line[(m.Index + m.Length)..]);
                        } else {
                            sw.WriteLine(line);
                        }

                        if (outputPattern != null) {
                            if (Regex.IsMatch(line, outputPattern)) {
                                messages.WriteLine(MessageHandler.InfoPrefix + line);
                            }
                        }
                    }
                }
            }
        }
    }
}
