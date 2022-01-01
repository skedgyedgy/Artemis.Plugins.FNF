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
            webServerService.AddStringEndPoint (this, "SetGameState", h => {
                DataModel.GameState.GameState = h;
                if (h == "dead") DataModel.GameState.OnBlueBalled.Trigger ();
            });
            webServerService.AddStringEndPoint (this, "SetModName", h => DataModel.GameState.ModName = h);

            webServerService.AddStringEndPoint (this, "SetStageName", h => DataModel.SongData.StageName = h);
            webServerService.AddStringEndPoint (this, "SetIsPixelStage", h => {
                bool val = DataModel.SongData.IsPixelStage;
                bool.TryParse (h, out val);
                DataModel.SongData.IsPixelStage = val;
            });

            webServerService.AddStringEndPoint (this, "SetBeat", h => {
                int val = DataModel.SongData.BeatNumber;
                int.TryParse (h, out val);

                if (val > DataModel.SongData.BeatNumber) {
                    DataModel.SongData.OnBeat.Trigger ();
                    if (val % 4 == 0) DataModel.SongData.OnMeasure.Trigger ();
                }

                DataModel.SongData.BeatNumber = val;
            });
            webServerService.AddStringEndPoint (this, "SetHealth", h => {
                float val = DataModel.SongData.BoyfriendHealth;
                float.TryParse (h, out val);
                DataModel.SongData.BoyfriendHealth = val;
            });
            webServerService.AddStringEndPoint (this, "SetRating", h => {
                float val = DataModel.SongData.RatingPercentage;
                float.TryParse (h, out val);
                DataModel.SongData.RatingPercentage = val;
            });
            webServerService.AddStringEndPoint (this, "SetCombo", h => {
                int val = DataModel.SongData.CurrentCombo;
                int.TryParse (h, out val);
                DataModel.SongData.CurrentCombo = val;
            });
            webServerService.AddStringEndPoint (this, "StartSong", h => {
                DataModel.SongData.FullCombo = true;
                DataModel.SongData.CurrentCombo = 0;
                DataModel.GameState.OnSongStarted.Trigger ();
                // DataModel.GameState.OnSongStarted.Trigger (new SongStartedEventArguments ());
            });
            webServerService.AddStringEndPoint (this, "BreakCombo", h => {
                DataModel.SongData.OnComboBroken.Trigger (new ComboBreakEventArgs (DataModel.SongData.CurrentCombo, DataModel.SongData.FullCombo));
                DataModel.SongData.FullCombo = false;
                DataModel.SongData.CurrentCombo = 0;
            });

            webServerService.AddStringEndPoint (this, "SetDadHex", h => {
                SKColor val = DataModel.Colors.DadHealthColor;
                SKColor.TryParse (h, out val);
                DataModel.Colors.DadHealthColor = val;
            });
            webServerService.AddStringEndPoint (this, "SetBFHex", h => {
                SKColor val = DataModel.Colors.BfHealthColor;
                SKColor.TryParse (h, out val);
                DataModel.Colors.BfHealthColor = val;
            });
            webServerService.AddStringEndPoint (this, "SetBackgroundHex", h => {
                SKColor val = DataModel.Colors.BackgroundColor;
                SKColor.TryParse (h, out val);
                DataModel.Colors.BackgroundColor = val;
            });
            webServerService.AddStringEndPoint (this, "SetAccent1Hex", h => {
                SKColor val = DataModel.Colors.AccentColor1;
                SKColor.TryParse (h, out val);
                DataModel.Colors.AccentColor1 = val;
            });
            webServerService.AddStringEndPoint (this, "SetAccent2Hex", h => {
                SKColor val = DataModel.Colors.AccentColor2;
                SKColor.TryParse (h, out val);
                DataModel.Colors.AccentColor2 = val;
            });
            webServerService.AddStringEndPoint (this, "SetAccent3Hex", h => {
                SKColor val = DataModel.Colors.AccentColor3;
                SKColor.TryParse (h, out val);
                DataModel.Colors.AccentColor3 = val;
            });
            webServerService.AddStringEndPoint (this, "SetAccent4Hex", h => {
                SKColor val = DataModel.Colors.AccentColor4;
                SKColor.TryParse (h, out val);
                DataModel.Colors.AccentColor4 = val;
            });
            webServerService.AddJsonEndPoint<FlashEventArgs> (this, "SetBlammedHex", h => DataModel.Colors.OnBlammedLights.Trigger (h));
            webServerService.AddJsonEndPoint<FlashEventArgs> (this, "TriggerFlash", h => DataModel.Colors.OnFlash.Trigger (h));
            webServerService.AddStringEndPoint (this, "SetFadeHex", h => {
                SKColor val = DataModel.Colors.FadeColor;
                SKColor.TryParse (h, out val);
                DataModel.Colors.FadeColor = val;
            });
            webServerService.AddStringEndPoint (this, "ToggleFade", h => {
                bool val = DataModel.Colors.Fade;
                bool.TryParse (h, out val);
                DataModel.Colors.Fade = val;
            });
            webServerService.AddJsonEndPoint<CustomEventArgs> (this, "TriggerCustomEvent", h => DataModel.CustomEvent.Trigger (h));

            /* webServerService.AddStringEndPoint (this, "FlashColorHex", h => {
             *    SKColor val = DataModel.Colors.FlashColor;
             *    SKColor.TryParse (h, out val);
             *    DataModel.Colors.FlashColor = val;
             *    DataModel.Colors.OnFlash.Trigger ();
             *}); // keeping this just in case but using events for flashes is a better idea
             */
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