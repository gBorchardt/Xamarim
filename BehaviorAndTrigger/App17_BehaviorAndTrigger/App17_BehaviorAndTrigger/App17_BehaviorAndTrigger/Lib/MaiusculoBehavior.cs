using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App17_BehaviorAndTrigger.Lib
{
    public class MaiusculoBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += MaiusculoAction;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= MaiusculoAction;
        }

        private void MaiusculoAction(object sender, TextChangedEventArgs args)
        {
            if(!string.IsNullOrEmpty(args.NewTextValue))
                ((Entry)sender).Text = args.NewTextValue.ToUpper();
        }
    }
}
