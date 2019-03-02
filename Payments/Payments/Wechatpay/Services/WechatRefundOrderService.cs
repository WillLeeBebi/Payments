using Payments.Core;
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
    /// 订单退款
    /// </summary>
    public class WechatRefundOrderService : WechatpayServiceBase<WechatRefundOrderRequest>, IWechatRefundOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatRefundOrderService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }



        public Task<PayResult> RefundAsync(WechatRefundOrderRequest param)
        {
            return Request(param);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatRefundOrderRequest param)
        {
            builder.Add(WechatpayConst.TransactionId, param.TransactionId).Add(WechatpayConst.OutTradeNo, param.OrderId)
                .Add(WechatpayConst.OutRefundNo, param.OutRefundNo).TotalFee(param.Money)
                .RefundTotalFee(param.RefundMoney).NotifyUrl(param.NotifyUrl).Add(WechatpayConst.RefundDesc, param.RefundDesc)
                .Remove(WechatpayConst.SpbillCreateIp).Remove(WechatpayConst.NotifyUrl);
        }

        protected override void ValidateParam(WechatRefundOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OrderId.IsEmpty())
            {
                throw new ArgumentNullException("TransactionId and OrderId not all null");
            }
            if (param.RefundMoney <= 0)
            {
                throw new ArgumentNullException("RefundMoney must be over 0");
            }
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetRefundQueryUrl();
        }
    }
}
