using Artemis.Core;
using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FNFColors {
        public SKColor DadHealthColor { get; set; } = new SKColor (0xB7, 0xD8, 0x55, 0xFF);
        public SKColor BfHealthColor { get; set; } = new SKColor (0x31, 0xB0, 0xD1, 0xFF);

        [DataModelProperty(Name = "Background color", Description = "The background color on main menus, also used for unconfigured songs.")]
        public SKColor BackgroundColor { get; set; } = SKColor.Empty;
        public SKColor AccentColor1 { get; set; } = SKColor.Empty;
        public SKColor AccentColor2 { get; set; } = SKColor.Empty;
        public SKColor AccentColor3 { get; set; } = SKColor.Empty;
        public SKColor AccentColor4 { get; set; } = SKColor.Empty;
        // [DataModelProperty(Name = "Blammed lights", Description = "The color fade during Blammed and all other stages that use it.")]
        // public SKColor BlammedLights { get; set; } = SKColor.Empty;
        // public SKColor FlashColor { get; set; } = SKColor.Empty;
        public SKColor FadeColor { get; set; } = new SKColor (0x00, 0x00, 0x00, 0xFF);
        public bool Fade { get; set; } = false;

        public DataModelEvent<FlashEventArgs> OnBlammedLights { get; } = new DataModelEvent<FlashEventArgs> ();
        public DataModelEvent<FlashEventArgs> OnFlash { get; } = new DataModelEvent<FlashEventArgs> ();
    }

    public class FlashEventArgs : DataModelEventArgs {
        public float FadeTime { get; set; } // can't do anything with this until artemis implements a way to control animation speed *shrug*
        [DataModelIgnore]
        public string FlashHex {
            get => FlashColor.ToString ();
            set {
                _ = SKColor.TryParse (value, out SKColor val);
                FlashColor = val;
            }
        }
        public SKColor FlashColor { get; set; }
    }
}