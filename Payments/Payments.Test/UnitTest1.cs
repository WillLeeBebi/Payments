using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Payments;
using Payments.Alipay.Configs;
using Payments.Extensions;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters.Requests;
using System;
using Util;

namespace Tests
{



    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddPay(a =>
            {

                a.GatewayUrl = "https://openapi.alipaydev.com/gateway.do";
                a.AppId = "2017022705929269";
                a.PrivateKey = "MIIEowIBAAKCAQEA4/wh822ynz+AutSuBfVgK39y9kU/QjlSb7sAhiypOdomZT4p7fyaVmXLdg361E3BeykbTVVxaFNZjRZ2p7Mk5VPl6cFB+eU+yJ8tsi8a/6zmhjT3Wf4bMYE417Dld9UfAzsVNP/UyukqjNlx9QkOLzKqrgAT4xU0i7OiWHUDqt3j62NFLGy3ofZxDS/Bq0xbbO/nH5t0qhBZbD5u1AajxL7S2sdcVwG+w7f/g5DLDHVt21KSZi3ML5je1FzhQUz5Cgb8Z/7R2KNqDoG8CQqafrD6QRAk+U3Khx/OoNEADZyg27hRIEuLJNj7IiiK47QEQGCIdktynKzbdMqK0vnqWwIDAQABAoIBAHPehPLPYeUFxUsvJHLqzsHMuITplMj3kSowBIgs0qUQdksmWPEXXOlkOw/48u5LxnXt4m5fao/3LKBENnHs3mefSE6RZhK3rD0SiYrx3err2Q2EheI6/18dqeIVicppiqV9tb2F+IRYFMQZD43V2FusiIp+h5z1/gqydWQ3tHF19uh9WoKS6Lj8RVo+Z9iHovJEBFOqEgJWu8TON16Gk+aebj5diJd4Rz0JRMPFaJO5XT59A7r9YtrZLwEP17loKXCAHMlxgzye+Mwta3nDT4vBgPW7uqIV0lbRV9dTJC+W36eYjL2X4lvJ77deAix3MZS1NANIJ920VFw5ccbBcQECgYEA94nWk6ZfZdAAAbwZX9jmuY9SJJ4aVUHvgfTyao5jlGN5SeeZrmXvDYMPfzEtYwHsRwZj3x4CZoUWX4U1jVgL34tIZBE0n0hXKsBJBmJuykT4iPVNkb6egsLpw5MkTwmIGGjUAqmqfN5yzWMsT7Yj7rJ7+E6VMOcWtxom+btugjsCgYEA68cvZSB+6/fcj8sMV/3+vP9ZhTTAIjtkF4npg3t7/1KeryCGz/9kiolcxDnWoT7wMi1dHQn/c2Az5yx75ZBIq9vyS6cyYa1FmIeClqrz6e8hBqcvfvx05TqjEcf02ZOBVu7Y9aj7YVC6BQgkJ6rse6dbkKyNf13ATlhhe+CklmECgYEAs3jAlrSdnhe8qYVTcGa2gfsjt2DZ/s6bdEHAMPmjwUaN/cNpbUSCme1YIwPowEv4n1ZGutHrM6FyozbVqPEZSq6Vgdfnq0SrzlczmulrIkP3XnVcFDt8eZoQGrhoLtXeUrROYs/YyEgQPFGXIwQP8VR/BX0UNiyWD5Nqhs4aRVkCgYBr7r3ajFqtyMR2KtxWt5ZSjI49dV1zDj8Oq3pzTyb/RaIQx1IPi3lKFgGabmO7YuVwAuY6MeZ3uZVpASsidr9dtQ0g5sQghMJ0RaxZLp8D+wziT8xlVEpq2UHnFOMYavbthd9Z7eZNsTfGr+hlJFCndoBrJSKNKKys8LaHj9moYQKBgAk0H7IMMQgdaGQmczk9NenRI4uE5A2Mra8k8MeTJyXGkWG5Ew6eMr/pSTIrkN8iQkSswv8MGYkb0lyazvWlm5lLGF3x/Jmh+3XIsjmwHDSHiMJDBJVkpTbjGQ15KPouzCO3gDJZYYWOO0dDj9tTEvnN8ftjLGE2gSJdgKB5hyXa";
                a.PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnmjf+QpGqixBIgk2FYNigemzhiagH0T0qIAN4sHofOacqFYknNG3vZbsoFy5SfBuYBnqBLxF8rekoeKx3RnZn1KUS9KD7VOAlVVBRpopTM7AzvzQrylICF1atRSuSqvw14vCXbAnzvagJR1OLwSE/2uFAqrRAXCampMU30D3OiLgoyJoIMTzg28LGMYS0cnTs44OkgleQtlGWMBr0V1bpOvYTNveETeASbAUMp5J7ofy+JRpX1YwcjY95ecpQWv9dp72XzjKN5q6l1FlLUeIewRde+Ry70M5/P90ofzCVmcaq30pbp0fQh3KyI4SJ6+NdqlF/GzLwO61gbF9xwIZ0QIDAQAB";


            }, w =>
            {

                w.AppId = "wx6e95a65ad4ee0135";
                w.MerchantId = "1517630381";
                w.PrivateKey = "XIAKEweixinpay2019shjGGYGHD54hlk";
                w.NotifyUrl = "https://openapi.alipaydev.com/gateway.do";

            });

            //string orderId = "12313412424412441";
            string orderId = "1231341242441242241";
            var wechatpayNativePayService = serviceDescriptors.BuildServiceProvider().GetService<IWechatpayNativePayService>();
            var wechatpayNativePayRequest = new WechatpayNativePayRequest()
            {
                Subject = "订单标题",
                OrderId = orderId,
                Money = 0.01m,
                Attach = "附加参数",

            };
            var result1 = wechatpayNativePayService.PayAsync(wechatpayNativePayRequest).GetAwaiter().GetResult();

            //var wechatOrderQueryService = serviceDescriptors.BuildServiceProvider().GetService<IWechatOrderQueryService>();
            //var result2 = wechatOrderQueryService.QueryAsync(new  WechatOrderQueryRequest()
            //{
            //    OrderId = orderId
            //}).GetAwaiter().GetResult();

            //var wechatCloseOrderService = serviceDescriptors.BuildServiceProvider().GetService<IWechatCloseOrderService>();
            //var result3 = wechatCloseOrderService.CloseAsync(new  WechatCloseOrderRequest()
            //{
            //    OrderId = orderId
            //}).GetAwaiter().GetResult();


            //var result4 = wechatOrderQueryService.QueryAsync(new  WechatOrderQueryRequest()
            //{
            //    OrderId = orderId
            //}).GetAwaiter().GetResult();

 

            //var wechatRefundOrderService = serviceDescriptors.BuildServiceProvider().GetService<IWechatRefundOrderService>();
            //var wechatRefundOrderRequest = new WechatRefundOrderRequest()
            //{
            //    OutRefundNo = "123456789",
            //    OrderId = orderId,
            //    Money = 0.01m,
            //    RefundMoney=0.01m,

            //    //NotifyUrl= "https://weixin.qq.com/notify/"

            //};
            //var result22 = wechatRefundOrderService.RefundAsync(wechatRefundOrderRequest).GetAwaiter().GetResult();


            var wechatRefundQueryService = serviceDescriptors.BuildServiceProvider().GetService<IWechatRefundQueryService>();
            var wechatRefundQueryRequest = new WechatRefundQueryRequest()
            {
                //OutRefundNo = "123456789",
                OrderId = orderId,
          

                //NotifyUrl= "https://weixin.qq.com/notify/"

            };
            var result2231 = wechatRefundQueryService.RefundQuery(wechatRefundQueryRequest).GetAwaiter().GetResult();

        }

    }
}