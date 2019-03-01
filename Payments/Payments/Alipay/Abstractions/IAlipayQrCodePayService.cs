using System.Threading.Tasks;
using Payments.Alipay.Parameters.Requests;

namespace Payments.Alipay.Abstractions {
    /// <summary>
    /// 支付宝二维码支付
    /// </summary>
    public interface IAlipayQrCodePayService {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        Task<string> PayAsync( AlipayPrecreateRequest request );
    }
}
