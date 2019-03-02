using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Exceptions;
using Util.Validations;

namespace Payments.Core
{
    /// <summary>
    /// 订单查询
    /// </summary>
    public class OrderQueryParam : IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        public ValidationResultCollection Validate()
        {    
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid)
                return ValidationResultCollection.Success;
            throw new Warning(result.First().ErrorMessage);
        }
    }
}
