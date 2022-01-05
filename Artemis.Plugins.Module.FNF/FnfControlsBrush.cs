using Artemis.Core;
using Artemis.Core.LayerBrushes;
using RGB.NET.Core;
using SkiaSharp;
using System.Linq;

namespace Artemis.Plugins.Module.FNF {
    public class FnfControlsBrush : PerLedLayerBrush<FnfControlsPropertyGroup> {
        public override void EnableLayerBrush () {
        }

        public override void DisableLayerBrush () {
        }

        public override void Update (double deltaTime) {
        }

        public override SKColor GetColor (ArtemisLed led, SKPoint renderPoint) {
            if (led.Device.DeviceType != RGBDeviceType.Keyboard) return SKColor.Empty;

            string controlName = led.RgbLed.Id switch {
                LedId.Keyboard_ArrowLeft => "Left",
                LedId.Keyboard_ArrowDown => "Down",
                LedId.Keyboard_ArrowUp => "Up",
                LedId.Keyboard_ArrowRight => "Right",
                _ => led.RgbLed.Id.ToString ().Replace ("Keyboard_", ""),
            };

            if (FnfControlsBrushProvider.Controls.Any (p => p.Value.Contains (controlName))) {
                string controlType = FnfControlsBrushProvider.Controls.First (p => p.Value.Contains (controlName)).Key;
                if (FnfControlsBrushProvider.ControlColors.ContainsKey (controlType)) return FnfControlsBrushProvider.ControlColors[controlType];
            }

            return SKColor.Empty;
        }
    }

    public class FnfControlsPropertyGroup : LayerPropertyGroup {
        protected override void PopulateDefaults () {
        }

        protected override void EnableProperties () {
        }

        protected override void DisableProperties () {
        }
    }
}