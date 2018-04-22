using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace RefServices
{
    public class MyMessageInspector : IDispatchMessageInspector
    {

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //  Console.WriteLine(request.ToString());
            using (StreamWriter fs = new StreamWriter(@"C:\Users\KOKO\Desktop\MessageInspektor\request1.xml"))
            {
                fs.Write(request.ToString());

            }
            return request;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Console.WriteLine(reply.ToString());
            using (StreamWriter fs = new StreamWriter(@"C:\Users\nrpopov\KOKO\MessageInspektor\response1.xml"))
            {
                fs.Write(reply.ToString());

            }
        }

    }
}
