using App07_Cell.Pagina;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App07_Cell.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}

        private void GoTextCellPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TextCellPage());
            IsPresented = false;
        }

        private void GoImageCellPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ImageCellPage());
            IsPresented = false;
        }

        private void GoEntryCellPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new EntryCellPage());
            IsPresented = false;
        }

        private void GoSwitchCellPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SwitchCellPage());
            IsPresented = false;
        }

        private void GoViewCellPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ViewCellPage());
            IsPresented = false;
        }

        private void GoListViewPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListViewPage());
            IsPresented = false;
        }

        private void GoListViewButtonPage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListViewButtonPage());
            IsPresented = false;
        }
    }
}