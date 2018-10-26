using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Helpers;
using Senparc.Weixin;
using Senparc.Weixin.WxOpen.AdvancedAPIs;
using Senparc.Weixin.WxOpen.Entities;
using Senparc.Weixin.WxOpen.Entities.Request;
using Senparc.Weixin.WxOpen.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TechSummitSample.MessageHandlers.WxOpen
{
    public class CustomWxOpenMessageHandler : WxOpenMessageHandler<CustomWxOpenMessageContext>
    {
        public CustomWxOpenMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
        }

        public override XDocument ResponseDocument => new XDocument();

        public override XDocument FinalResponseDocument => new XDocument();

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            CustomApi.SendText(Config.SenparcWeixinSetting.WxOpenAppId, requestMessage.FromUserName,
                "你刚才向小程序发送了文字：" + requestMessage.Content);
            return new SuccessResponseMessage();
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            CustomApi.SendText(Config.SenparcWeixinSetting.WxOpenAppId, requestMessage.FromUserName,
                "欢迎来到 2018 Tech Summit 《基于 .Net Core 的微信快速开发和持续集成》课堂！，这条消息来自小程序");

            return new SuccessResponseMessage();
        }
    }
}
