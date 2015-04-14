using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace TestApp01.Attribute.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (value == null)
            {
                return true;
            }
            var source = value as string;
            if (string.IsNullOrWhiteSpace(source))
            {
                return true;
            }
            try
            {
                var address = new MailAddress(source);
                return address.Address == source;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}