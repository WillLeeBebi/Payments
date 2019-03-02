using System;
using System.Threading.Tasks;
using Payments.Core;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Results;
using Util;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Extensions;

namespace Payments.Wechatpay.Services.Base
{
    /// <summary>
    /// 微信支付服务
    /// </summary>
    public abstract class WechatpayServiceBase : WechatpayServiceBase<PayParam>, IPayService
    {

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayServiceBase(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        public Task<PayResult> PayAsync(PayParam param)
        {
            return Request(param);
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitBuilder(WechatpayParameterBuilder builder, PayParam param)
        {
            builder.Body(param.Subject).OutTradeNo(param.OrderId).TradeType(GetTradeType())
                .TotalFee(param.Money).NotifyUrl(param.NotifyUrl).Attach(param.Attach).OpenId(param.OpenId);

        }


        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetOrderUrl();
        }

        /// <summary>
        /// 获取支付类型
        /// </summary>
        /// <returns></returns>
        protected abstract string GetTradeType();

    }
}
