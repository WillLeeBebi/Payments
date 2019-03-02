using Payments.Core;
using Payments.Wechatpay.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Abstractions
{
    public interface IWechatpayPayService<T> where T: PayParamBase
    {
        Task<PayResult> PayAsync(T t);
    }
}
