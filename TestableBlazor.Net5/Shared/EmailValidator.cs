using System;
using System.Collections.Generic;
using System.Text;

namespace TestableBlazor.Net5.Shared
{
    public class EmailValidator
    {
        public bool Validate(string value)
        {
			if (value == null)
			{
				return true;
			}

			if (!(value is string valueAsString))
			{
				return false;
			}

			// only return true if there is only 1 '@' character
			// and it is neither the first nor the last character
			int index = valueAsString.IndexOf('@');

			return
				index > 0 &&
				index != valueAsString.Length - 1 &&
				index == valueAsString.LastIndexOf('@');
		}
	
    }
}
