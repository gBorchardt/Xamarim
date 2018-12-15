using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerPage : ContentPage
	{
		public PickerPage ()
		{
			InitializeComponent ();
		}

        private void ActionMudarIndex(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            Resultado.Text = picker.SelectedItem.ToString() + " - " + picker.SelectedIndex.ToString();
        }
    }
}