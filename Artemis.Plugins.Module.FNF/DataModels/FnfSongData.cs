using Artemis.Core;
using Artemis.Core.Modules;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FNFSongData {
        [DataModelProperty (Name = "Song name", Description = "The name of the currently playing song")]
        public string SongName { get; set; } = "fresh";
        [DataModelProperty (Name = "Difficulty name", Description = "The currently selected difficulty")]
        public string Difficulty { get; set; } = "normal";

        [DataModelProperty (Name = "Opponent name", Description = "The name of the current opponent character")]
        public string DadName { get; set; } = "dad";
        [DataModelProperty (Name = "Boyfriend name", Description = "The name of the current player character")]
        public string BfName { get; set; } = "bf";
        [DataModelProperty (Name = "Girlfriend name", Description = "The name of the current girlfriend character")]
        public string GfName { get; set; } = "gf";

        [DataModelProperty (Name = "Stage name", Description = "The name of the current song's stage")]
        public string StageName { get; set; } = "stage";
        [DataModelProperty (Name = "Is pixel stage", Description = "Whether the stage is a pixel stage or not")]
        public bool IsPixelStage { get; set; } = false;

        [DataModelProperty (Name = "Beat number", Description = "The current beat of the song")]
        public int BeatNumber { get; set; } = 0;
        [DataModelProperty (Name = "Measure number", Description = "The current measure of the song (assuming it is 4/4 time)")]
        public int MeasureNumber => BeatNumber / 4;
        [DataModelProperty (Name = "Song progress", Description = "The percentage of the song that has passed")]
        public float SongProgress { get; set; } = 0;

        [DataModelProperty (Name = "Player health", Description = "How much health boyfriend has")]
        public float BoyfriendHealth { get; set; } = 1;
        [DataModelProperty (Name = "Current combo", Description = "How big your current combo is")]
        public int CurrentCombo { get; set; } = 0;
        [DataModelProperty (Name = "Rating", Description = "Your rating percentage")]
        public float RatingPercentage { get; set; } = 75;
        [DataModelProperty (Name = "Combo type", Description = "The type of combo you're currently in")]
        public string ComboType { get; set; } = "Clear";
        [DataModelProperty (Name = "Full combo", Description = "Whether you are currently in a full combo")]
        public bool FullCombo { get; set; } = false;
        // public bool FullCombo { get => ComboType == "FC" || ComboType == "GFC" || ComboType == "SFC" || ComboType == "MFC"; }
        // public bool FullCombo { get => ComboType == ComboType.FullCombo || ComboType == ComboType.GoodFullCombo || ComboType == ComboType.MasterFullCombo; }

        [DataModelProperty (Name = "On beat", Description = "Called every beat")]
        public DataModelEvent OnBeat { get; } = new DataModelEvent ();
        [DataModelProperty (Name = "On measure", Description = "Called every measure")]
        public DataModelEvent OnMeasure { get; } = new DataModelEvent ();

        [DataModelProperty (Name = "On note hit", Description = "Called when a note is hit")]
        public DataModelEvent<NoteHitEventArgs> OnNoteHit { get; } = new DataModelEvent<NoteHitEventArgs> ();
        [DataModelProperty (Name = "On note miss", Description = "Called when a note is missed")]
        public DataModelEvent<NoteMissEventArgs> OnNoteMiss { get; } = new DataModelEvent<NoteMissEventArgs> ();
        [DataModelProperty (Name = "On combo broken", Description = "Called when a combo is broken")]
        public DataModelEvent<ComboBreakEventArgs> OnComboBroken { get; } = new DataModelEvent<ComboBreakEventArgs> ();
    }

    public class NoteHitEventArgs : DataModelEventArgs {
        public int NoteDirection { get; set; }
        public string NoteType { get; set; }
        public string NoteHitAccuracy { get; set; }

        public NoteHitEventArgs (int noteDirection, string noteType, string noteHitAccuracy) {
            NoteDirection = noteDirection;
            NoteType = noteType;
            NoteHitAccuracy = noteHitAccuracy;
        }
    }

    public class NoteMissEventArgs : DataModelEventArgs {
        public int NoteDirection { get; set; }
        public string NoteType { get; set; }

        public NoteMissEventArgs (int noteDirection, string noteType) {
            NoteDirection = noteDirection;
            NoteType = noteType;
        }
    }

    public class ComboBreakEventArgs : DataModelEventArgs {
        public int BrokenComboValue { get; set; }
        public bool WasFullCombo { get; set; }

        public ComboBreakEventArgs (int brokenComboValue, bool wasFullCombo) {
            BrokenComboValue = brokenComboValue;
            WasFullCombo = wasFullCombo;
        }
    }

    /*public enum NoteHitAccuracy {
        Sick,
        Good,
        Bad,
        Shit
    }*/

    /*public enum ComboType {
        MasterFullCombo,
        GoodFullCombo,
        FullCombo,
        SingleDigitComboBreak,
        Clear
    }*/
}
