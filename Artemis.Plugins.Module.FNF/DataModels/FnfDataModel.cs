using Artemis.Core.Modules;
using SkiaSharp;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FnfDataModel : DataModel {
        public FnfDataModel () {
            //PluginSubDataModel = new FnfSubDataModel ();
        }

        [DataModelProperty (Name = "Player health", Description = "How much health boyfriend has.")]
        public float BoyfriendHealth { get; set; }
        [DataModelProperty (Name = "Background color", Description = "The background color on main menus, also used for unconfigured songs.")]
        public SKColor BackgroundColor { get; set; } = SKColor.Empty;
        [DataModelProperty (Name = "Overlay color")]
        public SKColor OVerlayColor { get; set; } = SKColor.Empty;

        public FnfSongData SongData { get; set; }

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