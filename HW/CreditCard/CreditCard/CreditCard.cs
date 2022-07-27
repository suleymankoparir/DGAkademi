using System;
using System.Collections.Generic;
using System.IO;
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
        public string Number { get; set; }
        public string ExpireDate { get; set; }
        public string Ccv { get; set; }
        public string HolderName { get; set; }
        public CreditCard(string holderName, string number, string expireDate, string ccv)
        {
            this.holderName = holderName;
            Regex regex = new Regex("^[0-9]+$");
            if (number.Length != 16)
                throw new CreditCardException("Invalid Number length. Number must contain 16 digits");
            if (!regex.IsMatch(number))
                throw new CreditCardException("Invalid Number length. Number must contain digits");
            this.number = number;


            if (expireDate.Length != 5)
                throw new CreditCardException("Invalid ExpireDate format");
            if (expireDate[2] != '/')
                throw new CreditCardException("Invalid ExpireDate format");
            int month;
            int year;
            try
            {
                month = int.Parse(expireDate.Substring(0, 2));
                year = 2000 + int.Parse(expireDate.Substring(3, 2));
            }
            catch (Exception e)
            {
                throw new CreditCardException("Invalid ExpireDate format. " + e.ToString());
            }
            if (!(month >= 1 && month <= 12))
                throw new CreditCardException("Invalid month value. The Month value must be between 1 and 12");
            if (year > DateTime.Today.Year)
                this.expireDate = expireDate;
            else if (year == DateTime.Today.Year)
            {
                if (month >= DateTime.Today.Month)
                    this.expireDate = expireDate;
                else
                    throw new CreditCardException("Invalid month value. Since the year values are equal, the month value must be greater than or equal to " + DateTime.Today.Month);
            }
            else
                throw new CreditCardException("Invalid year value. Year value must be greater than or equal to " + DateTime.Today.Year);

            if (ccv.Length != 3 || !regex.IsMatch(ccv))
                throw new CreditCardException("Invalid Ccv format");
            this.ccv = ccv;
        }
        public string getInfo()
        {
            return "Number :"+number+" Holder : "+holderName+" Ccv : "+ccv+" Expire Date : "+expireDate;
        }
    }
}
