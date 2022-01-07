using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FNFSongData {
        [DataModelProperty (Name = "Stage name", Description = "The name of the current song's stage")]
        public string StageName { get; set; } = "stage";
        [DataModelProperty (Name = "Is pixel stage", Description = "Whether the stage is a pixel stage or not")]
        public bool IsPixelStage { get; set; } = false;

        [DataModelProperty (Name = "Beat number", Description = "The current beat of the song.")]
        public int BeatNumber { get; set; }
        [DataModelProperty (Name = "Measure number", Description = "The current measure of the song (assuming it is 4/4 time).")]
        public int MeasureNumber => BeatNumber / 4;

        [DataModelProperty (Name = "Player health", Description = "How much health boyfriend has")]
        public float BoyfriendHealth { get; set; }
        [DataModelProperty (Name = "Current combo", Description = "How big your current combo is")]
        public int CurrentCombo { get; set; }
        [DataModelProperty (Name = "Rating", Description = "Your rating percentage")]
        public float RatingPercentage { get; set; }
        [DataModelProperty (Name = "Full combo", Description = "Whether you are currently in a full combo")]
        public bool FullCombo { get; set; }


        [DataModelProperty (Name = "On beat")]
        public DataModelEvent OnBeat { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On measure")]
        public DataModelEvent OnMeasure { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On combo broken")]
        public DataModelEvent<ComboBreakEventArgs> OnComboBroken { get; } = new DataModelEvent<ComboBreakEventArgs> ();
    }

    public class ComboBreakEventArgs : DataModelEventArgs {
        public int BrokenComboValue { get; set; }
        public bool WasFullCombo { get; set; }

        public ComboBreakEventArgs (int brokenComboValue, bool wasFullCombo) {
            BrokenComboValue = brokenComboValue;
            WasFullCombo = wasFullCombo;
        }
    }
}
