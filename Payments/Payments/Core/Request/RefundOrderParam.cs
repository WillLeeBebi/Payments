using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Util.Exceptions;
using Util.Validations;
namespace Payments.Core
{
    /// <summary>
    /// 退款
    /// </summary>
    public class RefundOrderParam : IValidation
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
        [Required()]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 支付金额，单位：元
        /// </summary>
        [Required()]
        public decimal Money { get; set; }


        /// <summary>
        /// 退款金额，单位：元
        /// </summary>
        [Required()]
        public decimal RefundMoney { get; set; }


        public string RefundDesc { get; set; }
        /// <summary>
        /// 退款通知Url
        /// </summary>
        public string NotifyUrl { get; set; }



        public ValidationResultCollection Validate()
        {
            var result = DataAnnotationValidation.Validate(this);
            if (result.IsValid)
                return ValidationResultCollection.Success;
            throw new Warning(result.First().ErrorMessage);
        }
    }
}
