﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities.OrderAggregate
{
        public enum OrderStatus
        {
            [EnumMember(Value = "Pending")]
            Pending,

            [EnumMember(Value = "Payment Received")]
            PaymentRecevied,

            [EnumMember(Value = "Payment Failed")]
            PaymentFailed
        }
}