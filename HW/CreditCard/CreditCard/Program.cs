using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();

            creditCard.Number = "1234567812345678";
            //creditCard.Number = "12345678123456781";  //throws exception
            //creditCard.Number = "AVC456781234567A";   //throws exception

            creditCard.ExpireDate = "12/24";
            //creditCard.ExpireDate = "12/123";     //throws exception
            //creditCard.ExpireDate = "12,24";      //throws exception
            //creditCard.ExpireDate = "ab/cd";      //throws exception
            //creditCard.ExpireDate = "12/20";      //throws exception
            //creditCard.ExpireDate = "13/24";      //throws exception
            //creditCard.ExpireDate = "00/24";      //throws exception
            //creditCard.ExpireDate = "06/22";      //throws exception

            creditCard.HolderName = "Süleyman Koparır";

            creditCard.Ccv = "927";
            //creditCard.Ccv = "9271";  //throws exception
            //creditCard.Ccv = "A12";   //throws exception

            Console.WriteLine(creditCard.ToString());
            //Number :1234567812345678 Holder : Süleyman Koparır Ccv : 927 Expire Date : 12/24

            Console.ReadKey();
        }
    }
}
