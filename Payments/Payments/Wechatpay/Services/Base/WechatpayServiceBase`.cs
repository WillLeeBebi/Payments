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
using Util.Validations;

namespace Payments.Wechatpay.Services.Base
{



    public abstract class WechatpayServiceBase<TPayParam> where TPayParam : class, IValidation, new()
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IWechatpayConfigProvider ConfigProvider;

        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayServiceBase(IWechatpayConfigProvider configProvider)
        {
            configProvider.CheckNull(nameof(configProvider));
            ConfigProvider = configProvider;
        }

        /// <summary>
        /// 是否写日志
        /// </summary>
        protected bool IsWriteLog { get; set; } = true;

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate(WechatpayConfig config, TPayParam param)
        {
            config.CheckNull(nameof(config));
            param.CheckNull(nameof(param));
            config.Validate();
            param.Validate();
            ValidateParam(param);
        }

        protected virtual async Task<PayResult> Request(TPayParam param)
        {
            var config = await ConfigProvider.GetConfigAsync();
            Validate(config, param);
            var builder = new WechatpayParameterBuilder(config);
            Config(builder, param);
            return await RequstResult(config, builder);
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected virtual void ValidateParam(TPayParam param)
        {
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected void Config(WechatpayParameterBuilder builder, TPayParam param)
        {
            builder.Init();
            InitBuilder(builder, param);
        }



        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected abstract void InitBuilder(WechatpayParameterBuilder builder, TPayParam param);


        /// <summary>
        /// 请求结果
        /// </summary>
        protected async Task<PayResult> RequstResult(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            var result = new WechatpayResult(ConfigProvider, await Request(config, builder));
            if (IsWriteLog)
            {
                WriteLog(config, builder, result);
            }
            return await CreateResult(config, builder, result);
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        protected virtual async Task<string> Request(WechatpayConfig config, WechatpayParameterBuilder builder)
        {
            if (IsSend == false)
                return string.Empty;
            return await Web.Client()
                .Post(GetRequestUrl(config))
                .XmlData(builder.ToXml())
                .ResultAsync();
        }

        /// <summary>
        /// 获取功能Url
        /// </summary>
        /// <returns></returns>
        protected abstract string GetRequestUrl(WechatpayConfig config);




        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("微信支付")
                .Content($"支付方式 : {GetType()}")
                .Content($"支付网关 : {config.GetOrderUrl()}")
                .Content("请求参数:")
                .Content(builder.ToXml())
                .Content()
                .Content("返回结果:")
                .Content(result.GetParams())
                .Content()
                .Content("原始响应: ")
                .Content(result.Raw)
                .Trace();
        }


        /// <summary>
        /// 创建支付结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual async Task<PayResult> CreateResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            var success = (await result.ValidateAsync()).IsValid;
            return new PayResult(success, result.GetPrepayId(), result.Raw)
            {
                Parameter = builder.ToString(),
                Message = result.GetReturnMessage(),
                Result = success ? GetResult(config, builder, result) : null
            };
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected virtual string GetResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            return result.GetPrepayId();
        }



        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog()
        {
            try
            {
                return Log.GetLog(WechatpayConst.TraceLogName);
            }
            catch
            {
                return Log.Null;
            }
        }

    }
}
