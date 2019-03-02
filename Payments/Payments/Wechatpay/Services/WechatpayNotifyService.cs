using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Properties;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using Util;
using Util.Helpers;
using Util.Validations;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    public class WechatpayNotifyService : WechatpayNotifyServiceBase, IWechatpayNotifyService
    {

        public WechatpayNotifyService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }


    }
}
