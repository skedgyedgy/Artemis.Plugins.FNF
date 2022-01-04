using Artemis.Core;
using Artemis.Core.LayerBrushes;
using Artemis.Core.Services;
using SkiaSharp;
using System.Collections.Generic;

namespace Artemis.Plugins.Module.FNF {
    [PluginFeature (Name = "FNF Controls Layer", Icon = "Music")]
    class FnfControlsBrushProvider : LayerBrushProvider {
        private readonly IWebServerService webServerService;

        public static Dictionary<string, string[]> Controls { get; set; } = new Dictionary<string, string[]> () {
            { "note_left", new string[2] { "left", "A" } },
            { "note_down", new string[2] { "down", "S" } },
            { "note_up", new string[2] { "up", "W" } },
            { "note_right", new string[2] { "right", "D" } }
        };
        public static Dictionary<string, SKColor> ControlColors { get; } = new Dictionary<string, SKColor> () {
            { "note_left", SKColor.Parse ("#FFC24B99") },
            { "note_down", SKColor.Parse ("#FF00FFFF") },
            { "note_up", SKColor.Parse ("#FF12FA05") },
            { "note_right", SKColor.Parse ("#FFF9393F") }
        };
        /* public Dictionary<string, string> ControlHexes {
            set {
                ControlColors.Clear ();
                foreach (KeyValuePair<string, string> entry in h) {
                    if (SKColor.TryParse (entry.Value, out SKColor color)) ControlColors.Add (entry.Key, color);
                    else ControlColors.Add (entry.Key, SKColor.Empty);
                }
            }
        } */

        public FnfControlsBrushProvider (IWebServerService webServerService) {
            this.webServerService = webServerService;
        }

        public override void Enable () {
            webServerService.AddJsonEndPoint<Dictionary<string, string[]>> (this, "SetControls", h => {
                Controls = h;
            });
            webServerService.AddJsonEndPoint<Dictionary<string, string>> (this, "SetControlColors", h => {
                ControlColors.Clear ();
                foreach (KeyValuePair<string, string> entry in h) {
                    if (SKColor.TryParse (entry.Value, out SKColor color)) ControlColors.Add (entry.Key, color);
                    else ControlColors.Add (entry.Key, SKColor.Empty);
                }
            });

            RegisterLayerBrushDescriptor<FnfControlsBrush> ("FNF Controls", "Displays the in-game controls for Friday Night Funkin', with pretty colors too.", "Controller");
        }

        public override void Disable () {

        }
    }
}
