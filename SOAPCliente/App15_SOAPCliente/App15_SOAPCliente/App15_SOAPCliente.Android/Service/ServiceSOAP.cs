using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly:Xamarin.Forms.Dependency(typeof(App15_SOAPCliente.Droid.Service.ServiceSOAP))]
namespace App15_SOAPCliente.Droid.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public int Somar(int num1, int num2)
        {
            return new Calculator.Calculator().Add(num1, num2);
        }
    }
}