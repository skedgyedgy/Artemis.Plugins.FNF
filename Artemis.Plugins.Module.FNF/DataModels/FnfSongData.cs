using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfSongData {
        public SKColor BoyfriendHealthColor { get; set; } = new SKColor (0x31, 0xB0, 0xD1, 0xFF);
        public SKColor EnemyHealthColor { get; set; } = new SKColor (0xB7, 0xD8, 0x55, 0xFF);
        public SKColor LeftNoteColor { get; set; } = new SKColor (0xC2, 0x4B, 0x99, 0xFF);
        public SKColor DownNoteColor { get; set; } = new SKColor (0x00, 0xFF, 0xFF, 0xFF);
        public SKColor UpNoteColor { get; set; } = new SKColor (0x12, 0xFA, 0x05, 0xFF);
        public SKColor RightNoteColor { get; set; } = new SKColor (0xF9, 0x39, 0x3F, 0xFF);
    }
}