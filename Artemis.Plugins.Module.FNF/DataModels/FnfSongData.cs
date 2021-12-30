﻿using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfSongData {
        public SKColor DadHealthColor { get; set; } = new SKColor (0xB7, 0xD8, 0x55, 0xFF);
        [DataModelIgnore]
        public string DadHealthHex {
            get => DadHealthColor.ToString ();
            set {
                SKColor val = DadHealthColor;
                SKColor.TryParse (value, out val);
                DadHealthColor = val;
            }
        }

        public SKColor BfHealthColor { get; set; } = new SKColor (0x31, 0xB0, 0xD1, 0xFF);
        [DataModelIgnore]
        public string BfHealthHex {
            get => BfHealthColor.ToString ();
            set {
                SKColor val = BfHealthColor;
                SKColor.TryParse (value, out val);
                BfHealthColor = val;
            }
        }

        public SKColor LeftNoteColor { get; set; } = new SKColor (0xC2, 0x4B, 0x99, 0xFF);
        [DataModelIgnore]
        public string LeftNoteHex {
            get => LeftNoteColor.ToString ();
            set {
                SKColor val = LeftNoteColor;
                SKColor.TryParse (value, out val);
                LeftNoteColor = val;
            }
        }
        public SKColor DownNoteColor { get; set; } = new SKColor (0x00, 0xFF, 0xFF, 0xFF);
        [DataModelIgnore]
        public string NoteHex {
            get => DownNoteColor.ToString ();
            set {
                SKColor val = DownNoteColor;
                SKColor.TryParse (value, out val);
                DownNoteColor = val;
            }
        }
        public SKColor UpNoteColor { get; set; } = new SKColor (0x12, 0xFA, 0x05, 0xFF);
        [DataModelIgnore]
        public string UpNoteHex {
            get => UpNoteColor.ToString ();
            set {
                SKColor val = UpNoteColor;
                SKColor.TryParse (value, out val);
                UpNoteColor = val;
            }
        }
        public SKColor RightNoteColor { get; set; } = new SKColor (0xF9, 0x39, 0x3F, 0xFF);
        [DataModelIgnore]
        public string RightNoteHex {
            get => RightNoteColor.ToString ();
            set {
                SKColor val = RightNoteColor;
                SKColor.TryParse (value, out val);
                RightNoteColor = val;
            }
        }
    }
}