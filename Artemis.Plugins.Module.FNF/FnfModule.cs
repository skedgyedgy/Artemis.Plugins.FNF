using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.Module.FNF.DataModels;
using SkiaSharp;
using System.Collections.Generic;

namespace Artemis.Plugins.Module.FNF {
    [PluginFeature (Name = "Friday Night Funkin' Module", Icon = "Music")]
    public class FnfModule : Module<FnfDataModel> {
        private readonly IWebServerService webServerService;

        public override List<IModuleActivationRequirement> ActivationRequirements => null; // might add this, probably won't just to be on the safe side when it comes to mods

        public FnfModule (IWebServerService webServerService) {
            this.webServerService = webServerService;
        }

        public override void Enable () {
            webServerService.AddStringEndPoint (this, "SetHealth", h => {
                float val = DataModel.BoyfriendHealth;
                float.TryParse (h, out val);
                DataModel.BoyfriendHealth = val;
            });

            JsonPluginEndPoint<FnfSongData> songDataEndpoint = webServerService.AddJsonEndPoint<FnfSongData> (this, "SongData", d => DataModel.SongData = d);
            songDataEndpoint.RequestException += JsonPluginEndPointOnRequestException;
        }

        public override void Disable () {
        }

        public override void ModuleActivated (bool isOverride) {
        }

        public override void ModuleDeactivated (bool isOverride) {
        }

        public override void Update (double deltaTime) {
        }

        private void JsonPluginEndPointOnRequestException (object sender, EndpointExceptionEventArgs e) {
            throw e.Exception;
        }
    }
}