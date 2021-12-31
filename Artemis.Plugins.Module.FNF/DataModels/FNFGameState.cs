using Artemis.Core;
using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FNFGameState {
        [DataModelProperty (Name = "Game state", Description = "The current state of the game: title, menu, in-game freeplay, in-game story, cutscene, dead, closed")]
        public string GameState { get; set; } = "closed";
        [DataModelProperty (Name = "In-game", Description = "Whether a game is currently active")]
        public bool InGame => GameState == "in-game story" || GameState == "in-game freeplay" || GameState == "dead";

        [DataModelProperty (Name = "Mod name", Description = "The name of the current mod")]
        public string ModName { get; set; } = "vanilla";

        public DataModelEvent OnSongStarted { get; } = new DataModelEvent ();
        // public DataModelEvent<SongStartedEventArguments> OnSongStarted { get; } = new DataModelEvent<SongStartedEventArguments> ();
        public DataModelEvent OnBlueBalled { get; } = new DataModelEvent ();
    }

    // yes there will be things here eventually
    /* public class SongStartedEventArguments : DataModelEventArgs {
        public SongStartedEventArguments () {

        }
    } */
}