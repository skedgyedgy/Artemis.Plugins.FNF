using Artemis.Core;
using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfDataModel : DataModel {
        public FnfDataModel () {
        }

        public FNFGameState GameState { get; set; } = new FNFGameState ();
        public FNFSongData SongData { get; set; } = new FNFSongData ();
        public FNFColors Colors { get; set; } = new FNFColors ();
        public FNFCustomFlags CustomFlags { get; set; } = new FNFCustomFlags ();
        public DataModelEvent<CustomEventArgs> CustomEvent { get; } = new DataModelEvent<CustomEventArgs> ();
    }

    public class CustomEventArgs : DataModelEventArgs {
        public string Name { get; set; }
        [DataModelIgnore]
        public string Hex {
            get => Color.ToString ();
            set {
                _ = SKColor.TryParse (value, out SKColor val);
                Color = val;
            }
        }
        public SKColor Color { get; set; }
        public int Num { get; set; }
    }
}