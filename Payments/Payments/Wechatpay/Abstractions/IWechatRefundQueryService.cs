﻿using Payments.Attributes;
using Payments.Core;
using Payments.Wechatpay.Parameters.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    [PayService("退款订单查询")]
    public interface IWechatRefundQueryService
    { /// <summary>
      /// 订单查询
      /// </summary>
      /// <param name="param"></param>
      /// <returns></returns>
        Task<PayResult> RefundQuery(WechatRefundQueryRequest param);
    }
}
