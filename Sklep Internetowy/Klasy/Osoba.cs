﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    abstract class Osoba : IPrintable
    {
        protected string imie, nazwisko;
        protected int id;

        public abstract string TextToPrint();
    }
}
