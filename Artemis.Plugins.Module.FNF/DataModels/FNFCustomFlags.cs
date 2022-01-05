using Artemis.Core.Modules;

namespace Artemis.Plugins.Module.FNF.DataModels {
    public class FNFCustomFlags {
        [DataModelProperty (Name = "Custom flag 1")]
        public bool CustomFlag1 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 2")]
        public bool CustomFlag2 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 3")]
        public bool CustomFlag3 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 4")]
        public bool CustomFlag4 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 5")]
        public bool CustomFlag5 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 6")]
        public bool CustomFlag6 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 7")]
        public bool CustomFlag7 { get; set; } = false;
        [DataModelProperty (Name = "Custom flag 8")]
        public bool CustomFlag8 { get; set; } = false;

        [DataModelProperty (Name = "Custom string 1")]
        public string CustomString1 { get; set; }
        [DataModelProperty (Name = "Custom string 2")]
        public string CustomString2 { get; set; }
        [DataModelProperty (Name = "Custom string 3")]
        public string CustomString3 { get; set; }
        [DataModelProperty (Name = "Custom string 4")]
        public string CustomString4 { get; set; }
        [DataModelProperty (Name = "Custom string 5")]
        public string CustomString5 { get; set; }

        [DataModelProperty (Name = "Custom number 1")]
        public int CustomNumber1 { get; set; } = 0;
        [DataModelProperty (Name = "Custom number 2")]
        public int CustomNumber2 { get; set; } = 0;
        [DataModelProperty (Name = "Custom number 3")]
        public int CustomNumber3 { get; set; } = 0;
        [DataModelProperty (Name = "Custom number 4")]
        public int CustomNumber4 { get; set; } = 0;
        [DataModelProperty (Name = "Custom number 5")]
        public int CustomNumber5 { get; set; } = 0;
    }
}