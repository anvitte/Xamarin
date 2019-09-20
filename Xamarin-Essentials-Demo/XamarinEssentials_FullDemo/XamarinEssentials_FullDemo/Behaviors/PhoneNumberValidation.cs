using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace XamarinEssentials_FullDemo.Behaviors
{
    public class PhoneNumberValidation : Behavior<Entry>
    {
        private static string[] m_Patterns = new string[] {
                                                             @"^[0-9]{10}$",
                                                             @"^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$",
                                                             @"^[0-9]{3}-[0-9]{4}-[0-9]{4}$",
                                                          };

        private static string MakeCombinedPattern()
        {
            return string.Join("|", m_Patterns
              .Select(item => "(" + item + ")"));
        }
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            bool iSValid = false;
            if (e.NewTextValue==null)
            {
               
                iSValid = Regex.IsMatch(e.OldTextValue, MakeCombinedPattern());
               
            }
            else
            {
                iSValid = Regex.IsMatch(e.NewTextValue, MakeCombinedPattern());
            }
           ((Entry)sender).TextColor = iSValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);
            entry.TextChanged -= OnTextChanged;
        }
    }
}
