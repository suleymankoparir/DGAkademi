using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCard
{
    internal class CreditCard
    {
        private string holderName;
        private string number;
        private string expireDate;
        private string ccv;
        public string HolderName {
            get
            {
                return holderName;
            }
            set
            {
                holderName = value;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                Regex regex = new Regex("^[0-9]+$");
                if (value.Length != 16)
                    throw new CreditCardException("Invalid Number length. Number must contain 16 digits");
                if(!regex.IsMatch(value))
                    throw new CreditCardException("Invalid Number length. Number must contain digits");
                number = value;
            }
        }
        public string ExpireDate
        {
            get
            {
                return expireDate;
            }
            set
            {
                if(value.Length!=5)
                    throw new CreditCardException("Invalid ExpireDate format");
                if (value[2]!='/')
                    throw new CreditCardException("Invalid ExpireDate format");
                int month;
                int year;
                try
                {
                   month =int.Parse(value.Substring(0, 2));
                   year = 2000+int.Parse(value.Substring(3, 2));
                }
                catch (Exception e)
                {
                    throw new CreditCardException("Invalid ExpireDate format. "+e.ToString());
                }
                if(!(month>=1&&month<=12))
                    throw new CreditCardException("Invalid month value. The Month value must be between 1 and 12");
                if (year > DateTime.Today.Year)
                    expireDate = value;
                else if(year == DateTime.Today.Year)
                {
                    if(month>=DateTime.Today.Month)
                        expireDate = value;
                    else
                        throw new CreditCardException("Invalid month value. Since the year values are equal, the month value must be greater than or equal to "+DateTime.Today.Month);
                }
                else
                    throw new CreditCardException("Invalid year value. Year value must be greater than or equal to "+DateTime.Today.Year);
            }
        }
        public string Ccv
        {
            get
            {
                return ccv;
            }
            set
            {
                Regex regex = new Regex("^[0-9]+$");
                if (value.Length != 3 || !regex.IsMatch(value))
                    throw new CreditCardException("Invalid Ccv format");
                ccv = value;
            }
        }

        public string ToString()
        {
            return "Number :"+number+" Holder : "+holderName+" Ccv : "+ccv+" Expire Date : "+expireDate;
        }
    }
}
