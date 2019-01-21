using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(App15_SOAPCliente.iOS.Service.ServiceSOAP))]
namespace App15_SOAPCliente.iOS.Service
{
    public class ServiceSOAP : IServiceSOAP
    {
        public int Somar(int num1, int num2)
        {
            return new Calculator.Calculator().Add(num1, num2);
        }
    }
}