using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Common.Navigation;
using Windows.UI.Xaml;

namespace TheRollingStones.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();

            Nodes.Add(new ItemNavigationNode
            {
                Title = @"The Rolling Stones",
                Label = "Home",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "best albums",
                NavigationInfo = NavigationInfo.FromPage("BestAlbumsListPage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "news",
                NavigationInfo = NavigationInfo.FromPage("NewsListPage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "moments of Tour",
                NavigationInfo = NavigationInfo.FromPage("MomentsOfTourListPage")
            });

            Nodes.Add(new GroupNavigationNode
            {
                Label = "Rolling conected",
                Visibility = Visibility.Visible,
                Nodes = new ObservableCollection<NavigationNode>()
                {
                    new ItemNavigationNode
                    {
                        Label = "Twitter",
                        NavigationInfo = NavigationInfo.FromPage("TwitterListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Facebook",
                        NavigationInfo = NavigationInfo.FromPage("FacebookListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "YouTube",
                        NavigationInfo = NavigationInfo.FromPage("YouTubeListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Flickr",
                        NavigationInfo = NavigationInfo.FromPage("FlickrListPage")
                    },
                    new ItemNavigationNode
                    {
                        Label = "Instagram",
                        NavigationInfo = NavigationInfo.FromPage("InstagramListPage")
                    },
                }
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "xbox music",
                NavigationInfo = NavigationInfo.FromPage("XboxMusicListPage")
            });

            Nodes.Add(new GroupNavigationNode
            {
                Label = "tour plan",
                Visibility = Visibility.Visible,
                Nodes = new ObservableCollection<NavigationNode>()
                {
                    new ItemNavigationNode
                    {
                        Label = "Madrid 15.09.2015",
                        NavigationInfo = new NavigationInfo { NavigationType = NavigationType.DeepLink, TargetUri = new Uri("http://www.rollingstones.com") }
                    },
                    new ItemNavigationNode
                    {
                        Label = "Paris 18.11.2015",
                        NavigationInfo = new NavigationInfo { NavigationType = NavigationType.DeepLink, TargetUri = new Uri("http://www.rollingstones.com") }
                    },
                    new ItemNavigationNode
                    {
                        Label = "London 18.02.2016",
                        NavigationInfo = new NavigationInfo { NavigationType = NavigationType.DeepLink, TargetUri = new Uri("http://www.rollingstones.com") }
                    },
                    new ItemNavigationNode
                    {
                        Label = "Seatle 11.06.2016",
                        NavigationInfo = new NavigationInfo { NavigationType = NavigationType.DeepLink, TargetUri = new Uri("http://www.rollingstones.com") }
                    },
                }
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "About",
                NavigationInfo = NavigationInfo.FromPage("AboutPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Privacy terms",
                NavigationInfo = new NavigationInfo()
                {
                    NavigationType = NavigationType.DeepLink,
                    TargetUri = new Uri("http://appstudio.windows.com/home/appprivacyterms", UriKind.Absolute)
                }
            });
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
