using System;
using System.Collections.Generic;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using Windows.Storage;
using TheRollingStones.Config;
using TheRollingStones.ViewModels;

namespace TheRollingStones.Sections
{
    public class MomentsOfTourConfig : SectionConfigBase<DynamicStorageDataConfig, MomentsOfTour1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, MomentsOfTour1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<MomentsOfTour1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://appstudio-dev.cloudapp.net/api/data/collection?dataRowListId=702843c5-bf98-4ca7-8c4d-369a5b7fe2a4&appId=2aacaf63-e88b-4e7e-91dd-5a035310ed22"),
                    AppId = "2aacaf63-e88b-4e7e-91dd-5a035310ed22",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("MomentsOfTourListPage");
            }
        }

        public override ListPageConfig<MomentsOfTour1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<MomentsOfTour1Schema>
                {
                    Title = "tour moments",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = "";
                        viewModel.SubTitle = "";
                        viewModel.Description = "";
                        viewModel.Image = item.Image.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("MomentsOfTourDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<MomentsOfTour1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, MomentsOfTour1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Moments of Tour";
                    viewModel.Title = "";
                    viewModel.Description = "";
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<MomentsOfTour1Schema>>
				{
				};

                return new DetailPageConfig<MomentsOfTour1Schema>
                {
                    Title = "moments of Tour",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

}
}
