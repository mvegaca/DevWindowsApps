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
    public class BestAlbumsConfig : SectionConfigBase<DynamicStorageDataConfig, BestAlbums1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, BestAlbums1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<BestAlbums1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://appstudio-dev.cloudapp.net/api/data/collection?dataRowListId=d4490b6b-d3b7-4947-8074-6990764caa46&appId=2aacaf63-e88b-4e7e-91dd-5a035310ed22"),
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
                return NavigationInfo.FromPage("BestAlbumsListPage");
            }
        }

        public override ListPageConfig<BestAlbums1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<BestAlbums1Schema>
                {
                    Title = "best albums",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Year.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.Cover.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("BestAlbumsDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<BestAlbums1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, BestAlbums1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Year.ToSafeString();
                    viewModel.Title = item.Name.ToSafeString();
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.Image = item.Cover.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<BestAlbums1Schema>>
				{
				};

                return new DetailPageConfig<BestAlbums1Schema>
                {
                    Title = "best albums",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

}
}
