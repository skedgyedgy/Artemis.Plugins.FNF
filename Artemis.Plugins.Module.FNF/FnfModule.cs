using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Plugins.Module.FNF.DataModels;
using SkiaSharp;
using System.Collections.Generic;

namespace Artemis.Plugins.Module.FNF {
    [PluginFeature (Name = "Friday Night Funkin' Module", Icon = "Music")]
    public class FnfModule : Module<FnfDataModel> {
        public override List<IModuleActivationRequirement> ActivationRequirements => null; // might add this, probably won't just to be on the safe side when it comes to mods

        public override void Enable () {
        }

        public override void Disable () {
        }

        public override void ModuleActivated (bool isOverride) {
        }

        public override void ModuleDeactivated (bool isOverride) {
        }

        public override void Update (double deltaTime) {
        }
    }
}