using Artemis.Core;
using Artemis.Core.Services;
using Artemis.UI.Events;
using Stylet;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Artemis.Plugins.Module.FNF {
    [PluginFeature (Name = "FNF Profile Manager", Icon = "Music")]
    public class FnfProfileManagerModule : PluginFeature {
        private readonly IWebServerService webServerService;
        private readonly IProfileService profileService;
        private readonly IEventAggregator eventAggregator;

        private ProfileCategory fnfCategory;

        public FnfProfileManagerModule (IWebServerService webServerService, IProfileService profileService, IEventAggregator eventAggregator) {
            this.webServerService = webServerService;
            this.profileService = profileService;
            this.eventAggregator = eventAggregator;
        }

        public override void Enable () {
            if (profileService.ProfileCategories.Any (cat => cat.Name == "Friday Night Funkin'")) {
                fnfCategory = profileService.ProfileCategories.First (cat => cat.Name == "Friday Night Funkin'");
                // } else if (settings.GetSetting ("AllowAutomaticProfiles", true).Value) { TODO: add this eventually
            } else {
                fnfCategory = profileService.CreateProfileCategory ("Friday Night Funkin'");
                fnfCategory.Load ();
                fnfCategory.Order = -10;
            }

            webServerService.AddStringEndPoint (this, "SetProfile", h => {
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
            });
        }

        public override void Disable () {
        }

        private void JsonPluginEndPointOnRequestException (object sender, EndpointExceptionEventArgs e) {
            throw e.Exception;
        }
    }
}