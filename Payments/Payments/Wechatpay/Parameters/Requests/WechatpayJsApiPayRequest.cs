using Payments.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 微信JsApi支付参数
    /// </summary>
    public class WechatpayJsApiPayRequest : PayParamBase
    {
        /// <summary>
        /// 微信的OpenId
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 附加数据，通知时原样返回
        /// </summary>
        public string Attach { get; set; }
    }
   
}
