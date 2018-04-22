﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace RefServices
{
    public class MyEdnpointBehaviorssExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(MyEdnpointBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new MyEdnpointBehavior();
        }
    }
}
