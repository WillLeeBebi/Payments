﻿using System.Threading.Tasks;
using Payments.Alipay.Abstractions;
using Payments.Alipay.Configs;
using Payments.Alipay.Parameters;
using Payments.Alipay.Parameters.Requests;
using Payments.Alipay.Services.Base;
using Payments.Core;

namespace Payments.Alipay.Services {
    /// <summary>
    /// 支付宝App支付服务
    /// </summary>
    public class AlipayAppPayService : AlipayServiceBase, IAlipayAppPayService {
        /// <summary>
        /// 初始化支付宝App支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayAppPayService( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<string> PayAsync( AlipayAppPayRequest request ) {
            var result = await PayAsync( request.ToParam() );
            return result.Result;
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        protected override Task<PayResult> RequstResult( AlipayConfig config, AlipayParameterBuilder builder ) {
            var result = builder.Result( true );
            WriteLog( config, builder, result );
            return Task.FromResult( new PayResult { Result = result } );
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.trade.app.pay";
        }
 
    }
}