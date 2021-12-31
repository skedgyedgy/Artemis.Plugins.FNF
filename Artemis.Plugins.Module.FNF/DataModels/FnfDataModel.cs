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
    }
}