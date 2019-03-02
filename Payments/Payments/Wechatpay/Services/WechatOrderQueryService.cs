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
    /// 订单查询服务
    /// </summary>
    public class WechatOrderQueryService : WechatpayServiceBase<WechatOrderQueryRequest>, IWechatOrderQueryService
    {

        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatOrderQueryService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {
            IsWriteLog = false;
        }



        public Task<PayResult> QueryAsync(WechatOrderQueryRequest param)
        {
            return Request(param);
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatOrderQueryRequest param)
        {
            builder.Add(WechatpayConst.TransactionId, param.TransactionId).Add(WechatpayConst.OutTradeNo, param.OrderId);
        }

        protected override void ValidateParam(WechatOrderQueryRequest param)
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
            return config.GetOrderQueryUrl();
        }
    }
}
