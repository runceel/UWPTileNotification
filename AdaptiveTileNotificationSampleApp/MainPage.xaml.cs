using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace AdaptiveTileNotificationSampleApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var bindingContent = new TileBindingContentAdaptive
            {
                PeekImage = new TilePeekImage
                {
                    Source = new TileImageSource("Assets/Square150x150Logo.png")
                },
                Children =
                {
                    new TileText { Text = "Hello world", Style = TileTextStyle.Title },
                    new TileText { Text = "okazuki", Style = TileTextStyle.Body },
                }
            };

            var tileBinding = new TileBinding
            {
                Branding = TileBranding.NameAndLogo,
                Content = bindingContent,
                DisplayName = "Hello display name",
            };

            var content = new TileContent
            {
                Visual = new TileVisual
                {
                    TileSmall = tileBinding,
                    TileMedium = tileBinding,
                    TileLarge = tileBinding,
                    TileWide = tileBinding,
                }
            };

            var n = new TileNotification(content.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication()
                .Update(n);
        }
    }
}
