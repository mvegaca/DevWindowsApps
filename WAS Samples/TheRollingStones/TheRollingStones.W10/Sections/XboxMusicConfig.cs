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
    public class XboxMusicConfig : SectionConfigBase<DynamicStorageDataConfig, XboxMusic1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, XboxMusic1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<XboxMusic1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://appstudio-dev.cloudapp.net/api/data/collection?dataRowListId=cc719b56-3bf2-4770-aae0-e869d7644417&appId=2aacaf63-e88b-4e7e-91dd-5a035310ed22"),
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
                return NavigationInfo.FromPage("XboxMusicListPage");
            }
        }

        public override ListPageConfig<XboxMusic1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<XboxMusic1Schema>
                {
                    Title = "xbox music",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.ReleaseDate.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("XboxMusicDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<XboxMusic1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, XboxMusic1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Album";
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.LabelName.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "More Details";
                    viewModel.Title = item.Genre.ToSafeString();
                    viewModel.Description = item.ReleaseDate.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "Cover";
                    viewModel.Title = "";
                    viewModel.Description = item.Title.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<XboxMusic1Schema>>
				{
                    ActionConfig<XboxMusic1Schema>.Play("Play", (item) => item.Link.ToSafeString()),
				};

                return new DetailPageConfig<XboxMusic1Schema>
                {
                    Title = "xbox music",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

}
}
