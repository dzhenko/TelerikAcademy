using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweets
{
    public class TweetsManager
    {
        // Since the new api of twiter, tweets can not be obtained unless you login. Instead of that I will return some Tweets objects from here. Cheers!

        public static IEnumerable<Tweet> GetTweets(string username = "pesho")
        {
            return new List<Tweet>()
            {
                new Tweet() {Date=DateTime.Now.AddDays(-1), Text="Left twitter :(", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-1.5), Text="Gonna leave this twitter", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-2), Text="So angry !", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-2.5), Text="Still waiting...", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-3), Text="Cmon guys .. change my pass", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-3.5), Text="Administration sucks", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-4), Text="They write bad stuff for me", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-4.5), Text="Someone stole my twitter", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-5), Text="Damn it - left twitter logged in", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-5.5), Text="Wow I can chat with anyone :)", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-6), Text="Woot ! So many ppl here", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-6.5), Text="This looks fun", User = username},
                new Tweet() {Date=DateTime.Now.AddDays(-7), Text="Joined Twitter :)", User = username},
            };
        }
    }
}