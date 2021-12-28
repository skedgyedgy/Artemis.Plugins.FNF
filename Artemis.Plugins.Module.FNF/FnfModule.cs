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
            webServerService.AddStringEndPoint (this, "SetGameState", h => DataModel.GameState = h);
            webServerService.AddStringEndPoint (this, "SetStageName", h => DataModel.StageName = h);
            webServerService.AddStringEndPoint (this, "SetModName", h => DataModel.ModName = h);

            JsonPluginEndPoint<FnfSongData> songDataEndpoint = webServerService.AddJsonEndPoint<FnfSongData> (this, "SetSongData", d => DataModel.SongData = d);
            songDataEndpoint.RequestException += JsonPluginEndPointOnRequestException;
            webServerService.AddStringEndPoint (this, "SetBeat", h => {
                int val = DataModel.BeatNumber;
                int.TryParse (h, out val);
                DataModel.BeatNumber = val;
            });
            webServerService.AddStringEndPoint (this, "SetMeasure", h => {
                int val = DataModel.MeasuerNumber;
                int.TryParse (h, out val);
                DataModel.MeasuerNumber = val;
            });

            webServerService.AddStringEndPoint (this, "SetHealth", h => {
                float val = DataModel.BoyfriendHealth;
                float.TryParse (h, out val);
                DataModel.BoyfriendHealth = val;
            });
            webServerService.AddStringEndPoint (this, "SetCombo", h => {
                int val = DataModel.CurrentCombo;
                int.TryParse (h, out val);
                DataModel.CurrentCombo = val;
            });
            webServerService.AddStringEndPoint (this, "SetRating", h => {
                float val = DataModel.RatingPercentage;
                float.TryParse (h, out val);
                DataModel.RatingPercentage = val;
            });
            webServerService.AddStringEndPoint (this, "SetFullCombo", h => {
                bool val = DataModel.FullCombo;
                bool.TryParse (h, out val);
                DataModel.FullCombo = val;
            });

            webServerService.AddStringEndPoint (this, "SetBackgroundHex", h => {
                SKColor val = DataModel.BackgroundColor;
                SKColor.TryParse (h, out val);
                DataModel.BackgroundColor = val;
            });
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