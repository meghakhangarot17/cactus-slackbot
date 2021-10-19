// using System;
// using System.ComponentModel;
// using System.Collections;
// using static System.ComponentModel.TypeDescriptor;
// using CsvHelper;
// using HtmlAgilityPack;
// using System.IO;
// using System.Collections.Generic;
// using System.Globalization;
// using SlackAPI;


// namespace project
// {

//     public class Row
//     {
//         public string Title { get; set; }
//     }



//     class Program
//     {
//         static void Main(string[] args)
//         {

//             var urlWithAccessToken = "https://hooks.slack.com/services/{YOUR}/{ACCESS}/{TOKENS}";

//             var client = new SlackClient(urlWithAccessToken);

//             client.PostMessage(username: "Mr. Torgue",
//                        text: "THIS IS A TEST MESSAGE! SQUEEDLYBAMBLYFEEDLYMEEDLYMOWWWWWWWW!",
//                        channel: "#general");

//             HtmlWeb web = new HtmlWeb();
//             // HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/Greece");
//             // HtmlDocument doc = web.Load("https://app.slack.com/client/T02J23BGBUK/C02JRNQDG2U");
//             // PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(doc);

//             // foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(doc))
//             // {
//             //     string name = descriptor.Name;
//             //     object value = descriptor.GetValue(doc);
//             //     Console.WriteLine("{0}={1}", name, value);
//             // }
//             // Console.WriteLine(doc);
//             // var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='p-rich_text_section']");
//             // Console.WriteLine(HeaderNames);
//             // foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(HeaderNames))
//             // {
//             //     string name = descriptor.Name;
//             //     object value = descriptor.GetValue(HeaderNames);
//             //     Console.WriteLine("{0}={1}", name, value);
//             // }

//             // var titles = new List<Row>();
//             // foreach (var item in HeaderNames)
//             // {
//             //     titles.Add(new Row { Title = item.InnerText });
//             // }
//             // using (var writer = new StreamWriter("./example.csv"))
//             // using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//             // {
//             //     csv.WriteRecords(titles);
//             // }

//             Console.WriteLine("Hello World!");
//         }
//     }
// }
