using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeVito_antiqueShop
{

    //create first class with data and methods : Soap
    internal class Soap
    {
        string _SoapName;
        decimal _SoapWeight;
        decimal _SoapPrice;
        Image _Photo;


        // zero arg ctor
        public Soap() { }

        // four arg ctor initializing private members 
        public Soap(string n, decimal w, decimal p, Image ph)
        {
            _SoapName = n;
            _SoapWeight = w;
            _SoapPrice = p;
            _Photo = ph;

        }

        // prop blocks for each data member

        public string SoapName
        { 
            get { return _SoapName; } 
        
        }

        public decimal SoapWeight
        { 
            get { return _SoapWeight; } 
        
        }

        public decimal SoapPrice
        { 
        get { return _SoapPrice; }
                
        }
        
        public Image Photo
        { get { return _Photo; } 
        
        }

        // testing for Git

        // look at all my cool code!!!! Its a branch!!! 


    }

}
