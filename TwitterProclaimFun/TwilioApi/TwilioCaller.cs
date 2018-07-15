using TrumpTwitterFun.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwitterProclaim.TwilioApi
{
    public class TwilioCaller
    {
        
        public string MessagePersonWithTweet(TwiloModel twilio, string toNumber, string tweet)
        {

            var accountSid = twilio.Sid;
            var authToken = twilio.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: tweet,
                @from: twilio.Number,
                to: toNumber
            );

            return  "This tweet was sent: " + message.Body;
        }
    }
}
