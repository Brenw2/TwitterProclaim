using System;
using TrumpTwitterFun.Model;
using TwitterProclaim.TwilioApi;

namespace TrumpTwitterFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetNumberMessage = "Please enter number to send tweet: ";
            Console.WriteLine(targetNumberMessage);

            var targetNumber = Console.ReadLine();

            var twilio = new TwilioCaller();
            var twitter = new TwitterAPI.TweetRetriever();
            
            //must have a twilio account set up here
            var twilioAccount = new Model.TwiloModel
            {
                AuthToken = "",
                Number = "",
                Sid = ""
            };

            //must have twitter api account set up here 
            var twitterAccount = new TwitterAuth
            {
                ConsumerKey = "",

                ConsumerSeceret = "",

                AccessToken = "",

                AccessSecret = ""
                
            };
            //twitter username goes here
            var tweet  = twitter.GetTweets(twitterAccount, "");

            var message = twilio.MessagePersonWithTweet(twilioAccount, targetNumber, tweet);

            Console.WriteLine(message);
            Console.WriteLine("Press Any Key to close program.");
            Console.ReadLine();
        }
    }
}
