using System;
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
    public class WechatRefundNotifyService : WechatpayNotifyServiceBase, IWechatRefundNotifyService
    {

        public WechatRefundNotifyService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {

        }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId => GetParam(WechatpayConst.RefundId);
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string OutRefundNo => GetParam(WechatpayConst.OutRefundNo);
        /// <summary>
        /// 退款总金额
        /// </summary>
        public decimal RefundFee => GetParam(WechatpayConst.RefundFee).ToDecimal() / 100M;

        /// <summary>
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        public decimal SettlementRefundFee => GetParam(WechatpayConst.SettlementRefundFee).ToDecimal() / 100M;
        /// <summary>
        /// 退款成功时间
        /// </summary>
        public DateTime SuccessTime => GetParam(WechatpayConst.SuccessTime).ToDate();

        protected override void InitResult()
        {
            //建议使用 WechatRefundQueryService
            //TODO解密 https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_16&index=10
            Result = new WechatpayResult(ConfigProvider, Web.Body);
        }

    }
}
