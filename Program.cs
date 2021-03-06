using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SlackAPI;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace project
{

    public class Row
    {
        public string ChannelName { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTopic { get; set; }

        public int Number_of_members { get; set; }

        public string UserName { get; set; }
        public string UserId { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime FeedbackDate { get; set; }
    }

    class Async
    {
        public async Task Run()
        {
            // instantiate a new Slack Client by provding a token
            var token = "xoxb-2614113555971-2630584309489-1cVuqys96jugciDxfVA9Q5Qa";
            var client = new SlackTaskClient(token);

            // get channel list
            var listRes = await client.GetConversationsListAsync();
            // get users list
            var userRes = await client.GetUserListAsync();
            // id map stores user id and name
            var usersIdMap = new Dictionary<string, string>();
            foreach (User user in userRes.members)
            {
                usersIdMap[user.id] = user.name;
            }


            var feedback = new List<Row>();


            foreach (Channel channel in listRes.channels)
            {
                // get all conversation history for the current channel
                var convs = await client.GetConversationsHistoryAsync(channel);
                Console.WriteLine("channel: " + channel.name);
                Console.WriteLine();

                foreach (Message message in convs.messages)
                {
                    string s = message.text;
                    if (s.IndexOf("feedback", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(s);
                        if (message.user != null)
                        {
                            Console.WriteLine("User id: " + message.user);
                            Console.WriteLine("User name: " + usersIdMap[message.user]);
                        }
                        Console.WriteLine("Message time: " + message.ts);
                        Console.WriteLine("channel: " + channel.name);
                        Console.WriteLine("channel id: " + channel.id);
                        Console.WriteLine("channel members: " + channel.num_members);
                        Console.WriteLine("channel topic: " + channel.topic.value);
                        Console.WriteLine();
                        feedback.Add(new Row { ChannelName = channel.name, ChannelId = channel.id, ChannelTopic = channel.topic.value, Number_of_members = channel.num_members, UserId = message.user, UserName = usersIdMap[message.user], FeedbackContent = s, FeedbackDate = message.ts });
                    }
                }
            }

            // export data to csv file
            using (var writer = new StreamWriter("./feedback.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(feedback);
            }

            return;
        }

        static void Main(string[] args)
        {
            // instantiate main class and start execution by calling its Run() method
            // then wait for the task to complete
            var p = new Async();
            p.Run().Wait();

            Console.ReadKey();
        }
    }
}
