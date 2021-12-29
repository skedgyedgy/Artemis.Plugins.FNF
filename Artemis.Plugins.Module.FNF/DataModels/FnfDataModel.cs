using Artemis.Core;
using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfDataModel : DataModel {
        public FnfDataModel () {
            //PluginSubDataModel = new FnfSubDataModel ();
        }

        [DataModelProperty (Name = "Game state", Description = "The current state of the game: title, menu, in-game freeplay, in-game story, cutscene, dead")]
        public string GameState { get; set; } = "title";
        [DataModelProperty (Name = "In-game", Description = "Whether a game is currently active.")]
        public bool InGame => GameState == "in-game story" || GameState == "in-game freeplay";

        [DataModelProperty (Name = "Mod name", Description = "The name of the current mod")]
        public string ModName { get; set; } = "vanilla";
        [DataModelProperty (Name = "Stage name", Description = "The name of the current song's stage")]
        public string StageName { get; set; } = "stage";

        public FnfSongData SongData { get; set; }
        [DataModelProperty (Name = "Beat number", Description = "The current beat of the song.")]
        public int BeatNumber { get; set; }
        [DataModelProperty (Name = "Measure number", Description = "The current measure of the song.")]
        public int MeasureNumber { get; set; }

        [DataModelProperty (Name = "Player health", Description = "How much health boyfriend has.")]
        public float BoyfriendHealth { get; set; }
        [DataModelProperty (Name = "Current combo", Description = "How big your current combo is.")]
        public int CurrentCombo { get; set; }
        [DataModelProperty (Name = "Rating", Description = "Your rating percentage")]
        public float RatingPercentage { get; set; }
        [DataModelProperty (Name = "Full combo", Description = "Whether you are currently in a full combo")]
        public bool FullCombo { get; set; }

        [DataModelProperty (Name = "Background color", Description = "The background color on main menus, also used for unconfigured songs.")]
        public SKColor BackgroundColor { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Accent color 1 ")]
        public SKColor AccentColor1 { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Accent color 2")]
        public SKColor AccentColor2 { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Blammed lights", Description = "The color fade during Blammed and all other stages that use it.")]
        public SKColor BlammedLights { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Flash color")]
        public SKColor FlashColor { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Fade to black")]
        public bool FadeToBlack { get; set; } = false;

        [DataModelProperty (Name = "On beat")]
        public DataModelEvent OnBeat { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On measure")]
        public DataModelEvent OnMeasure { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On blammed light")]
        public DataModelEvent OnBlammedLights { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On flash")]
        public DataModelEvent OnFlash { get; } = new DataModelEvent ();

        /*
        // You can even have classes in your datamodel, just don't forget to instantiate them ;)
        [DataModelProperty (Name = "A class within the datamodel")]
        public FnfSubDataModel PluginSubDataModel { get; set; }*/
    }

    /*public class FnfSubDataModel {
        public FnfSubDataModel () {
            ListOfInts = new List<int> { 1, 2, 3, 4, 5 };
        }

        // You don't need to annotate properties, they will still show up 
        public float FloatyFloat { get; set; }

        // You can even have a list!
        public List<int> ListOfInts { get; set; }

        // If you don't want a property to show up in the datamodel, annotate it with DataModelIgnore
        [DataModelIgnore]
        public string MyDarkestSecret { get; set; }
    }*/
}