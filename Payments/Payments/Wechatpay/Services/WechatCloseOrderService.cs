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
    /// 关闭订单服务
    /// </summary>
    public class WechatCloseOrderService : WechatpayServiceBase<WechatCloseOrderRequest>, IWechatCloseOrderService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatCloseOrderService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }



        public Task<PayResult> CloseAsync(WechatCloseOrderRequest param)
        {
            return Request(param);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatCloseOrderRequest param)
        {
            builder.Add(WechatpayConst.TransactionId, param.TransactionId).Add(WechatpayConst.OutTradeNo, param.OrderId).Remove(WechatpayConst.SpbillCreateIp);
        }

        protected override void ValidateParam(WechatCloseOrderRequest param)
        {
            if (param.TransactionId.IsEmpty() && param.OrderId.IsEmpty())
            {
                throw new ArgumentNullException("TransactionId and OrderId not all null");
            }
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetOrderCloseUrl();
        }
    }
}
