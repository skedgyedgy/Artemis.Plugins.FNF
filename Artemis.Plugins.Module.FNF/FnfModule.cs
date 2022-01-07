using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.Module.FNF.DataModels;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace Artemis.Plugins.Module.FNF {
    [PluginFeature (Name = "FNF Module", Icon = "Music")]
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

            webServerService.AddStringEndPoint (this, "SetSongName", h => DataModel.SongData.SongName = h);
            webServerService.AddStringEndPoint (this, "SetDifficlutyName", h => DataModel.SongData.Difficulty = h);

            webServerService.AddStringEndPoint (this, "SetDadName", h => DataModel.SongData.DadName = h);
            webServerService.AddStringEndPoint (this, "SetBfName", h => DataModel.SongData.BfName = h);
            webServerService.AddStringEndPoint (this, "SetGfName", h => DataModel.SongData.GfName = h);

            webServerService.AddStringEndPoint (this, "SetStageName", h => DataModel.SongData.StageName = h);
            webServerService.AddStringEndPoint (this, "SetIsPixelStage", h => DataModel.SongData.IsPixelStage = bool.Parse (h));

            webServerService.AddStringEndPoint (this, "SetBeat", h => {
                int val = int.Parse (h);

                if (val > DataModel.SongData.BeatNumber) {
                    DataModel.SongData.OnBeat.Trigger ();
                    if (val % 4 == 0) DataModel.SongData.OnMeasure.Trigger ();
                }

                DataModel.SongData.BeatNumber = val;
            });
            webServerService.AddStringEndPoint (this, "SetSongProgress", h => DataModel.SongData.SongProgress = float.Parse (h));
            webServerService.AddStringEndPoint (this, "SetHealth", h => DataModel.SongData.BoyfriendHealth = float.Parse (h));
            webServerService.AddStringEndPoint (this, "SetRating", h => DataModel.SongData.RatingPercentage = float.Parse (h));
            webServerService.AddStringEndPoint (this, "SetCombo", h => DataModel.SongData.CurrentCombo = int.Parse (h));
            webServerService.AddStringEndPoint (this, "StartSong", h => {
                DataModel.SongData.ComboType = "SFC";
                DataModel.SongData.FullCombo = true;
                DataModel.SongData.CurrentCombo = 0;
                DataModel.GameState.OnSongStarted.Trigger ();
                // DataModel.GameState.OnSongStarted.Trigger (new SongStartedEventArguments ());
            });
            webServerService.AddJsonEndPoint<NoteHitEventArgs> (this, "NoteHit", h => DataModel.SongData.OnNoteHit.Trigger (h));
            webServerService.AddJsonEndPoint<NoteMissEventArgs> (this, "NoteMiss", h => DataModel.SongData.OnNoteMiss.Trigger (h));
            webServerService.AddStringEndPoint (this, "BreakCombo", h => {
                DataModel.SongData.OnComboBroken.Trigger (new ComboBreakEventArgs (DataModel.SongData.CurrentCombo, DataModel.SongData.FullCombo));
                if (DataModel.SongData.FullCombo) DataModel.SongData.ComboType = "SDCB";
                DataModel.SongData.FullCombo = false;
                DataModel.SongData.CurrentCombo = 0;
            });
            webServerService.AddStringEndPoint (this, "SetComboType", h => {
                DataModel.SongData.ComboType = h;
                // DataModel.SongData.ComboType = Enum.Parse<ComboType> (h);
            });

            webServerService.AddStringEndPoint (this, "SetDadHex", h => DataModel.Colors.DadHealthColor = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetBFHex", h => DataModel.Colors.BfHealthColor = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetBackgroundHex", h => DataModel.Colors.BackgroundColor = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetAccent1Hex", h => DataModel.Colors.AccentColor1 = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetAccent2Hex", h => DataModel.Colors.AccentColor2 = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetAccent3Hex", h => DataModel.Colors.AccentColor3 = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "SetAccent4Hex", h => DataModel.Colors.AccentColor4 = SKColor.Parse (h));
            webServerService.AddJsonEndPoint<FlashEventArgs> (this, "SetBlammedHex", h => DataModel.Colors.OnBlammedLights.Trigger (h));
            webServerService.AddJsonEndPoint<FlashEventArgs> (this, "TriggerFlash", h => DataModel.Colors.OnFlash.Trigger (h));
            webServerService.AddStringEndPoint (this, "SetFadeHex", h => DataModel.Colors.FadeColor = SKColor.Parse (h));
            webServerService.AddStringEndPoint (this, "ToggleFade", h => DataModel.Colors.Fade = bool.Parse (h));
            webServerService.AddJsonEndPoint<CustomEventArgs> (this, "TriggerCustomEvent", h => DataModel.CustomEvent.Trigger (h));
            webServerService.AddStringEndPoint (this, "ResetAllFlags", h => {
                DataModel.CustomFlags.CustomFlag1 = false;
                DataModel.CustomFlags.CustomFlag2 = false;
                DataModel.CustomFlags.CustomFlag3 = false;
                DataModel.CustomFlags.CustomFlag4 = false;
                DataModel.CustomFlags.CustomFlag5 = false;
                DataModel.CustomFlags.CustomFlag6 = false;
                DataModel.CustomFlags.CustomFlag7 = false;
                DataModel.CustomFlags.CustomFlag8 = false;

                DataModel.CustomFlags.CustomString1 = null;
                DataModel.CustomFlags.CustomString2 = null;
                DataModel.CustomFlags.CustomString3 = null;
                DataModel.CustomFlags.CustomString4 = null;
                DataModel.CustomFlags.CustomString5 = null;

                DataModel.CustomFlags.CustomNumber1 = 0;
                DataModel.CustomFlags.CustomNumber2 = 0;
                DataModel.CustomFlags.CustomNumber3 = 0;
                DataModel.CustomFlags.CustomNumber4 = 0;
                DataModel.CustomFlags.CustomNumber5 = 0;
            });
            webServerService.AddStringEndPoint (this, "EnableFlag", h => {
                switch (h) {
                    case "1":
                        DataModel.CustomFlags.CustomFlag1 = true;
                        break;
                    case "2":
                        DataModel.CustomFlags.CustomFlag2 = true;
                        break;
                    case "3":
                        DataModel.CustomFlags.CustomFlag3 = true;
                        break;
                    case "4":
                        DataModel.CustomFlags.CustomFlag4 = true;
                        break;
                    case "5":
                        DataModel.CustomFlags.CustomFlag5 = true;
                        break;
                    case "6":
                        DataModel.CustomFlags.CustomFlag6 = true;
                        break;
                    case "7":
                        DataModel.CustomFlags.CustomFlag7 = true;
                        break;
                    case "8":
                        DataModel.CustomFlags.CustomFlag8 = true;
                        break;
                    default:
                        throw new System.IndexOutOfRangeException ();
                }
            });
            webServerService.AddStringEndPoint (this, "DisableFlag", h => {
                switch (h) {
                    case "1":
                        DataModel.CustomFlags.CustomFlag1 = false;
                        break;
                    case "2":
                        DataModel.CustomFlags.CustomFlag2 = false;
                        break;
                    case "3":
                        DataModel.CustomFlags.CustomFlag3 = false;
                        break;
                    case "4":
                        DataModel.CustomFlags.CustomFlag4 = false;
                        break;
                    case "5":
                        DataModel.CustomFlags.CustomFlag5 = false;
                        break;
                    case "6":
                        DataModel.CustomFlags.CustomFlag6 = false;
                        break;
                    case "7":
                        DataModel.CustomFlags.CustomFlag7 = false;
                        break;
                    case "8":
                        DataModel.CustomFlags.CustomFlag8 = false;
                        break;
                    default:
                        throw new System.IndexOutOfRangeException ();
                }
            });
            webServerService.AddJsonEndPoint<CustomStringSetArgs> (this, "SetCustomString", h => {
                switch (h.Id) {
                    case 1:
                        DataModel.CustomFlags.CustomString1 = h.Value;
                        break;
                    case 2:
                        DataModel.CustomFlags.CustomString2 = h.Value;
                        break;
                    case 3:
                        DataModel.CustomFlags.CustomString3 = h.Value;
                        break;
                    case 4:
                        DataModel.CustomFlags.CustomString4 = h.Value;
                        break;
                    case 5:
                        DataModel.CustomFlags.CustomString5 = h.Value;
                        break;
                    default:
                        throw new System.IndexOutOfRangeException ();
                }
            });
            webServerService.AddJsonEndPoint<CustomNumberSetArgs> (this, "SetCustomNumber", h => {
                switch (h.Id) {
                    case 1:
                        DataModel.CustomFlags.CustomNumber1 = h.Value;
                        break;
                    case 2:
                        DataModel.CustomFlags.CustomNumber2 = h.Value;
                        break;
                    case 3:
                        DataModel.CustomFlags.CustomNumber3 = h.Value;
                        break;
                    case 4:
                        DataModel.CustomFlags.CustomNumber4 = h.Value;
                        break;
                    case 5:
                        DataModel.CustomFlags.CustomNumber5 = h.Value;
                        break;
                    default:
                        throw new System.IndexOutOfRangeException ();
                }
            });

            /* webServerService.AddStringEndPoint (this, "SetProfile", h => {
                // if (File.Exists (h)) AddDefaultProfile (DefaultCategoryName.Games, h);
                if (fnfCategory != null) {
                    if (File.Exists (h)) {
                        ProfileConfigurationExportModel exportModel = JsonConvert.DeserializeObject<ProfileConfigurationExportModel> (File.ReadAllText (h), IProfileService.ExportSettings);
                        if (exportModel != null) {
                            if (profileService.ProfileConfigurations.Any (p => p.Entity.ProfileId == exportModel.ProfileEntity.Id)) {
                                ProfileConfiguration oldConfig = fnfCategory.ProfileConfigurations.First (p => p.Entity.ProfileId == exportModel.ProfileEntity.Id);
                                if (oldConfig.IsBeingEdited) eventAggregator.Publish (new RequestSelectSidebarItemEvent ("Home"));

                                profileService.RemoveProfileConfiguration (oldConfig);
                            }
                            profileService.ImportProfile (fnfCategory, exportModel, false, true, "auto-added");
                        } else {
                            throw new System.Exception ();
                        }
                    } else {
                        throw new FileNotFoundException ();
                    }
                }
            });*/ // this was moved to its own feature

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

        private class CustomStringSetArgs {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private class CustomNumberSetArgs {
            public int Id { get; set; }
            public int Value { get; set; }
        }
    }
}