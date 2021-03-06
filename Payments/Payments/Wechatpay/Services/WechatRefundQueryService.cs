﻿using Payments.Core;
using Payments.Properties;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;
using Util;
using Util.Helpers;
namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 退款订单查询
    /// </summary>
    public class WechatRefundQueryService : WechatpayServiceBase<WechatRefundQueryRequest>, IWechatRefundQueryService
    {     /// <summary>
          /// 初始化微信App支付服务
          /// </summary>
          /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundQueryService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }

        public Task<PayResult> RefundQuery(WechatRefundQueryRequest param)
        {
            return Request(param);
        }
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetRefundQueryUrl();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatRefundQueryRequest param)
        {
            builder.Add(WechatpayConst.TransactionId, param.TransactionId).Add(WechatpayConst.OutTradeNo, param.OrderId)
                   .Add(WechatpayConst.OutRefundNo, param.OutRefundNo).Add(WechatpayConst.RefundId, param.RefundId)
                   .Remove(WechatpayConst.SpbillCreateIp).Remove(WechatpayConst.NotifyUrl); ;
        }
    }
}
