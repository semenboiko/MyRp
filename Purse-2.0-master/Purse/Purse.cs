﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purse
{
    public class Purse
    {
        public BusinessCard busCard;
        public GoldenCard goldCard;
        public CreditCard credCard;
        
        public IMoney cash;

        public Purse()
        {
            cash = new Money();
            cash.SetCash(5000);
            busCard = new BusinessCard();
            goldCard = new GoldenCard();
            credCard = new CreditCard();
            
        }


    }
}
