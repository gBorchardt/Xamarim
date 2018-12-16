using App07_Cell.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}