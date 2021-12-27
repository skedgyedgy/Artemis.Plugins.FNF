using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfSongData {
        public SKColor DadHealthHex { get; set; } = new SKColor (0xB7, 0xD8, 0x55, 0xFF);
        public SKColor BfHealthHex { get; set; } = new SKColor (0x31, 0xB0, 0xD1, 0xFF);
        public SKColor LeftNoteHex { get; set; } = new SKColor (0xC2, 0x4B, 0x99, 0xFF);
        public SKColor DownNoteHex { get; set; } = new SKColor (0x00, 0xFF, 0xFF, 0xFF);
        public SKColor UpNoteHex { get; set; } = new SKColor (0x12, 0xFA, 0x05, 0xFF);
        public SKColor RightNoteHex { get; set; } = new SKColor (0xF9, 0x39, 0x3F, 0xFF);
    }
}