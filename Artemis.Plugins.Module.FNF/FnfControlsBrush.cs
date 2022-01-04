using Artemis.Core;
using Artemis.Core.LayerBrushes;
using RGB.NET.Core;
using SkiaSharp;
using System.Linq;

namespace Artemis.Plugins.Module.FNF {
    using PropertyGroups;

    public class FnfControlsBrush : PerLedLayerBrush<FnfControlsPropertyGroup> {
        public override void EnableLayerBrush () {
        }

        public override void DisableLayerBrush () {
        }

        public override void Update (double deltaTime) {
        }

        public override SKColor GetColor (ArtemisLed led, SKPoint renderPoint) {
            if (led.Device.DeviceType != RGBDeviceType.Keyboard) return SKColor.Empty;

            string controlName;

            switch (led.RgbLed.Id) {
                case LedId.Keyboard_ArrowLeft:
                    controlName = "Left";
                    break;
                case LedId.Keyboard_ArrowDown:
                    controlName = "Down";
                    break;
                case LedId.Keyboard_ArrowUp:
                    controlName = "Up";
                    break;
                case LedId.Keyboard_ArrowRight:
                    controlName = "Right";
                    break;
                default:
                    controlName = led.RgbLed.Id.ToString ().Replace ("Keyboard_", "");
                    break;
            }

            if (FnfControlsBrushProvider.Controls.Any (p => p.Value.Contains (controlName))) {
                string controlType = FnfControlsBrushProvider.Controls.First (p => p.Value.Contains (controlName)).Key;
                if (FnfControlsBrushProvider.ControlColors.ContainsKey (controlType)) return FnfControlsBrushProvider.ControlColors[controlType];
            }

            return SKColor.Empty;
        }
    }
}