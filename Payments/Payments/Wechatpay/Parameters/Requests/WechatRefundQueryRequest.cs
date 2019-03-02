using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Exceptions;
using Util.Validations;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryRequest : IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId { get; set; }

        public ValidationResultCollection Validate()
        {
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid)
                return ValidationResultCollection.Success;
            throw new Warning(result.First().ErrorMessage);
        }
    }
}
