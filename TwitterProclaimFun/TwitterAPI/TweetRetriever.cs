using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using TrumpTwitterFun.Model;

namespace TrumpTwitterFun.TwitterAPI
{
    public class TweetRetriever
    {

        public string GetTweets(TwitterAuth obj, string twitterScreenName)
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore() 
                {
                    ConsumerKey = obj.ConsumerKey,
                    ConsumerSecret = obj.ConsumerSeceret,
                    AccessToken = obj.AccessToken,
                    AccessTokenSecret = obj.AccessSecret,
                    
                }
            };

            var twitterContext = new TwitterContext(auth);

            var tweets = (from tweet in twitterContext.Status
                where tweet.Type == StatusType.User && tweet.ScreenName == twitterScreenName
                select tweet).Take(3);

            var mostRecentTweet = tweets.FirstOrDefault();
            return mostRecentTweet?.Text;
        }
    }
}
