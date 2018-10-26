using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Helpers;
using Senparc.NeuChar.MessageHandlers;
using Senparc.Weixin.MP.AppStore;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TechSummitSample.MessageHandlers
{
    public class CustomMpMessageHandler : MessageHandler<CustomMpMessageContext>
    {
        public CustomMpMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0, DeveloperInfo developerInfo = null)
            : base(inputStream, postModel, maxRecordCount, developerInfo)
        {
        }

        //public override Task<IResponseMessageBase> OnTextOrEventRequestAsync(RequestMessageText requestMessage)
        //{
        //    return Task.Factory.StartNew(() =>
        //    {
        //        var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
        //        responseMessage.Content = "你刚才发送了文字：" + requestMessage.Content;
        //        return responseMessage as IResponseMessageBase;
        //    });
        //}

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageImage>();
            responseMessage.Image.MediaId = "你好！";
            return responseMessage;
        }


        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            //throw new NotImplementedException();

            var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "欢迎来到 2018 Tech Summit 《基于 .Net Core 的微信快速开发和持续集成》课堂！";
            return responseMessage;
        }
    }
}
