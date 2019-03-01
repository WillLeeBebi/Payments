﻿using Payments.Alipay.Abstractions;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Parameters.Requests;
using Payments.Alipay.Services.Base;
using Payments.Core;
using Payments.Properties;
using System.Threading.Tasks;
using Util;
using Util.Exceptions;
namespace Payments.Alipay.Services
{
    /// <summary>
    /// 支付宝条码支付服务
    /// </summary>
    public class AlipayBarcodePayService : AlipayServiceBase, IAlipayBarcodePayService {
        /// <summary>
        /// 初始化支付宝条码支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayBarcodePayService( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">条码支付参数</param>
        public async Task<PayResult> PayAsync( AlipayBarcodePayRequest request ) {
            return await PayAsync( request.ToParam() );
        }

        /// <summary>
        /// 获取场景
        /// </summary>
        protected override string GetScene() {
            return "bar_code";
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.trade.pay";
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        protected override PayWay GetPayWay() {
            return PayWay.AlipayBarcodePay;
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam( PayParam param ) {
            if( param.AuthCode.IsEmpty() )
                throw new Warning( PayResource.AuthCodeIsEmpty );
        }

        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitContentBuilder( AlipayContentBuilder builder, PayParam param ) {
            builder.AuthCode( param.AuthCode );
        }
    }
}
