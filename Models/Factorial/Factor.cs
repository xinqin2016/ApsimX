﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Core;
using System.Xml.Serialization;
using System.Xml;

namespace Models.Factorial
{
    [Serializable]
    [ViewName("UserInterface.Views.FactorView")]
    [PresenterName("UserInterface.Presenters.FactorPresenter")]
    [AllowDropOn("Factors")]
    public class Factor : ModelCollection
    {
        public List<string> Paths { get; set; }

        [XmlIgnore]
        public List<FactorValue> FactorValues { get { return ModelsMatching<FactorValue>(); } }


        //public Model Child { get; set; }
    }
}
